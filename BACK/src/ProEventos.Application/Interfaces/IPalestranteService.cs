using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Interfaces
{
    public interface IPalestranteService
    {
        Task<Palestrante> AddPalestrante(Palestrante model);
        Task<Palestrante> UpdatePalestrante(int palestranteId, Palestrante model);
        Task<bool> DeletePalestrante(int palestranteId);

        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false);
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false);
    }
}