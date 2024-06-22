using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Dtos.GlobalSetting;
using AppCore.Interfaces;
using AppDomain;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GlobalSettingController(
    IGlobalSetting globalSetting,
    IDTMF dTMF,
    IPrivilege privilege,
    IJitterBuffer jitterBuffer,
    IMapper mapper
    ) : ControllerBase
    {

        private readonly IGlobalSetting _globalSetting = globalSetting;
        private readonly IDTMF _dTMF = dTMF;
        private readonly IPrivilege _privilege = privilege;
        private readonly IJitterBuffer _jitterBuffer = jitterBuffer;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetAllRequierdData()
        {
            try
            {
                var DTMFs = await _dTMF.GetAllAsync();
                var Privileges = await _privilege.GetAllAsync();
                var JitterBuffers = await _jitterBuffer.GetAllAsync();
                return Ok(new { DTMFs, Privileges, JitterBuffers });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { Message = "Internal Server Error" });
            }
        }

        [HttpGet]
        [Route("index")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var Record = await _globalSetting.GetFirstAsync();
                var globalSettingDto = _mapper.Map<GlobalSettingDto>(Record);
                return Ok(globalSettingDto);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { Message = "Internal Server Error" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] GlobalSettingDto dto)
        {
            try
            {
                var Record = await _globalSetting.GetFirstAsync();
                var newRecord = _mapper.Map<GlobalExtenstionDefault>(dto);
                await _globalSetting.UpdateAsync(Record.Id, newRecord);
                return Ok(dto);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { Message = "Internal Server Error" });
            }
        }

    }
}