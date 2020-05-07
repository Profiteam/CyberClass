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

        public MaterialDTO() { }

        public MaterialDTO(Material material)
        {
            if (material == null)
                return;
            ID = material.ID;
            Number = material.Number;
            Name = material.Name;
            Description = material.Description;
            Price = material.Price;
            TotalDuration = material.TotalDuration;
        }
    }
}
