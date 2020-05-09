using Domain.Materials;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class MaterialDTO
    {
        public long ID { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double TotalDuration { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public bool MyDislike { get; set; }
        public bool MyLike { get; set; }

        public MaterialDTO() { }

        public MaterialDTO(Material material, int likeCount, int disLikeCount)
        {
            if (material == null)
                return;
            ID = material.ID;
            Number = material.Number;
            Name = material.Name;
            Description = material.Description;
            Price = material.Price;
            TotalDuration = material.TotalDuration;
            LikeCount = likeCount;
            DislikeCount = disLikeCount;
        }

        public MaterialDTO(Material material, int likeCount, int disLikeCount, bool myLike, bool myDislike)
        {
            if (material == null)
                return;
            ID = material.ID;
            Number = material.Number;
            Name = material.Name;
            Description = material.Description;
            Price = material.Price;
            TotalDuration = material.TotalDuration;
            LikeCount = likeCount;
            DislikeCount = disLikeCount;
            MyLike = myLike;
            MyDislike = myDislike;

        }

    }
}
