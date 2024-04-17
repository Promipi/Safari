using BACKEND.Common;
using BACKEND.Models;
using BACKEND.Services;
using Microsoft.AspNetCore.Mvc;

namespace BACKEND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        //completar todos los metodos teniendo en cuenta que se debe inyectar el repositorio de eventos
        //inyecta primero el repo de eventos
        //luego completa los metodos
        private IEventoRepository _eventoRepository;

        public EventosController(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<GetResponseDto<DataCollection<Evento>>>> Get(int page = 1, int take = 10)
        {
            List<Func<Evento, bool>> filter = new List<Func<Evento, bool>>() { x => x.Id == x.Id };
            var response = await _eventoRepository.GetAsync(filter, page, take);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("GetFromUser")]
        public async Task<ActionResult<GetResponseDto<DataCollection<Evento>>>> GetFromUser(string userId, int page = 1, int take = 10)
        {
            var response = await _eventoRepository.GetFromUserAsync(userId, page, take);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<PostResponseDto<Evento>>> Create(Evento eventoCreateDto)
        {
            var response = await _eventoRepository.CreateAsync(eventoCreateDto);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }

        [HttpPost("RegisterEvent")]
        public async Task<ActionResult<PostResponseDto<EventoToUser>>> RegisterEvent(string userId, string eventId)
        {
            var response = await _eventoRepository.RegisterEvent(userId, eventId);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<PostResponseDto<Evento>>> Update(Evento eventoUpdateDto)
        {
            var response = await _eventoRepository.UpdateAsync(eventoUpdateDto);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteResponseDto>> Delete(string id)
        {
            var response = await _eventoRepository.DeleteAsync(id);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }
        

    }
}