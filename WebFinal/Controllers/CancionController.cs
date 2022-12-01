using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebFinal.Models;
using WebFinal.Models.Dtos;
using WebFinal.Services;


namespace WebFinal.Controllers
{
    [ApiController]
    [Route("api/playlist/{playlistId}/cancion")]
    public class CancionController : ControllerBase
    {

        private readonly IPlaylistRepository _playlistRepository;
        private readonly IMapper _mapper;

        public CancionController(IMapper mapper,  IPlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository ?? throw new ArgumentNullException(nameof(playlistRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CancionDto>>> GetCanciones(int playlistId)
        {

            if (!await _playlistRepository.PlaylistExistAsync(playlistId))
                {
                    return NotFound();
                }

            var cancionEntity = await _playlistRepository.GetCanciones(playlistId);

            
            return Ok(_mapper.Map<IEnumerable<CancionDto>>(cancionEntity));

        }

        [HttpGet("{cancionId}", Name ="GetCancion")]
        public async Task<ActionResult<CancionDto>> GetCancion(int playlistId,int cancionId)
        {

            if (!await _playlistRepository.PlaylistExistAsync(playlistId))
            {
                return NotFound();
            }

            var cancionEntity = await _playlistRepository.GetCancion(playlistId,cancionId);


            return Ok(_mapper.Map<CancionDto>(cancionEntity));

        }

        [HttpPost]
        public async Task<ActionResult<CancionDto>> CreateCancion(int playlistId, CancionFroCreationDto cancionCreate)
        {

            if (!await _playlistRepository.PlaylistExistAsync(playlistId))
            {
                return NotFound();
            }

            var cancionentity = _mapper.Map<Cancion>(cancionCreate);

            await _playlistRepository.AddCancion(playlistId,cancionentity);

            await _playlistRepository.SavesChangesAsync();


            var cancionreturn = _mapper.Map<Models.Dtos.CancionDto>(cancionentity);


            return CreatedAtRoute("GetCancion",
                new
                {
                    playlistId = playlistId,
                    cancionId = cancionreturn.Id
                }, cancionreturn);

        }

        [HttpPut("{cancionid}")]
        public async Task<ActionResult> UpdateCancion(int playlistId,int cancionId, CancionUpdateDto cancion)
        {
            if (!await _playlistRepository.PlaylistExistAsync(playlistId))
            {
                return NotFound();
            }

            var cancionentity = await _playlistRepository.GetCancion(playlistId,cancionId);
            if (cancionentity == null)
            {
                return NotFound();
            }

            _mapper.Map(cancion, cancionentity);

            await _playlistRepository.SavesChangesAsync();

            return NoContent();

        }


        [HttpPatch("{cancionId}")]

        public async Task<ActionResult> PartialUpdatePlaylist(int playlistId,int cancionId, JsonPatchDocument<CancionUpdateDto> patchDocument)
        {

            if (!await _playlistRepository.PlaylistExistAsync(playlistId))
            {
                return NotFound();
            }

            var cancionentity = await _playlistRepository.GetCancion(playlistId, cancionId);
            if (cancionentity == null)
            {
                return NotFound();
            }

            var cancionpath = _mapper.Map<CancionUpdateDto>(cancionentity);

            patchDocument.ApplyTo(cancionpath, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!TryValidateModel(cancionpath))
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(cancionpath, cancionentity);

            await _playlistRepository.SavesChangesAsync();

            return NoContent();
        }

    }
}
