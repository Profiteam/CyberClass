using Domain.Materials;
using Domain.Persons;
using DTO.Response;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class LessonService : BaseCrudService<Lesson>, ILessonService
    {
        private IMaterialService MaterialService { get; set; }
        private IUserService UserService { get; set; }
        public LessonService(IRepository<Lesson> repository, IMaterialService materialService, IUserService userService) : base(repository)
        {
            MaterialService = materialService;
            UserService = userService;
        }

        public IList<LessonNotAuthDTO> GetLessonsNotAutarize(long matId)
        {

            var mat = MaterialService.GetAll().FirstOrDefault(x => x.ID == matId) ?? throw new ServiceErrorException(605);

            return GetAll().Where(x => x.Material == mat).Select(x => new LessonNotAuthDTO(x)).ToList();
          
        }
    }
}
