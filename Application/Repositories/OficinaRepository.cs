using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repositories
{
    public class OficinaRepository : GenericRepositoryStr<Oficina>, IOficinaRepository
    {
        private readonly ApiPracticeContext _context;
    
        public OficinaRepository(ApiPracticeContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Oficina>> OfficeCodeAndCity()
        {
            return await (from cli in _context.Oficinas
                         select new Oficina 
                         {
                            CodigoOficina = cli.CodigoOficina,
                            Ciudad = cli.Ciudad
                         }
            ).ToListAsync();
        }
    }
}