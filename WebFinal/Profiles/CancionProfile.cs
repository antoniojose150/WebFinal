using AutoMapper;

namespace WebFinal.Profiles
{
    public class CancionProfile : Profile
    {

        public CancionProfile()
        {
            CreateMap<Models.Cancion, Models.Dtos.CancionDto>();
            CreateMap<Models.Cancion, Models.Dtos.CancionFroCreationDto>();
            CreateMap<Models.Dtos.CancionFroCreationDto, Models.Cancion>();
            CreateMap<Models.Cancion, Models.Dtos.CancionUpdateDto>();
            CreateMap<Models.Dtos.CancionUpdateDto, Models.Cancion>();
            CreateMap<Models.Dtos.CancionDto, Models.Cancion>();
        }
    }
}
