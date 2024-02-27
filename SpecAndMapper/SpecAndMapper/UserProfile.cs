using AutoMapper;

namespace SpecAndMapper;

public class UserProfile : Profile
{
    public UserProfile()
    {			
        CreateMap<User, PublicUser>();
    }
}