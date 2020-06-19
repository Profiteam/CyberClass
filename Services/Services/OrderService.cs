using Domain.Orders;
using Domain.Persons;
using DTO.Request;
using DTO.Response;
using Org.BouncyCastle.Ocsp;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Utils;

namespace Services.Services
{
    public class OrderService : BaseCrudService<Order>, IOrderService
    {
        private IMaterialService MaterialService { get; set; }
        private ILessonService LessonService { get; set; }
        public OrderService(IRepository<Order> repository, IMaterialService materialService, ILessonService lessonService) : base(repository)
        {
            MaterialService = materialService;
            LessonService = lessonService;
        }

        public IList<LessonDTO> GetLessons(long matId, User user)
        {

            var mat = MaterialService.GetAll().FirstOrDefault(x => x.ID == matId) ?? throw new ServiceErrorException(605);

            
            var lessons = new List<LessonDTO>();
            foreach (var lesson in LessonService.GetAll().Where(x => x.Material == mat))
            {
                bool isPaid = false;
                var paid = GetAll().FirstOrDefault(x => x.Material == mat && x.User == user && x.Status == Domain.Enum.OrderStatus.Paid);
                if (paid != null)
                    isPaid = true;
                lessons.Add(new LessonDTO(lesson, isPaid));

            }
            return lessons;

        }

        public OrderDTO CreateOrder(CreateOrderDTO request, User user)
        {
            var material = MaterialService.GetAll().FirstOrDefault(x => x.ID == request.MaterialID) ?? throw new ServiceErrorException(605);

            var order = new Order
            {
                User = user,
                Material = material,
                AmountPay = material.Price,
                Date = DateTime.UtcNow,
                Status = Domain.Enum.OrderStatus.Paid
            };
            Create(order);

            return new OrderDTO(order);
        }

        public IList<LessonDTO> GetPaidLessons(User user, string ipAddress)
        {

            string key = "Amo2R5chkTTsFq";
            string domain = "https://cyberclass-vod-hls.cdnvideo.ru";
            var time = DateTimeOffset.UtcNow.AddDays(2).ToUnixTimeSeconds();
            var result = new List<LessonDTO>();

            var buyMaterials = GetAll().Where(x => x.User == user && x.Status == Domain.Enum.OrderStatus.Paid).Select(x => x.Material).ToList();

            foreach(var buyMaterial in buyMaterials)
            {              
                foreach (var lesson in LessonService.GetAll().Where(x => x.Material == buyMaterial).ToList())
                {
                    foreach(var video in lesson.Videos.ToList())
                    {
                        if (video.Url.Contains("/playlist"))
                        {
                            var e = lesson.Url.IndexOf("/playlist");

                            var streamName = lesson.Url[domain.Length..e];
                            var url = HttpUtility.UrlDecode($"{key}:{time}:{ipAddress}:{streamName}");
                            var md5 = CryptHelper.Md5Sum_Raw(url);
                            var base64md5 = Base64Helper.Base64Encode(md5).Replace("+", "-").Replace("/", "_").Replace("=", "");
                            video.Url = ($"{lesson.Url}?e={time}&md5={base64md5}").Replace("http: ", "").Replace("https: ", "");
                            video.Url = $"//playercdn.cdnvideo.ru/aloha/players/cyberclass_player1.html?source={HttpUtility.UrlEncode(lesson.Url)}";
                            result.Add(new LessonDTO(lesson, true));
                        }
                        else if (video.Url.Contains("/chunklist"))
                        {
                            var e = lesson.Url.IndexOf("/chunklist");

                            var streamName = lesson.Url[domain.Length..e];
                            var url = HttpUtility.UrlDecode($"{key}:{time}:{ipAddress}:{streamName}");
                            var md5 = CryptHelper.Md5Sum_Raw(url);
                            var base64md5 = Base64Helper.Base64Encode(md5).Replace("+", "-").Replace("/", "_").Replace("=", "");
                            video.Url = ($"{lesson.Url}?e={time}&md5={base64md5}").Replace("http: ", "").Replace("https: ", "");
                            video.Url = $"//playercdn.cdnvideo.ru/aloha/players/cyberclass_player1.html?source={HttpUtility.UrlEncode(lesson.Url)}";
                            result.Add(new LessonDTO(lesson, true));
                        }
                    }
                }
            }

            return result;
        }
    }
}
