using Domain.Ratings;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class RatingService : BaseCrudService<Rating>, IRatingService
    {
        public RatingService(IRepository<Rating> repository) : base(repository)
        {

        }
    }
}
