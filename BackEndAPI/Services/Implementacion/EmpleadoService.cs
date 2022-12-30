using BackEndAPI.Models;
using BackEndAPI.Services.Contrato;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Services.Implementacion
{
    public class EmpleadoService : IEmpleadoService
    {

        private readonly DbempleadoContext _dbContext;

        public EmpleadoService(DbempleadoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Empleado>> GetList()
        {
            try
            {
                List<Empleado> lista = new List<Empleado>();

                lista = await _dbContext.Empleados.Include(emp => emp.IdDepartamentoNavigation).ToListAsync();

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Empleado> Get(int idEmpleado)
        {
            try
            {
                Empleado? encontrado = new Empleado();

                encontrado = await _dbContext.Empleados
                    .Include(emp => emp.IdDepartamentoNavigation)
                    .Where(emp => emp.IdEmpleado == idEmpleado)
                    .FirstOrDefaultAsync();

                return encontrado;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Empleado> Add(Empleado modelo)
        {
            try
            {
                _dbContext.Empleados.Add(modelo);
                await _dbContext.SaveChangesAsync();

                return modelo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Update(Empleado modelo)
        {
            try
            {
                _dbContext.Empleados.Update(modelo);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Delete(Empleado modelo)
        {
            try
            {
                _dbContext.Empleados.Remove(modelo);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
