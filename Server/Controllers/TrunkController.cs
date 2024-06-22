using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Dtos.Trunk;
using AppCore.Interfaces;
using AppDomain.TrunkEntity;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrunkController(ITrunk trunk, IMapper mapper) : ControllerBase
    {
        private readonly ITrunk _trunk = trunk;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetAllTrunks()
        {
            try
            {
                var trunks = await _trunk.GetAllAsync();
                return Ok(trunks);
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { Message = "Internal Server Error" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrunk([FromBody] TrunkDto dto)
        {
            try
            {
                var newTrunk = _mapper.Map<Trunk>(dto);
                await _trunk.InsertAsync(newTrunk);
                return Ok(new { message = "New Trunk Created Successfully" });
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { Message = "Internal Server Error" });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrunk([FromRoute] int id)
        {
            try
            {
                var trunk = await _trunk.GetAsync(id);
                return Ok(_mapper.Map<TrunkDto>(trunk));
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { Message = "Internal Server Error" });
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateExt([FromBody] UpdateTrunkDto dto)
        {
            try
            {
                var UpdatedTrunk = _mapper.Map<Trunk>(dto);
                await _trunk.UpdateAsync(dto.Id, UpdatedTrunk);
                return Ok(new { message = "Trunk Updated Successfully" });
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { Message = "Internal Server Error" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrunk([FromRoute] int id)
        {
            try
            {
                await _trunk.DeleteAsync(id);
                return Ok(new { Message = "Trunk Deleted Successfully" });
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { Message = "Internal Server Error" });
            }
        }


    }
}