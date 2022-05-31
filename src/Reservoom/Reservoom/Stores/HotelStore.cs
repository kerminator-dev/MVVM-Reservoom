using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Stores
{
    public class HotelStore
    {
        private List<Reservation> _reservations;
        private Hotel _hotel;
        private Lazy<Task> _initalizeLazy;

        public IEnumerable<Reservation> Reservations => _reservations;
        public event Action<Reservation> ReservationMade;

        public HotelStore(Hotel hotel)
        {
            _hotel = hotel;
            _initalizeLazy = new Lazy<Task>(Initialize);
            _reservations = new List<Reservation>();
        }

        public async Task MakeReservation(Reservation reservation)
        {
            await _hotel.MakeReservation(reservation);

            _reservations.Add(reservation);

            OnReservationMade(reservation);
        }

        private void OnReservationMade(Reservation reservation)
        {
            ReservationMade?.Invoke(reservation);
        }

        public async Task Load()
        {
            try
            {
                await _initalizeLazy.Value;
            }
            catch (Exception ex)
            {
                _initalizeLazy = new Lazy<Task>(Initialize);
                throw;
            }
        }

        private async Task Initialize()
        {
            IEnumerable<Reservation> reservations = await _hotel.GetAllReservations();

            _reservations.Clear();
            _reservations.AddRange(reservations);
        }
    }
}
