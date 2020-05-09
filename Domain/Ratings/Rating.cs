using Domain.Enum;
using Domain.Materials;
using Domain.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Ratings
{
    public class Rating: PersistentObject
    {
        public virtual User User { get; set; }
        public virtual Material Material { get; set; }
        public virtual RatingType RatingType { get; set; }
        public virtual DateTime Date { get; set; }
    }
}
