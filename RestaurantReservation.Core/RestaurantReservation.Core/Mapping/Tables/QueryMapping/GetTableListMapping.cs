using RestaurantReservation.Core.Features.Restaurants.Queries.Results;
using RestaurantReservation.Core.Features.Tables.Queries.Models;
using RestaurantReservation.Core.Features.Tables.Queries.Results;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Mapping.Tables;
public partial class TableProfile
{
    public void GetTableListMapping()
    {
        CreateMap<Table, GetTableListResponse>()
           .ForMember(dest => dest.RestaurantName, opt => opt.MapFrom(src => src.Restaurant.Name));
    }
}
