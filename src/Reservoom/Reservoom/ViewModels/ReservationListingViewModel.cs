using Reservoom.Commands;
using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Reservoom.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ReservationViewModel> _reservations;

        public IEnumerable<ReservationViewModel> Reservations => _reservations;
        public ICommand MakeReservationCommand { get; }

        public ReservationListingViewModel()
        {
            MakeReservationCommand = new NavigateCommand();

            _reservations = new ObservableCollection<ReservationViewModel>();
            _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(1, 2), "John", DateTime.Now.AddDays(-1), DateTime.Now)));
            _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(1, 4), "Mike", DateTime.Now.AddDays(-1), DateTime.Now)));
        }
    }
}
