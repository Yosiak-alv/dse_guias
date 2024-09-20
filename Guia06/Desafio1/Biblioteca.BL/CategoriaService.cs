using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Biblioteca.BL.Interfaces;
using Biblioteca.DAL.Interfaces;
using Biblioteca.Entities.DTO;
using Biblioteca.Entities.Models;

namespace Biblioteca.BL
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository repository;
        private readonly IMapper mapper;

        public CategoriaService(ICategoriaRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<CategoríasDto>> GetCategoriasAsync()
        {
            try
            {
                var result = await repository.GetCategoriasAsync();
                return mapper.Map<List<Categorías>, List<CategoríasDto>>(result);
            }
            catch (Exception ex)
            {
                return new List<CategoríasDto>();
            }
        }

        public async Task<CategoríasDto> GetCategoriaByIdAsync(int id)
        {
            try
            {
                var result = await repository.GetCategoriaByIdAsync(id);
                return mapper.Map<Categorías, CategoríasDto>(result);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> InsertCategoriaAsync(CategoríasDto categoria)
        {
            try
            {
                var model = mapper.Map<CategoríasDto, Categorías>(categoria);
                return await repository.InsertCategoriaAsync(model);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<CategoríasDto> UpdateCategoriaAsync(CategoríasDto categoria)
        {
            try
            {
                var model = mapper.Map<CategoríasDto, Categorías>(categoria);
                var result = await repository.UpdateCategoriaAsync(model);
                return mapper.Map<Categorías, CategoríasDto>(result);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteCategoriaAsync(int id)
        {
            try
            {
                return await repository.DeleteCategoriaAsync(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
