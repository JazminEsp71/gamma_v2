    using Dapper;
    using Dapper.Contrib.Extensions;
    using Gamma.System.Api.DataAccess.Interfaces;
    using Gamma.System.Api.Repositories.Interfaces;
    using Gamma.System.Core.Entities;

    namespace Gamma.System.Api.Repositories;

    public class ClientesRepository : IClientesRepository
    {
        private readonly IDbContext _dbcontext;

        public ClientesRepository(IDbContext context)
        {
            _dbcontext = context;
        }

        public async Task<Clientes> SaveAsync(Clientes clientes)
        {
            clientes.IdCliente = await _dbcontext.Connection.InsertAsync(clientes);
            return clientes;
        }

        public async Task<Clientes> UpdateAsync(Clientes clientes)
        {
            await _dbcontext.Connection.UpdateAsync(clientes);
            return clientes;
        }

        public async Task<List<Clientes>> GetAllAsync()
        {
            const string sql = "SELECT * FROM Clientes WHERE IsDeleted = 0";
            
            var clientes = await _dbcontext.Connection.QueryAsync<Clientes>(sql);
            
            return clientes.ToList();
        }

        public async Task<bool> DeleteAsync(int idCliente)
        {
            var clientes = await GetById(idCliente);
            if(clientes == null)
                return false;
            
            clientes.IsDeleted = true;
            
            return await _dbcontext.Connection.UpdateAsync(clientes);
        }

        public async Task<Clientes> GetById(int idCliente)
        {
            var clientes = await _dbcontext.Connection.GetAsync<Clientes>(idCliente);
            
            if(clientes == null)
                return null;
            return clientes.IsDeleted == true ? null : clientes;
        }
    }