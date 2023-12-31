using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiPractice.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiPractice.Controllers;

public class OficinaController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public OficinaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Oficina>>> Get()
    {
        var entity = await _unitOfWork.Oficinas.GetAllAsync();
        return _mapper.Map<List<Oficina>>(entity);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Oficina>> Get(string id)
    {
        var entity = await _unitOfWork.Oficinas.GetByIdAsync(id);
        if (entity == null)
        {
            return NotFound();
        }
        return _mapper.Map<Oficina>(entity);
    }

    // 1

    [HttpGet("OfficesAndCities")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<OficinaDto>>> OfficesAndCities()
    {
        var entity = await _unitOfWork.Oficinas.OfficeCodeAndCity();
        return _mapper.Map<List<OficinaDto>>(entity);
    }

    // 2
    [HttpGet("OfficesSpain")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<OficinasDeEspañaDto>>> OfficesSpain()
    {
        var entity = await _unitOfWork.Oficinas.OfficesFromSpain();
        return _mapper.Map<List<OficinasDeEspañaDto>>(entity);
    }
}
