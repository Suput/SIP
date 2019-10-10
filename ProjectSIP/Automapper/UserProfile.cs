using AutoMapper;
using ProjectSIP.Models.Identity;
using ProjectSIP.Models.Requests.Auth;
using ProjectSIP.Models.Responses.Identity;

namespace ProjectSIP.Automapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserRequest, User>();
            CreateMap<User, UserView>();
        }
    }
}
