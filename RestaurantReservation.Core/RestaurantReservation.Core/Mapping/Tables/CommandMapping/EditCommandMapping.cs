using AutoMapper;
using RestaurantReservation.Core.Features.Tables.Commands.Models;
using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Core.Mapping.Tables;
public partial class TableProfile : Profile
{
    public void EditTableMapping()
        {
        CreateMap<EditTableCommand, Table>()
     .ForMember(dest => dest.TableID, opt => opt.MapFrom(src => src.TableID))
     .ForMember(dest => dest.RestaurantID, opt => opt.MapFrom(src => src.RestaurantID))
     .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity));

    }
}

