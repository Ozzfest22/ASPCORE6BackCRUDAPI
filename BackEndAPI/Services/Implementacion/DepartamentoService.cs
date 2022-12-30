﻿using BackEndAPI.Models;
using BackEndAPI.Services.Contrato;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Services.Implementacion
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly DbempleadoContext _dbContext;

        public DepartamentoService(DbempleadoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Departamento>> GetList()
        {
            try
            {
                List<Departamento> lista = new List<Departamento>();

                lista = await _dbContext.Departamentos.ToListAsync();

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
