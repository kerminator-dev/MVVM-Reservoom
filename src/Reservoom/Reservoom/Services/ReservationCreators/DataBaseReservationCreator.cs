using Reservoom.DBContexts;
using Reservoom.DTOs;
using Reservoom.Models;
using System.Threading.Tasks;

namespace Reservoom.Services.ReservationCreators
{
    public class DataBaseReservationCreator : IReservationCreator
    {
        private readonly ReservoomDBContextFactory _dbContextFactory;

        public DataBaseReservationCreator(ReservoomDBContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateReservation(Reservation reservation)
        {
            using (ReservoomDBContext context = _dbContextFactory.CreateDBContext())
            {
                ReservationDTO reservationDTO = ToReservationDTO(reservation);

                context.Reservations.Add(reservationDTO);
                await context.SaveChangesAsync();
            }
        }

        private ReservationDTO ToReservationDTO(Reservation reservation)
        {
            return new ReservationDTO()
            {
                FloorNumber = reservation.RoomID?.FloorNumber ?? 0,
                RoomNumber = reservation.RoomID?.RoomNumber ?? 0,
                Username = reservation.Username,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
            };
        }
    }
}
