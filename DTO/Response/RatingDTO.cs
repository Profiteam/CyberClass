using Domain.Enum;
using Domain.Ratings;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class RatingDTO
    {
        public long UserId { get; set; }
        public long MaterialId { get; set; }
        public RatingType RatingType { get; set; }
        public DateTime Date { get; set; }

        public RatingDTO() { }

        public RatingDTO(Rating rating)
        {
            if (rating == null)
                return;
            UserId = rating.User.ID;
            MaterialId = rating.Material.ID;
            RatingType = rating.RatingType;
            Date = rating.Date;
        }
    }
}
