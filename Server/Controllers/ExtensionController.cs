using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Dtos.Extension;
using AppCore.Interfaces;
using AppDomain;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExtensionController(IExtenstions extenstions, IMapper mapper, ILogger<ExtensionController> logger) : ControllerBase
    {
        private readonly IExtenstions _extenstions = extenstions;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger _logger = logger; 
        [HttpGet]
        public async Task<IActionResult> GetAllExtensions()
        {
            try
            {
                var result = await _extenstions.GetAllAsync();
                return Ok(result);

            }
            catch (System.Exception ex)
            {
                _logger?.LogError("Error : {ErrorMessage}", ex.InnerException?.Message);
                return StatusCode(500, new { Message = "Internal Server Error" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateExt([FromBody] ExtensionDto dto)
        {
            try
            {
                var newExt = _mapper.Map<Extenstion>(dto);
                await _extenstions.InsertAsync(newExt);
                return Ok(new { message = "New Extension Created Successfully" });
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { Message = "Internal Server Error" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExt([FromRoute] int id)
        {
            try
            {
                await _extenstions.DeleteAsync(id);
                return Ok(new { Message = "Extension Deleted Successfully" });
            }
            catch (System.Exception)
            {
                // return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
                return StatusCode(500, new { Message = "Internal Server Error" });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExt([FromRoute] int id)
        {
            try
            {
                var ext = await _extenstions.GetAsync(id);
                return Ok(_mapper.Map<ExtensionDto>(ext));
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { Message = "Internal Server Error" });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExt([FromRoute] int id, [FromBody] UpdateExtenionDto dto)
        {
            try
            {
                var UpdatedExt = _mapper.Map<Extenstion>(dto);
                await _extenstions.UpdateAsync(dto.Id, UpdatedExt);
                return Ok(new { message = "Extension Updated Successfully" });
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { Message = "Internal Server Error" });
            }
        }

    }
}