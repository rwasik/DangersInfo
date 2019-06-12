using System.Collections.Generic;
using AutoMapper;
using DangersInfo.Services.Dtos;
using DangersInfoApp.ViewModels;

namespace DangersInfoApp.Mapping
{
    public class ReportedDangersToViewModelProfile : Profile
    {
        public ReportedDangersToViewModelProfile()
        {
            CreateMap<IEnumerable<ReportedDanger>, DangersViewModel>()
                .ForMember(dest => dest.ReportedDangers, m => m.MapFrom(src => src));

            CreateMap<ReportedDanger, ReportedDangerViewModel>()
                .ForMember(dest => dest.Category, m => m.MapFrom(src => src.Category))
                .ForMember(dest => dest.City, m => m.MapFrom(src => src.City))
                .ForMember(dest => dest.District, m => m.MapFrom(src => src.District))
                .ForMember(dest => dest.NotificationType, m => m.MapFrom(src => src.NotificationType))
                .ForMember(dest => dest.NotificationNumber, m => m.MapFrom(src => src.NotificationNumber))
                .ForMember(dest => dest.Source, m => m.MapFrom(src => src.Source))
                .ForMember(dest => dest.Street, m => m.MapFrom(src => src.Street))
                .ForMember(dest => dest.Subcategory, m => m.MapFrom(src => src.Subcategory))
                .ForMember(dest => dest.CreateDate, m => m.MapFrom(src => src.CreateDate.ToShortDateString()));
        }
    }
}
