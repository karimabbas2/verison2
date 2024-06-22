using AppCore.Dtos.GlobalSetting;
using AppDomain;
using AutoMapper;

namespace AppCore.Mapping.GlobalSettingMapping
{
    public class SettingProfile : Profile
    {
        public SettingProfile()
        {
            //Update
            CreateMap<GlobalSettingDto, GlobalExtenstionDefault>()
            .ForMember(dest => dest.CodecFrom, opt => opt.MapFrom(src => src.CodecFrom != null ? string.Join(",", src.CodecFrom).ToString() : null))
            .ForMember(dest => dest.CodecTo, opt => opt.MapFrom(src => src.CodecTo != null ? string.Join(",", src.CodecTo).ToString() : null));

            //Get
            CreateMap<GlobalExtenstionDefault, GlobalSettingDto>()
            .ForMember(dest => dest.CodecFrom, opt => opt.MapFrom(src => src.CodecFrom.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList()))
            .ForMember(dest => dest.CodecTo, opt => opt.MapFrom(src => src.CodecTo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList()));

        }

    }
}