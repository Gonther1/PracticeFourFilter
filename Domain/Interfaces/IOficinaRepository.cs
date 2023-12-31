using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOficinaRepository : IGenericRepositoryStr<Oficina>
    {
        Task<IEnumerable<Oficina>> OfficeCodeAndCity();
        Task<IEnumerable<Oficina>> OfficesFromSpain();
    }
}