using BACKEND.Common;
using BACKEND.Models.DTOs;
using BACKEND.Models;

namespace BACKEND.Services
{
    public interface IEventoRepository
    {
        public Task<GetResponseDto<DataCollection<Evento>>> GetAsync(List<Func<Evento, bool>> filter, int page, int take);

        public Task<GetResponseDto<DataCollection<Evento>>> GetFromUserAsync(string userId, int page, int take);

        public Task<PostResponseDto<Evento>> CreateAsync(Evento eventoCreateDto);

        public Task<PostResponseDto<EventoToUser>> RegisterEvent(string userId, string eventId);

        public Task<PostResponseDto<Evento>> UpdateAsync(Evento eventoUpdateDto);

        public Task<DeleteResponseDto> DeleteAsync(string idDelete);
    }
}
