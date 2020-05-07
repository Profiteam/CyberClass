using Domain.Materials;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class MaterialService : BaseCrudService<Material>, IMaterialService
    {
        public MaterialService(IRepository<Material> repository) : base(repository)
        {

        }
    }
}
