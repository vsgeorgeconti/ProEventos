using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexts;
using ProEventos.Persistence.Intefaces;

namespace ProEventos.Persistence
{
    public class PalestranteRepository : IPalestranteRepository
    {
        private readonly ProEventosContext _context;
        public PalestranteRepository(ProEventosContext context)
        {
            this._context = context;
            
        }
        
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

                if(includeEventos){
                    query = query
                        .Include(p => p.PalestrantesEventos)
                        .ThenInclude(pe => pe.Evento);

                }

                query = query.AsNoTracking().OrderBy(p => p.Id);

                return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

                if(includeEventos){
                    query = query
                        .Include(p => p.PalestrantesEventos)
                        .ThenInclude(pe => pe.Evento);

                }

                query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

                return await query.ToArrayAsync();
        }
        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(e => e.RedesSociais);

                if(includeEventos){
                    query = query
                        .Include(e => e.PalestrantesEventos)
                        .ThenInclude(pe => pe.Palestrante);

                }

                query = query.AsNoTracking().OrderBy(e => e.Id)
                            .Where(e => e.Id == palestranteId);

                return await query.FirstOrDefaultAsync();
        }
    }
}