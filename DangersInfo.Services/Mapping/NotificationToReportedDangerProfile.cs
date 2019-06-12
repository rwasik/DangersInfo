using AutoMapper;
using DangersInfo.Services.Dtos;
using WarsawOpenData.Proxy.Contracts;

namespace DangersInfo.Services.Mapping
{
    public class NotificationToReportedDangerProfile : Profile
    {
        public NotificationToReportedDangerProfile()
        {
            CreateMap<Notification, ReportedDanger>()
                .ForMember(dest => dest.Category, m => m.MapFrom(src => src.Category))
                .ForMember(dest => dest.City, m => m.MapFrom(src => src.City))
                .ForMember(dest => dest.District, m => m.MapFrom(src => src.District))
                .ForMember(dest => dest.NotificationType, m => m.MapFrom(src => src.NotificationType))
                .ForMember(dest => dest.NotificationNumber, m => m.MapFrom(src => src.NotificationNumber))
                .ForMember(dest => dest.Source, m => m.MapFrom(src => src.Source))
                .ForMember(dest => dest.Street, m => m.MapFrom(src => src.Street))
                .ForMember(dest => dest.Subcategory, m => m.MapFrom(src => src.Subcategory))
                .ForMember(dest => dest.CreateDate, m => m.ConvertUsing(new UnixTimeStampFormatter()));
        }
    }
}
