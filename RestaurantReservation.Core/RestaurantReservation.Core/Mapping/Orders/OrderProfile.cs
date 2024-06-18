using AutoMapper;

namespace RestaurantReservation.Core.Mapping.Orders;
public partial class OrderProfile : Profile
{
        public OrderProfile()
        {
            AddOrderMapping();
            EditOrderMapping();
            GetOrderListMapping();
    }
}