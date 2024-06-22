using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Dtos.SipSetting;
using AppDomain;
using AutoMapper;

namespace AppCore.Mapping.SipSetting
{
    public class SipSettingProfile : Profile
    {
        public SipSettingProfile()
        {
            CreateMap<SIPSetting, SipSettingDto>().ReverseMap();
        }
    }
}