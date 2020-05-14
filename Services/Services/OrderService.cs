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

        public IList<LessonDTO> GetPaidLessons(User user)
        {
            var result = new List<LessonDTO>();

            var buyMaterials = GetAll().Where(x => x.User == user && x.Status == Domain.Enum.OrderStatus.Paid).Select(x => x.Material).ToList();

            foreach(var buyMaterial in buyMaterials)
            {              
                foreach (var lesson in LessonService.GetAll().Where(x => x.Material == buyMaterial))
                {
                    result.Add(new LessonDTO(lesson, true));
                }
            }

            return result;
        }
    }
}
