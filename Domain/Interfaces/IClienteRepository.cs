using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPractice.Dtos.AnotherEntities;
using Domain.Entities;
using Domain.Entities.AnotherEntities;

namespace Domain.Interfaces
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        Task<IEnumerable<ClienteYRepresentante>> GetClientAndSalesRepresentant(); 
        Task<IEnumerable<ClientesConPagos>> GetClientsWithPays(); 
        Task<IEnumerable<ClientesConPagos>> GetClientsWithoutPays(); 
    }
}