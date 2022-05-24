using Microsoft.EntityFrameworkCore;
using Reservoom.DBContexts;
using Reservoom.DTOs;
using Reservoom.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Reservoom.Services.ReservationConflictValidators
{
    internal class DatabaseReservationConflictValidator : IReservationConflictValidator
    {
        private readonly ReservoomDBContextFactory _dbContextFactory;

        public DatabaseReservationConflictValidator(ReservoomDBContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Reservation?> GetConflictingReservation(Reservation reservation)
        {
            using (ReservoomDBContext context = _dbContextFactory.CreateDBContext())
            {
                ReservationDTO? reservationDTO = await context.Reservations
                    .Where(r => r.FloorNumber == reservation.RoomID.FloorNumber)
                    .Where(r => r.RoomNumber == reservation.RoomID.RoomNumber)
                    .Where(r => r.Username == reservation.Username)
                    .Where(r => r.StartDate < reservation.EndDate)
                    .Where(r => r.EndDate > reservation.StartDate)
                    .FirstOrDefaultAsync();

                if (reservationDTO == null)
                    return null;

                return ToReservation(reservationDTO);
            }
        }

        private Reservation ToReservation(ReservationDTO dto)
        {
            return new Reservation(
                new RoomID(dto.FloorNumber, dto.RoomNumber),
                dto.Username,
                dto.StartDate,
                dto.EndDate
            );
        }
    }
}
