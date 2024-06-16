using AutoMapper;
using RestaurantReservation.Core.Features.Tables.Commands.Models;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Mapping.Tables;
public partial class TableProfile : Profile
{
    public void AddTableMapping()
    {
        CreateMap<AddTableCommand, Table>()
           .ForMember(dest => dest.RestaurantID, opt => opt.MapFrom(src => src.RestaurantID));
    }
}
