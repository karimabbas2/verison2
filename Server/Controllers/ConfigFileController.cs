using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigFileController(IExtenstions extenstions, ITrunk trunk) : ControllerBase
    {
        private readonly IExtenstions _extenstions = extenstions;
        private readonly ITrunk _trunk = trunk;

        [HttpGet]
        public async Task<IActionResult> Applaychanges()
        {

            var allExt = await _extenstions.GetAllExtensionConfig();
            var allTrunks = await _trunk.GetAllTrunksConfig();

            string rootPath = "/etc/asterisk";
            string filePath1 = Path.Combine(rootPath, "pjsip_endpoint.conf");
            string filePath2 = Path.Combine(rootPath, "pjsip_auth.conf");
            string filePath3 = Path.Combine(rootPath, "pjsip_aor.conf");
            string filePath4 = Path.Combine(rootPath, "pjsip_identify.conf");
            string filePath5 = Path.Combine(rootPath, "pjsip_registeration.conf");

            List<string> allPaths = [filePath1, filePath2, filePath3, filePath4, filePath5];

            try
            {
                foreach (var path in allPaths)
                {
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }

                    switch (path)
                    {
                        case "/etc/asterisk/pjsip_endpoint.conf":
                            using (StreamWriter outputFile = new(filePath1, false))
                            {
                                foreach (var item in allExt)
                                {
                                    if (item.CallerId_Number is not null)
                                    {
                                        var x = $"{item.F_Name}" + " " + $"{(item.L_Name != null ? $"{item.L_Name}" + " " : "")}" + $"<{item.CallerId_Number}>";
                                        var y = x.Trim();

                                        outputFile.WriteLine(
                                        $"[{item.Ext_Number}]" + "\n" +
                                        "type=endpoint" + "\n" +
                                        "context=internal" + "\n" +
                                        "auth=auth" + $"{item.Ext_Number}" + "\n" +
                                        "outbound_auth=" + $"{item.Ext_Number}" + "\n" +
                                        "aors=" + $"{item.Ext_Number}" + "\n" +
                                        "callerid=" + " " + $"{y}" + "\n" +
                                        "direct_media=" + "" + $"{(item.Enable_DM ? "yes" : "no")}" + "\n" +
                                        "dtmf_mode=" + "" + $"{item.DTMF_Mode?.DTMF_Mode}" + "\n" +
                                        "language=" + "" + $"{item.Language}" + "\n" +
                                        "force_rport=" + "" + $"{(item.Enable_NAT ? "yes" : "no")}" + "\n" +
                                        "rewrite_contact=" + "" + $"{(item.Enable_NAT ? "yes" : "no")}" + "\n" +
                                        "allow=" + "" + $"{item.A_CodecTo}" + "\n"
                                        );
                                    }
                                    else
                                    {
                                        var w = $"{item.F_Name}" + " " + $"{(item.L_Name != null ? $"{item.L_Name}" + " " : "")}" + $"<{item.Ext_Number}>";
                                        var z = w.Trim();

                                        outputFile.WriteLine(
                                         $"[{item.Ext_Number}]" + "\n" +
                                         "type=endpoint" + "\n" +
                                         "context=internal" + "\n" +
                                         "auth=auth" + $"{item.Ext_Number}" + "\n" +
                                         "outbound_auth=" + $"{item.Ext_Number}" + "\n" +
                                         "aors=" + $"{item.Ext_Number}" + "\n" +
                                         "callerid=" + " " + $"{z}" + "\n" +
                                         "direct_media=" + "" + $"{(item.Enable_DM ? "yes" : "no")}" + "\n" +
                                         "dtmf_mode=" + "" + $"{item.DTMF_Mode?.DTMF_Mode}" + "\n" +
                                         "language=" + "" + $"{item.Language}" + "\n" +
                                         "force_rport=" + "" + $"{(item.Enable_NAT ? "yes" : "no")}" + "\n" +
                                         "rewrite_contact=" + "" + $"{(item.Enable_NAT ? "yes" : "no")}" + "\n" +
                                         "allow=" + "" + $"{item.A_CodecTo}" + "\n"
                                         );
                                    }
                                }
                                outputFile.WriteLine(";============ Trunks ==============");

                                foreach (var trunk in allTrunks)
                                {
                                    if (trunk.Type == "peer_trunk")
                                    {
                                        outputFile.WriteLine(
                                        $"[{trunk.Name}]" + "\n" +
                                        "type=endpoint" + "\n" +
                                        "context=" + $"{trunk.Name}" + "\n" +
                                        "aors=" + $"{trunk.Name}" + "\n" +
                                        "allow=" + "" + $"{trunk.A_CodecTo}" + "\n" +
                                        "transport=" + $"{trunk.Transport}" + "\n" +
                                        "outbound_proxy=sip" + $":{trunk.Out_Proxy_Server}" + $":{trunk.Out_Proxy_Port}" + "\n" +
                                        "from_user=" + $"{trunk.From_User ?? ""}" + "\n" +
                                        "from_domain=" + $"{trunk.From_Domain ?? ""}" + "\n"
                                        );
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(
                                        $"[{trunk.Name}]" + "\n" +
                                        "type=endpoint" + "\n" +
                                        "context=" + $"{trunk.Name}" + "\n" +
                                        "outbound_auth=" + $"{trunk.Name}" + "\n" +
                                        "outbound_proxy=sip" + $":{trunk.Out_Proxy_Server}" + $":{trunk.Out_Proxy_Port}" + "\n" +
                                        "aors=" + $"{trunk.Name}" + "\n" +
                                        "allow=" + "" + $"{trunk.A_CodecTo}" + "\n" +
                                        "transport=" + $"{trunk.Transport}" + "\n" +
                                        "from_user=" + $"{trunk.From_User ?? ""}" + "\n" +
                                        "from_domain=" + $"{trunk.From_Domain ?? ""}" + "\n"
                                        );
                                    }
                                }
                            }
                            break;
                        case "/etc/asterisk/pjsip_auth.conf":
                            using (StreamWriter outputFile = new(filePath2, false))
                            {
                                foreach (var item in allExt)
                                {
                                    if (item.AuthId is not null)
                                    {
                                        outputFile.WriteLine(
                                        "[auth" + $"{item.Ext_Number}]" + "\n" +
                                        "type=auth" + "\n" +
                                        "auth_type=userpass" + "\n" +
                                        "password=" + $"{item.SIP_Password}" + "\n" +
                                        "username=" + $"{item.AuthId}" + "\n"
                                        );
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(
                                        "[auth" + $"{item.Ext_Number}]" + "\n" +
                                        "type=auth" + "\n" +
                                        "auth_type=userpass" + "\n" +
                                        "password=" + $"{item.SIP_Password}" + "\n" +
                                        "username=" + $"{item.Ext_Number}" + "\n"
                                        );
                                    }
                                }
                                outputFile.WriteLine(";============ Register Trunks ==============");
                                foreach (var trunk in allTrunks)
                                {
                                    if (trunk.Type == "register_trunk")
                                    {
                                        outputFile.WriteLine(
                                        $"[{trunk.Name}]" + "\n" +
                                        "type=auth" + "\n" +
                                        "username=" + $"{trunk.User_Name}" + "\n" +
                                        "password=" + $"{trunk.Password}" + "\n"
                                        );
                                    }
                                }
                            }
                            break;

                        case "/etc/asterisk/pjsip_aor.conf":
                            using (StreamWriter outputFile = new(filePath3, false))
                            {
                                foreach (var item in allExt)
                                {
                                    outputFile.WriteLine(
                                    $"[{item.Ext_Number}]" + "\n" +
                                    "type=aor" + "\n" +
                                    "max_contacts=" + $"{item.Ext_CC_Registrations}" + "\n" +
                                    (item.Enable_VM ? "mailboxes=" + $"{item.Ext_Number}" + "@default" + "\n" : ";mailboxes=" + $"{item.Ext_Number}" + "@default" + "\n")
                                    );
                                }
                                outputFile.WriteLine(";============ Trunks ==============");

                                foreach (var trunk in allTrunks)
                                {
                                    if (trunk.Type == "peer_trunk")
                                    {
                                        outputFile.WriteLine(
                                        $"[{trunk.Name}]" + "\n" +
                                        "type=aor" + "\n" +
                                        "contact=sip" + $":{trunk.Server_Address}" + $":{trunk.Port}" + "\n" +
                                        "qualify_frequency=" + $"{trunk.KA_Freq}" + "\n"
                                        );
                                    }
                                    else if (trunk.Type == "register_trunk" && trunk.Need_Registration == true)
                                    {
                                        outputFile.WriteLine(
                                        $"[{trunk.Name}]" + "\n" +
                                        "type=aor" + "\n" +
                                        "contact=sip" + $":{trunk.User_Name}" + $"@{trunk.Server_Address}" + $":{trunk.Port}" + "\n" +
                                        "qualify_frequency=" + $"{trunk.KA_Freq}" + "\n"
                                        );
                                    }
                                    else if (trunk.Type == "register_trunk" && trunk.Need_Registration == false)
                                    {
                                        outputFile.WriteLine(
                                        $"[{trunk.Name}]" + "\n" +
                                        "type=aor" + "\n" +
                                        "max_contacts=1" + "\n" +
                                        "qualify_frequency=" + $"{trunk.KA_Freq}" + "\n"
                                        );
                                    }

                                }
                            }

                            break;

                        case "/etc/asterisk/pjsip_identify.conf":
                            using (StreamWriter outputFile = new(filePath4, false))
                            {
                                foreach (var trunk in allTrunks)
                                {
                                    if (trunk.Type == "peer_trunk")
                                    {
                                        outputFile.WriteLine(
                                        $"[{trunk.Name}]" + "\n" +
                                        "type=identify" + "\n" +
                                        "endpoint=" + $"{trunk.Name}" + "\n" +
                                        "match=" + $"{trunk.Server_Address}" + "\n"
                                        );
                                    }

                                }
                            }
                            break;

                        case "/etc/asterisk/pjsip_registeration.conf":
                            using (StreamWriter outputFile = new(filePath5, false))
                            {
                                outputFile.WriteLine(";============ Register Trunks with Need Registeration ==============");
                                foreach (var trunk in allTrunks)
                                {
                                    if (trunk.Type == "register_trunk" && trunk.Need_Registration == true)
                                    {
                                        outputFile.WriteLine(
                                        $"[{trunk.Name}]" + "\n" +
                                        "type=registration" + "\n" +
                                        "line=yes" + "\n" +
                                        "outbound_auth=" + $"{trunk.Name}" + "\n" +
                                        "endpoint=" + $"{trunk.Name}" + "\n" +
                                        "transport=" + $"{trunk.Transport}" + "\n" +
                                        "client_uri=sip" + $":{trunk.User_Name}" + $"@{trunk.Server_Address}" + $":{trunk.Port}" + "\n" +
                                        "server_uri=sip" + $":{trunk.Server_Address}" + $":{trunk.Port}" + "\n"
                                        );
                                    }
                                }
                            }
                            break;

                        default:
                            break;
                    }
                }

                //Talk To asterisk
                // AsteriskCommand.CommandMethod();
                // CommandAfterApplyChanges.CommandMethod();

                return Ok(new { Message = "Done" });
            }
            catch (System.Exception ex)
            {
                // _logger?.LogError("Error : {ErrorMessage}", ex.InnerException?.Message);
                return StatusCode(500, new { Message = "Internal Server Error" });
            }
        }

    }
}