using Microsoft.EntityFrameworkCore;
using Reservoom.DBContexts;
using Reservoom.DTOs;
using Reservoom.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservoom.Services.ReservationProviders
{
    internal class DatabaseReservationProvider : IReservationProvider
    {
        private readonly ReservoomDBContextFactory _dbContextFactory;

        public DatabaseReservationProvider(ReservoomDBContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            using (ReservoomDBContext context = _dbContextFactory.CreateDBContext())
            {
                IEnumerable<ReservationDTO> reservationDTOs = await context.Reservations.ToListAsync();

                return reservationDTOs.Select(r => ToReservation(r));
            }
        }

        private static Reservation ToReservation(ReservationDTO r)
        {
            return new Reservation
            (
                roomID: new RoomID(r.FloorNumber, r.RoomNumber),
                usernmae: r.Username,
                startDate: r.StartDate,
                endDate: r.EndDate
            );
        }
    }
}
