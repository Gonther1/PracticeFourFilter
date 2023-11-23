using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPractice.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiPractice.Controllers;

public class EmpleadoController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public EmpleadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Empleado>>> Get()
    {
        var entity = await _unitOfWork.Empleados.GetAllAsync();
        return _mapper.Map<List<Empleado>>(entity);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Empleado>> Get(int id)
    {
        var entity = await _unitOfWork.Empleados.GetByIdAsync(id);
        if (entity == null)
        {
            return NotFound();
        }
        return _mapper.Map<Empleado>(entity);
    }

    // 3
    [HttpGet("EmpleadoJefe7")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EmpleadoIdJefe7>>> EmpleadoJefe7()
    {
        var entity = await _unitOfWork.Empleados.EmployeeWithBossCode7();
        return _mapper.Map<List<EmpleadoIdJefe7>>(entity);
    }

    // 4

    [HttpGet("DirectorGeneral")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmpleadoJefeDto>> DirectorGeneral()
    {
        var entity = await _unitOfWork.Empleados.GetBoss();
        return _mapper.Map<EmpleadoJefeDto>(entity);
    }
}
