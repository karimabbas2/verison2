using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Dtos.Trunk;
using AppDomain.TrunkEntity;
using AutoMapper;

namespace AppCore.Mapping.TrunkMapping
{
    public class TrunkProfile : Profile
    {
        public TrunkProfile()
        {
            //Add
            CreateMap<TrunkDto, Trunk>()
            .ForMember(dest => dest.A_CodecFrom, opt => opt.MapFrom(src => src.A_CodecFrom != null ? string.Join(",", src.A_CodecFrom).ToString() : null))
            .ForMember(dest => dest.A_CodecTo, opt => opt.MapFrom(src => src.A_CodecTo != null ? string.Join(",", src.A_CodecTo).ToString() : null));

            //Get
            CreateMap<Trunk, TrunkDto>()
            .ForMember(dest => dest.A_CodecFrom, opt => opt.MapFrom(src => src.A_CodecFrom.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList()))
            .ForMember(dest => dest.A_CodecTo, opt => opt.MapFrom(src => src.A_CodecTo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList()));

            //Update
            CreateMap<TrunkDto, Trunk>()
            .ForMember(dest => dest.A_CodecFrom, opt => opt.MapFrom(src => src.A_CodecFrom != null ? string.Join(",", src.A_CodecFrom).ToString() : null))
            .ForMember(dest => dest.A_CodecTo, opt => opt.MapFrom(src => src.A_CodecTo != null ? string.Join(",", src.A_CodecTo).ToString() : null));
        }

    }
}