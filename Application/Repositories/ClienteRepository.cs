using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPractice.Dtos.AnotherEntities;
using Domain.Entities;
using Domain.Entities.AnotherEntities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repositories
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        private readonly ApiPracticeContext _context;
    
        public ClienteRepository(ApiPracticeContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClienteYRepresentante>> GetClientAndSalesRepresentant()
        {
            return await (from cli in _context.Clientes
                         join emp in _context.Empleados
                         on cli.CodigoEmpleadoRepVentas equals emp.CodigoEmpleado
                         select new ClienteYRepresentante
                         {
                            NombreCliente = cli.NombreCliente,
                            NombreEmpleado = emp.Nombre,
                            ApellidoEmpleado = emp.Apellido1,
                            Puesto = emp.Puesto
                         }
            ).ToListAsync();
        }

        public async Task<IEnumerable<ClientesConPagos>> GetClientsWithPays()
        {
            return await (from cli in _context.Clientes
                         join pays in _context.Pagos
                         on cli.CodigoCliente equals pays.CodigoCliente
                         join emp in _context.Empleados
                         on cli.CodigoEmpleadoRepVentas equals emp.CodigoEmpleado
                         join of in _context.Oficinas
                         on emp.CodigoOficina equals of.CodigoOficina
                          
                        select new ClientesConPagos
                        {
                            CodigoCliente = cli.CodigoCliente,
                            ClientePagoFk = pays.CodigoCliente,
                            NombreCliente = cli.NombreCliente,
                            NombreRepresentante = emp.Nombre,
                            CiudadOficina = of.Ciudad
                        }
            ).ToListAsync();
        }

        public async Task<IEnumerable<ClientesConPagos>> GetClientsWithoutPays()
        {
            return await (from cli in _context.Clientes
                            where !_context.Pagos.Any(p => p.CodigoCliente == cli.CodigoCliente)
                            join emp in _context.Empleados
                            on cli.CodigoEmpleadoRepVentas equals emp.CodigoEmpleado
                            join of in _context.Oficinas
                            on emp.CodigoOficina equals of.CodigoOficina
                        select new ClientesConPagos
                        {
                            CodigoCliente = cli.CodigoCliente,
                            NombreCliente = cli.NombreCliente,
                            NombreRepresentante = emp.Nombre,
                            CiudadOficina = of.Ciudad
                        }
            ).ToListAsync();
        }

        public async Task<IEnumerable<ClientePedidoTarde>> ClientsWithLateDelivery()
        {
            return await (from ped in _context.Pedidos
                         join cli in _context.Clientes
                         on ped.CodigoPedido equals cli.CodigoCliente
                         where ped.FechaEntrega.Year >= ped.FechaEsperada.Year 
                         && ped.FechaEntrega.Month >= ped.FechaEsperada && ped.FechaEntrega.Day > =
                         
                            )
        }
    }
}