using Domain.Materials;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class VideoService : BaseCrudService<Video>, IVideoService
    {
        public VideoService(IRepository<Video> repository) : base(repository)
        {

        }
    }
}
