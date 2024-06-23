using AutoMapper;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Services.Implementations;
public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IMapper _mapper;

    public ReservationService(IReservationRepository reservationRepository,IMapper mapper)
    {
        _mapper = mapper;
        _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
    }

    public async Task<List<Reservation>> GetAllAsync()
    {
        return await _reservationRepository.GetListAsync();
    }

    public async Task<Reservation> GetByIdAsync(int id)
    {
        return await _reservationRepository.GetByIdAsync(id);
    }

    public async Task<Reservation> AddAsync(Reservation entity)
    {
        return await _reservationRepository.AddAsync(entity);
    }

    public async Task<Reservation> EditAsync(Reservation entity)
    {
        var existingReservation = await _reservationRepository.GetByIdAsync(entity.ReservationID);
        if (existingReservation is null)
        {
            throw new Exception($"Reservation with ID {entity.ReservationID} not found.");
        }

        _mapper.Map(entity, existingReservation);
        await _reservationRepository.UpdateAsync(existingReservation);
        return existingReservation;
    }


    public async Task<string> DeleteAsync(Reservation entity)
    {
        var existingOrderItem = await _reservationRepository.GetByIdAsync(entity.ReservationID);
        if (existingOrderItem is null)
        {
            throw new Exception($"Order item with ID {entity.ReservationID} not found.");
        }

        await _reservationRepository.DeleteAsync(existingOrderItem);

        return "Deleted successfully";
    }
    public async Task<List<Reservation>> GetReservationsByCustomerId(int customerId)
    {
        return await _reservationRepository.GetReservationsByCustomerId(customerId);
    }
}

