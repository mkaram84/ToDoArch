using AutoMapper;

namespace ToDoMonolithApi.Core;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Domain.Entities.User, Domain.Dtos.UserDto>()
            .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks));
        CreateMap<Domain.Dtos.UserToAddDto, Domain.Entities.User>();
        CreateMap<Domain.Dtos.UserToUpdateDto, Domain.Entities.User>();

        CreateMap<Domain.Entities.Task, Domain.Dtos.TaskDto>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));
        CreateMap<Domain.Dtos.TaskToAddDto, Domain.Entities.Task>();
        CreateMap<Domain.Dtos.TaskToUpdateDto, Domain.Entities.Task>();
    }
}
