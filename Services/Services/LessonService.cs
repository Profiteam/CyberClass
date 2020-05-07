using Domain.Materials;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class LessonService : BaseCrudService<Lesson>, ILessonService
    {
        public LessonService(IRepository<Lesson> repository) : base(repository)
        {

        }
    }
}
