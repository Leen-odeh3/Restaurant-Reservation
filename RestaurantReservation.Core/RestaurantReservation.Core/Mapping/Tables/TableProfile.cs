using AutoMapper;
namespace RestaurantReservation.Core.Mapping.Tables;
public partial class TableProfile : Profile
{
    public TableProfile()
    {
      AddTableMapping();
      GetTableListMapping();
      EditTableMapping();
    }
   
}
