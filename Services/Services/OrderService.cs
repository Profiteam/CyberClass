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

        public IList<LessonDTO> GetLessons(long matId, string ipAddress, User user)
        {

            var mat = MaterialService.GetAll().FirstOrDefault(x => x.ID == matId) ?? throw new ServiceErrorException(605);
            string key = "Amo2R5chkTTsFq";
            string domain = "https://cyberclass-vod-hls.cdnvideo.ru";
            var time = DateTimeOffset.UtcNow.AddDays(2).ToUnixTimeSeconds();

            var result = new List<LessonDTO>();
            foreach (var lesson in LessonService.GetAll().Where(x => x.Material == mat && x.LessonType == Domain.Enum.LessonType.Free).ToList())
            {
                if (lesson.Url.Contains("/playlist"))
                {
                    var e = lesson.Url.IndexOf("/playlist");

                    var streamName = lesson.Url[domain.Length..e];
                    var url = HttpUtility.UrlDecode($"{key}:{time}:{ipAddress}:{streamName}");
                    var md5 = CryptHelper.Md5Sum_Raw(url);
                    var base64md5 = Base64Helper.Base64Encode(md5).Replace("+", "-").Replace("/", "_").Replace("=", "");
                    lesson.Url = ($"{lesson.Url}?e={time}&md5={base64md5}").Replace("http: ", "").Replace("https: ", "");
                    lesson.Url = $"//playercdn.cdnvideo.ru/aloha/players/cyberclass_player1.html?source={HttpUtility.UrlEncode(lesson.Url)}";
                    result.Add(new LessonDTO(lesson));
                }
                else if (lesson.Url.Contains("/chunklist"))
                {
                    var e = lesson.Url.IndexOf("/chunklist");

                    var streamName = lesson.Url[domain.Length..e];
                    var url = HttpUtility.UrlDecode($"{key}:{time}:{ipAddress}:{streamName}");
                    var md5 = CryptHelper.Md5Sum_Raw(url);
                    var base64md5 = Base64Helper.Base64Encode(md5).Replace("+", "-").Replace("/", "_").Replace("=", "");
                    lesson.Url = ($"{lesson.Url}?e={time}&md5={base64md5}").Replace("http: ", "").Replace("https: ", "");
                    lesson.Url = $"//playercdn.cdnvideo.ru/aloha/players/cyberclass_player1.html?source={HttpUtility.UrlEncode(lesson.Url)}";
                    result.Add(new LessonDTO(lesson));
                }
            }
                return result;

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

        public IList<LessonDTO> GetPaidLessons(User user, long matId, string ipAddress)
        {

            string key = "Amo2R5chkTTsFq";
            string domain = "https://cyberclass-vod-hls.cdnvideo.ru";
            var time = DateTimeOffset.UtcNow.AddDays(2).ToUnixTimeSeconds();
            var result = new List<LessonDTO>();

            var mat = MaterialService.GetAll().FirstOrDefault(x => x.ID == matId) ?? throw new ServiceErrorException(605);
            var buyMaterial = GetAll().FirstOrDefault(x => x.User == user && x.Status == Domain.Enum.OrderStatus.Paid && x.Material == mat).Material;
            
                foreach (var lesson in LessonService.GetAll().Where(x => x.Material == buyMaterial).ToList())
                {
                        if (lesson.Url.Contains("/playlist"))
                        {
                            var e = lesson.Url.IndexOf("/playlist");

                            var streamName = lesson.Url[domain.Length..e];
                            var url = HttpUtility.UrlDecode($"{key}:{time}:{ipAddress}:{streamName}");
                            var md5 = CryptHelper.Md5Sum_Raw(url);
                            var base64md5 = Base64Helper.Base64Encode(md5).Replace("+", "-").Replace("/", "_").Replace("=", "");
                            lesson.Url = ($"{lesson.Url}?e={time}&md5={base64md5}").Replace("http: ", "").Replace("https: ", "");
                            lesson.Url = $"//playercdn.cdnvideo.ru/aloha/players/cyberclass_player1.html?source={HttpUtility.UrlEncode(lesson.Url)}";
                            result.Add(new LessonDTO(lesson));
                        }
                        else if (lesson.Url.Contains("/chunklist"))
                        {
                            var e = lesson.Url.IndexOf("/chunklist");

                            var streamName = lesson.Url[domain.Length..e];
                            var url = HttpUtility.UrlDecode($"{key}:{time}:{ipAddress}:{streamName}");
                            var md5 = CryptHelper.Md5Sum_Raw(url);
                            var base64md5 = Base64Helper.Base64Encode(md5).Replace("+", "-").Replace("/", "_").Replace("=", "");
                            lesson.Url = ($"{lesson.Url}?e={time}&md5={base64md5}").Replace("http: ", "").Replace("https: ", "");
                            lesson.Url = $"//playercdn.cdnvideo.ru/aloha/players/cyberclass_player1.html?source={HttpUtility.UrlEncode(lesson.Url)}";
                            result.Add(new LessonDTO(lesson));
                        }                    
                }
            return result;

        }
    }
}
