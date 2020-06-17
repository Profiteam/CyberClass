using Domain.Materials;
using Domain.Orders;
using Domain.Persons;
using Domain.Ratings;
using DTO.Request;
using DTO.Response;
using Microsoft.AspNetCore.Http;
using Remotion.Linq.Clauses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
   
    public interface IUserService : IBaseCrudService<User>
    {
        User CreateUser(CreateUserDTO createUser);
        ProfileDTO GetMyProfile(User user);
        ProfileDTO EditMyProfile(EditProfileDTO request, User user);
    }

    public interface IAccountService : IBaseCrudService<UserSession>
    {
        SignInDTO AuthAdmin(string login, string password);
        bool AuthUser(AuthRequest authRequest);
        SignInDTO CheckCode(string login, string code);
        UserDTO RegisterUser(CreateUserDTO createUser);
    }

    public interface IMaterialService : IBaseCrudService<Material>
    {
        
    }
    public interface ISubService : IBaseCrudService<Sub>
    {
        bool CreateSub(CreateSubDTO request);
        IList<SubDTO> GetSubs();
    }

    public interface IActivationCodeService : IBaseCrudService<ActivationCode>
    {
        
    }
    public interface IPersonService : IBaseCrudService<Person>
    {
        Task<ProfileDTO> SetAvatar(IFormFile file,  User user);
    }

    public interface ILessonService : IBaseCrudService<Lesson>
    {
        IList<LessonNotAuthDTO> GetLessonsNotAutarize(long matId);
    }

    public interface IRatingService : IBaseCrudService<Rating>
    {
        RatingDTO CreateRating(CreateRatingDTO request, User user);
        IList<MaterialDTO> GetMaterials(User user);
        IList<MaterialDTO> GetMaterialsNotAutorize();
    }

    public interface IOrderService : IBaseCrudService<Order>
    {
        OrderDTO CreateOrder(CreateOrderDTO request, User user );
        IList<LessonDTO> GetLessons(long matId, User user);
        IList<LessonDTO> GetPaidLessons(User user, string ipAddress);
    }
}