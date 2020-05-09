using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Request
{
    public class CreateRatingDTO
    {
        public long MaterialId { get; set; }
        public RatingType RatingType { get; set; }

    }
}
