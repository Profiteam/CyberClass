using Domain.Persons;
using Domain.Ratings;
using DTO.Request;
using DTO.Response;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class RatingService : BaseCrudService<Rating>, IRatingService
    {
        private IMaterialService MaterialService { get; set; }
        public RatingService(IRepository<Rating> repository, IMaterialService materialService) : base(repository)
        {
            MaterialService = materialService;
        }


        public RatingDTO CreateRating(CreateRatingDTO request, User user)
        {
            var material = MaterialService.GetAll().FirstOrDefault(x => x.ID == request.MaterialId) ?? throw new ServiceErrorException(605);

            var oldRating = GetAll().FirstOrDefault(x => x.User == user && x.Material == material);
                if (oldRating != null) 
                throw new ServiceErrorException(606);
            

            var rating = new Rating
            {
                User = user,
                Material = material,
                RatingType = request.RatingType,
                Date = DateTime.UtcNow
            };
            Create(rating);
            return new RatingDTO(rating);
        }

        public IList<MaterialDTO> GetMaterials(User user)
        {
            var materials = new List<MaterialDTO>();

            foreach(var material in MaterialService.GetAll().ToList())
            {
                int likeCount = GetAll().Where(x => x.Material == material && x.RatingType == Domain.Enum.RatingType.Like).Count();
                int disLikeCount = GetAll().Where(x => x.Material == material && x.RatingType == Domain.Enum.RatingType.Dislike).Count();

                bool myLike = false;
                bool myDislike = false;
                var myLiked = GetAll().FirstOrDefault(x => x.User == user && x.Material == material);
                if (myLiked != null)
                {
                    if (myLiked.RatingType == Domain.Enum.RatingType.Like)
                        myLike = true;
                    else 
                        myDislike = true;
                }
                
                materials.Add(new MaterialDTO(material, likeCount, disLikeCount, myLike, myDislike));
            }

            return materials;
        }

        public IList<MaterialDTO> GetMaterialsNotAutorize()
        {
            var materials = new List<MaterialDTO>();

            foreach (var material in MaterialService.GetAll())
            {
                int likeCount = GetAll().Where(x => x.Material == material && x.RatingType == Domain.Enum.RatingType.Like).Count();
                int disLikeCount = GetAll().Where(x => x.Material == material && x.RatingType == Domain.Enum.RatingType.Dislike).Count();
                materials.Add(new MaterialDTO(material, likeCount, disLikeCount));
            }

            return materials;
        }
    }
}
