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
    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleadoRepository
    {
        private readonly ApiPracticeContext _context;
    
        public EmpleadoRepository(ApiPracticeContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empleado>> EmployeeWithBossCode7()
        {
            return await (from emp in _context.Empleados
                         where emp.CodigoJefe == 7
                        select new Empleado 
                        {
                            Nombre = emp.Nombre,
                            Apellido1 = emp.Apellido1,
                            Apellido2 = emp.Apellido2,
                            Email = emp.Email,
                            CodigoJefe = emp.CodigoJefe
                        }
            ).ToListAsync();
        }

        public async Task<Empleado> GetBoss()
        {
            return await (from emp in _context.Empleados
                          where emp.Puesto == "Director General"
                          select new Empleado
                          {
                            Puesto = emp.Puesto,
                            Nombre = emp.Nombre,
                            Apellido1 = emp.Apellido1,
                            Apellido2 = emp.Apellido2,
                            Email = emp.Email
                          }
            ).FirstOrDefaultAsync();
        }
    }
}