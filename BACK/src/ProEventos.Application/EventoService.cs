using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Application.Interfaces;
using ProEventos.Domain;
using ProEventos.Persistence;
using ProEventos.Persistence.Contexts;
using ProEventos.Persistence.Intefaces;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralRepository _geralRepo;
        private readonly IEventoRepository _eventoRepo;
        public EventoService(IGeralRepository geralRepo, IEventoRepository eventoRepo)
        {
            this._eventoRepo = eventoRepo;
            this._geralRepo = geralRepo;
        }  

        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralRepo.Add<Evento>(model);
                if (await _geralRepo.SaveChangesAsync())
                {
                    return await _eventoRepo.GetEventoByIdAsync(model.Id);
                }
                return null;
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        
        public async Task<Evento> UpdateEventos(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoRepo.GetEventoByIdAsync(eventoId);
                if (evento == null) throw new Exception("Evento não foi encontrado para atualizar.");

                model.Id = evento.Id;
                
                _geralRepo.Update<Evento>(model);
                if (await _geralRepo.SaveChangesAsync())
                {
                   return await _eventoRepo.GetEventoByIdAsync(model.Id);
                }
                return null;
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }       
        }
        public async Task<bool> DeleteEventos(int eventoId)
        {
            try
            {
                var evento = await _eventoRepo.GetEventoByIdAsync(eventoId);
                if (evento == null) throw new Exception("Evento não foi encontrado para deletar.");

                _geralRepo.Delete<Evento>(evento);
                 return await _geralRepo.SaveChangesAsync();
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepo.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {

            try
            {
                var eventos = await _eventoRepo.GetEventoByIdAsync(eventoId,includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
           
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepo.GetAllEventosByTemaAsync(tema,includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
    }
}