using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Services.Implementations;
public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;

    public ReservationService(IReservationRepository reservationRepository)
    {
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
        if (existingReservation == null)
        {
            throw new Exception($"Reservation with ID {entity.ReservationID} not found.");
        }

        existingReservation.CustomerID = entity.CustomerID;
        existingReservation.RestaurantID = entity.RestaurantID;
        existingReservation.TableID = entity.TableID;
        existingReservation.ReservationDate = entity.ReservationDate;
        existingReservation.PartySize = entity.PartySize;

        await _reservationRepository.UpdateAsync(existingReservation);

        return existingReservation; 
    }


    public async Task<string> DeleteAsync(Reservation entity)
    {
        var existingOrderItem = await _reservationRepository.GetByIdAsync(entity.ReservationID);
        if (existingOrderItem == null)
        {
            throw new Exception($"Order item with ID {entity.ReservationID} not found.");
        }

        await _reservationRepository.DeleteAsync(existingOrderItem);

        return "Deleted successfully";
    }
}

