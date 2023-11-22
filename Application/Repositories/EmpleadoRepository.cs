using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleadoRepository
    {
        private readonly ApiPracticeContext _context;
    
        public EmpleadoRepository(ApiPracticeContext context) : base(context)
        {
            _context = context;
        }
    }
}