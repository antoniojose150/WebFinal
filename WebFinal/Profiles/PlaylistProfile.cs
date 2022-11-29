using AutoMapper;

namespace WebFinal.Profiles
{
    public class PlaylistProfile :Profile
    {
        public PlaylistProfile()
        {
            CreateMap<Models.Playlist, Models.Dtos.PlaylistForCreationDto>();
            CreateMap<Models.Playlist, Models.Dtos.PlaylistDto>();
            CreateMap<Models.Dtos.PlaylistForCreationDto, Models.Playlist>();
            CreateMap<Models.Dtos.PlaylistForUpdateDto, Models.Playlist>();
            CreateMap<Models.Playlist, Models.Dtos.PlaylistWithoutCancionesDto>();
            CreateMap<Models.Playlist, Models.Dtos.PlaylistForUpdateDto>();
            CreateMap<Models.Cancion, Models.Dtos.CancionDto>();


        }
    }
}
