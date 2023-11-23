using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPractice.Dtos.AnotherEntities;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.AnotherEntities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiPractice.Controllers;
public class ClienteController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ClienteController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Cliente>>> Get()
    {
        var entity = await _unitOfWork.Clientes.GetAllAsync();
        return _mapper.Map<List<Cliente>>(entity);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Cliente>> Get(int id)
    {
        var entity = await _unitOfWork.Clientes.GetByIdAsync(id);
        if (entity == null)
        {
            return NotFound();
        }
        return _mapper.Map<Cliente>(entity);
    }

    // 1.4.5) 1
    [HttpGet("ClienteYRepresentanteDeVentas")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteYRepresentante>>> ClienteYRepresentanteDeVentas()
    {
        var entity = await _unitOfWork.Clientes.GetClientAndSalesRepresentant();
        return _mapper.Map<List<ClienteYRepresentante>>(entity);
    }

    // 1.4.5) 4
    [HttpGet("ClientesConPagos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClientesConPagos>>> ClientsWithPays()
    {
        var entity = await _unitOfWork.Clientes.GetClientsWithPays();
        return _mapper.Map<List<ClientesConPagos>>(entity);
    }

    // 1.4.5) 5
    [HttpGet("ClientesSinPagos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClientesConPagos>>> ClientsWithoutPays()
    {
        var entity = await _unitOfWork.Clientes.GetClientsWithoutPays();
        return _mapper.Map<List<ClientesConPagos>>(entity);
    }

    // 1.4.5) 10
    [HttpGet("ClienteEntregaTardia")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClientesConPagos>>> ClientsWithoutPays()
    {
        var entity = await _unitOfWork.Clientes.GetClientsWithoutPays();
        return _mapper.Map<List<ClientesConPagos>>(entity);
    }

}
