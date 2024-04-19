using BACKEND.Common;
using BACKEND.Models;
using BACKEND.Models.DTOs;
using BACKEND.Persistence;
using System.Linq;

namespace BACKEND.Services
{
    public class EventoRepository : IEventoRepository
    {
        private SafariDbContext _context;
        public EventoRepository(SafariDbContext context)
        {
            _context = context;
        }
        public async Task<PostResponseDto<Evento>> CreateAsync(Evento eventoCreateDto)
        {
            eventoCreateDto.Id = Guid.NewGuid().ToString();
            var eventoNew = await _context.Eventos.AddAsync(eventoCreateDto);
            await _context.SaveChangesAsync();
            var response = new PostResponseDto<Evento>
            {
                Success = true,
                Message = "Success",
                Entity = eventoNew.Entity
            };
            return response;
        }

        public async Task<DeleteResponseDto> DeleteAsync(string idDelete)
        {
            var response = new DeleteResponseDto();
            try
            {
                var evento = new Evento { Id = idDelete };  
                if (evento != null)
                {
                    _context.Eventos.Remove(evento);
                    await _context.SaveChangesAsync();
                    response.Success = true;
                    response.Message = "Success";
                }
                else
                {
                    response.Message = "Evento not found";
                }
            }
            catch (System.Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<GetResponseDto<DataCollection<Evento>>> GetAsync(List<Func<Evento, bool>> filter, int page, int take)
        {
            var response = new GetResponseDto<DataCollection<Evento>>();
            try
            {
                var eventos = _context.Eventos.ToList();
                filter.ForEach(f => { eventos = eventos.Where(f).ToList(); });
                var result = await eventos.GetPagedAsync(page, take);

                response.Success = true;
                response.Message = "Success";
                response.Content = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<GetResponseDto<DataCollection<Evento>>> GetFromUserAsync(string userId, int page, int take)
        {
            var response = new GetResponseDto<DataCollection<Evento>>();
            try
            {
                var eventosId = _context.EventosToUsers.Where(x => x.UserId == userId);
                var eventos = new List<Evento>();
                foreach(var id in eventosId)
                {
                    var evento = await _context.Eventos.FindAsync(id);
                    eventos.Add(evento);
                }
                var result = await eventos.GetPagedAsync(page, take);
                response.Success = true;
                response.Message = "Success";
                response.Content = result;

            }
            catch(Exception Ex)
            {
                response.Message = Ex.Message;
            }
            return response;
        }

        public async Task<PostResponseDto<EventoToUser>> RegisterEvent(string userId, string eventId)
        {
            var eventoToUser = new EventoToUser { UserId = userId, EventoId = eventId };
            var eventoToUserNew = await _context.EventosToUsers.AddAsync(eventoToUser);
            await _context.SaveChangesAsync();
            var response = new PostResponseDto<EventoToUser>
            {
                Success = true,
                Message = "Success",
                Entity = eventoToUserNew.Entity
            };
            return response;
        }


        public async Task<PostResponseDto<Evento>> UpdateAsync(Evento eventoUpdateDto)
        {
            var response = new PostResponseDto<Evento>();
            try
            {
                var updateEntity =  _context.Eventos.Find(eventoUpdateDto.Id);
                updateEntity.Description = eventoUpdateDto.Description;
                updateEntity.Start = eventoUpdateDto.Start;
                updateEntity.End = eventoUpdateDto.End;
                updateEntity.Image = eventoUpdateDto.Image;
                updateEntity.Price = eventoUpdateDto.Price;

                 _context.Eventos.Update(updateEntity);
                 _context.SaveChanges();

                response.Success = true;
                response.Message = "Updated Successfully";

            }catch(Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;

        }
    }
}
