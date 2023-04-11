using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Application.Interfaces;
using ProEventos.Domain;
using ProEventos.Persistence.Intefaces;

namespace ProEventos.Application
{
    public class PalestranteService : IPalestranteService
    {
        private readonly IGeralRepository _geralRepo;
        private readonly IPalestranteRepository _palestranteRepo;
        public PalestranteService(IGeralRepository geralRepo, IPalestranteRepository palestranteRepo)
        {
            this._palestranteRepo = palestranteRepo;
            this._geralRepo = geralRepo;
            
        }
        public async Task<Palestrante> AddPalestrante(Palestrante model)
        {
            try
            {
                _geralRepo.Add<Palestrante>(model);
                if (await _geralRepo.SaveChangesAsync())
                {
                    return await _palestranteRepo.GetPalestranteByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Palestrante> UpdatePalestrante(int palestranteId, Palestrante model)
        {
            try
            {
                var palestrante = await _palestranteRepo.GetPalestranteByIdAsync(palestranteId);
                if (palestrante == null) throw new Exception("Palestrante não encontrado para atualizar.");
                
                model.Id = palestrante.Id;

                _geralRepo.Update<Palestrante>(model);
                if(await _geralRepo.SaveChangesAsync())
                {
                    return await _palestranteRepo.GetPalestranteByIdAsync(model.Id);
                } 
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePalestrante(int palestranteId)
        {
            try
            {
                var palestrante = await _palestranteRepo.GetPalestranteByIdAsync(palestranteId);
                if (palestrante == null) throw new Exception("Palestrante não encontrado para deletar.");

                _geralRepo.Delete<Palestrante>(palestrante);
                return await _geralRepo.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            try
            {
                var palestrantes = await _palestranteRepo.GetAllPalestrantesAsync();
                if (palestrantes == null) return null;

                return palestrantes;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            try
            {
                var palestrantes = await _palestranteRepo.GetAllPalestrantesByNomeAsync(nome);
                if (palestrantes == null) return null;

                return palestrantes;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            try
            {
                var palestrante = await _palestranteRepo.GetPalestranteByIdAsync(palestranteId);
                if (palestrante == null) return null;

                return palestrante;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}