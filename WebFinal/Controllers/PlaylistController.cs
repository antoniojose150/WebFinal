using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebFinal.Models.Dtos;
using WebFinal.Services;

namespace WebFinal.Controllers
{
    [ApiController]
    [Route("api/playlist")]
    public class PlaylistController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IPlaylistRepository _playlistRepository;

        public PlaylistController(IPlaylistRepository playlistRepository, IMapper mapper)
        {
            _playlistRepository = playlistRepository ?? throw new ArgumentNullException(nameof(playlistRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpPost]
        public async Task<ActionResult<PlaylistForCreationDto>> CreatePlaylist(PlaylistForCreationDto playlist)
        {
            var playlistcreate = _mapper.Map<Models.Playlist>(playlist);

            await _playlistRepository.CreatePlaylist(playlistcreate);

            var playlistReturn = _mapper.Map<Models.Dtos.PlaylistDto>(playlistcreate);


            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaylistWithoutCancionesDto>>> GetPlaylists()
        {
            var playlist = await _playlistRepository.GetPlaylists();
            return Ok(_mapper.Map<IEnumerable<PlaylistWithoutCancionesDto>>(playlist));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPlaylist(int Id, bool incluyecanciones = false)
        {

            var playlist = await _playlistRepository.GetPlaylist(Id,incluyecanciones);
            if (playlist == null)
            {
                return NotFound();
            }
            if (incluyecanciones)
            {
                return Ok(_mapper.Map<PlaylistDto>(playlist));
            }
            return Ok(_mapper.Map<PlaylistWithoutCancionesDto>(playlist));
        }

        [HttpPut("{playlistId}")]
        public async Task<IActionResult> UpdatePlaylist(int playlistId, PlaylistForUpdateDto playlist)
        {

            var playlistUpdate = await _playlistRepository.GetPlaylist(playlistId, true);
            if (playlistUpdate == null)
            {
                return NotFound();
            }

            _mapper.Map(playlist, playlistUpdate);

            await _playlistRepository.SavesChangesAsync();

            return NoContent();

        }

        [HttpPatch("{playlistId}")]

        public async Task<ActionResult> PartialUpdatePlaylist(int playlistId, JsonPatchDocument<PlaylistForUpdateDto> patchDocument)
        {

            var playlistentity = await _playlistRepository.GetPlaylist(playlistId, false);
            if (playlistentity == null)
            {
                return NotFound();
            }

            var playlistpath = _mapper.Map<PlaylistForUpdateDto>(playlistentity);

            patchDocument.ApplyTo(playlistpath, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest("sdhvbksdh");
            }
            if (!TryValidateModel(playlistpath))
            {
                return BadRequest("segundi");
            }
            _mapper.Map(playlistpath, playlistentity);

            await _playlistRepository.SavesChangesAsync();

            return NoContent();
        }


    }
}
