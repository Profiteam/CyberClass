using Domain.Materials;
using Domain.Orders;
using Domain.Persons;
using Domain.Ratings;
using DTO.Request;
using DTO.Response;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
   
    public interface IUserService : IBaseCrudService<User>
    {
        User CreateUser(CreateUserDTO createUser);
    }

    public interface IAccountService : IBaseCrudService<UserSession>
    {
        SignInDTO AuthAdmin(string login, string password);
        SignInDTO AuthUser(string login, string password);
        UserDTO RegisterUser(CreateUserDTO createUser);
    }

    public interface IMaterialService : IBaseCrudService<Material>
    {

    }

    public interface ILessonService : IBaseCrudService<Lesson>
    {
        IList<LessonNotAuthDTO> GetLessonsNotAutarize(long matId);
    }

    public interface IRatingService : IBaseCrudService<Rating>
    {

    }

    public interface IOrderService : IBaseCrudService<Order>
    {
        IList<LessonDTO> GetLessons(long matId, User user);
    }
}