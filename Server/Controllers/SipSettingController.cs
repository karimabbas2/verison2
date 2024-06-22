using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Dtos.SipSetting;
using AppCore.Interfaces;
using AppDomain;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SipSettingController(ISIPSettingInterface sIPSettingInterface,
    ILogger<SipSettingController> logger,
    IMapper mapper) : ControllerBase
    {
        private readonly ISIPSettingInterface _sIPSettingInterface = sIPSettingInterface;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger _logger = logger;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var record = await _sIPSettingInterface.GetFirstAsync();
                return Ok(_mapper.Map<SipSettingDto>(record));
            }
            catch (System.Exception ex)
            {
               return StatusCode(500, new { Message = "Internal Server Error" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] SipSettingDto dto)
        {
            try
            {
                var Record = await _sIPSettingInterface.GetFirstAsync();
                var newRecord = _mapper.Map<SIPSetting>(dto);
                await _sIPSettingInterface.UpdateAsync(Record.Id, newRecord);
                return Ok(dto);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { Message = "Internal Server Error" });
            }
        }

        [HttpGet]
        [Route("ApplaySIPChanges")]
        public async Task<IActionResult> ApplaySIPChanges()
        {

            string rootPath = "/etc/asterisk";
            string filePath = Path.Combine(rootPath, "pjsip_transport.conf");

            try
            {
                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);

                using (StreamWriter outputFile = new(filePath, false))
                {
                    var DefalutSIP = await _sIPSettingInterface.GetFirstAsync();
                    outputFile.WriteLine(
                    "[udp]" + "\n" +
                    "type=transport" + "\n" +
                    "protocol=udp" + "\n" +
                    "bind=0.0.0.0:" + $"{DefalutSIP.UDP_PORT}" + "\n" +
                    "external_signaling_port=" + $"{DefalutSIP.UDP_PORT}" + "\n"
                    );

                    outputFile.WriteLine(
                   "[tcp]" + "\n" +
                   "type=transport" + "\n" +
                   "protocol=tcp" + "\n" +
                   "bind=0.0.0.0:" + $"{DefalutSIP.TCP_PORT}" + "\n" +
                   "external_signaling_port=" + $"{DefalutSIP.TCP_PORT}" + "\n"
                   );

                    outputFile.WriteLine(
                   "[tls]" + "\n" +
                   "type=transport" + "\n" +
                   "protocol=tls" + "\n" +
                   "bind=0.0.0.0:" + $"{DefalutSIP.TLS_PORT}" + "\n" +
                   "cert_file=/etc/asterisk/keys/asterisk.pem" + "\n" +
                   "priv_key_file=/etc/asterisk/keys/asterisk.pem" + "\n" +
                   "method=sslv23" + "\n"
                   );
                }

                return Ok(new { Message = "File Created Successfully" });

            }
            catch (System.Exception ex)
            {
                _logger?.LogError("Error : {ErrorMessage}", ex.InnerException?.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }

        }

        [HttpGet]
        [Route("RebootSystem")]
        public async Task<IActionResult> RebootSystem()
        {
            try
            {
                Process process = new();
                process.StartInfo.FileName = "/bin/bash";
                process.StartInfo.Arguments = "-c \"sudo -S reboot\"";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardInput = true;

                process.Start();
                /// not seucre way , we can change use privillage form suders files
                using (StreamWriter writer = process.StandardInput)
                {
                    if (writer.BaseStream.CanWrite)
                    {
                        writer.WriteLine("fiberme");
                    }
                }
                Console.WriteLine(process.StandardOutput.ReadToEnd());

                if (process.StandardError is not null)
                {
                    Console.WriteLine(process.StandardError.ReadToEnd());
                }
                process.WaitForExit();
                return Ok(new { Message = "Done" });

            }
            catch (System.Exception ex)
            {
                _logger?.LogError("Error : {ErrorMessage}", ex.InnerException?.Message);
                // return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
                return StatusCode(500, new { Message = "Internal Server Error" });
            }

        }
    }
}