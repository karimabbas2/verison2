using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Dtos.Extension;
using AppDomain;
using AutoMapper;

namespace AppCore.Mapping.ExtensionMapping
{
    public class ExtensionProfile : Profile
    {
        public ExtensionProfile()
        {
            //Add
            CreateMap<ExtensionDto, Extenstion>()
            .ForMember(dest => dest.A_CodecFrom, opt => opt.MapFrom(src => src.A_CodecFrom != null ? string.Join(",", src.A_CodecFrom).ToString() : null))
            .ForMember(dest => dest.A_CodecTo, opt => opt.MapFrom(src => src.A_CodecTo != null ? string.Join(",", src.A_CodecTo).ToString() : null));


            //Get
            CreateMap<Extenstion, ExtensionDto>()
            .ForMember(dest => dest.A_CodecFrom, opt => opt.MapFrom(src => src.A_CodecFrom.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList()))
            .ForMember(dest => dest.A_CodecTo, opt => opt.MapFrom(src => src.A_CodecTo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList()));


            //Update
            CreateMap<UpdateExtenionDto, Extenstion>()
            .ForMember(dest => dest.A_CodecFrom, opt => opt.MapFrom(src => src.A_CodecFrom != null ? string.Join(",", src.A_CodecFrom).ToString() : null))
            .ForMember(dest => dest.A_CodecTo, opt => opt.MapFrom(src => src.A_CodecTo != null ? string.Join(",", src.A_CodecTo).ToString() : null));

            //Dtatabel
            CreateMap<Extenstion, ExtensionDataTable>()
            .ForMember(x => x.DTMF_Mode, opt => opt.MapFrom(src => src.DTMF_Mode.DTMF_Mode));
        }
    }
}