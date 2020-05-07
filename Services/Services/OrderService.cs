using Domain.Orders;
using Domain.Persons;
using DTO.Response;
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
                var paid = GetAll().FirstOrDefault(x => x.Material == mat && x.User == user);
                if (paid != null)
                    isPaid = true;
                lessons.Add(new LessonDTO(lesson, isPaid));

            }
            return lessons;

        }
    }
}
