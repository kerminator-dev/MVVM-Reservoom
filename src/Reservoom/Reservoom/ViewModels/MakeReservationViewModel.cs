using Reservoom.Commands;
using Reservoom.Models;
using System;
using System.Windows.Input;

namespace Reservoom.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase
    {
        private string _username = string.Empty;
        private int _floorNumber;
        private int _roomNumber;
        private DateTime _startDate = new DateTime(DateTime.Now.Year, 1, 1);
        private DateTime _endDate = new DateTime(DateTime.Now.Year, 1, 2);

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                base.OnPropertyChanged(nameof(Username));
            }
        }

        public int FloorNumber
        {
            get => _floorNumber;
            set
            {
                _floorNumber = value;
                base.OnPropertyChanged(nameof(FloorNumber));
            }
        }

        public int RoomNumber
        {
            get => _roomNumber;
            set
            {
                _roomNumber = value;
                base.OnPropertyChanged(nameof(RoomNumber));
            }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        public ICommand SubmitCommand { get; }

        public ICommand CancelCommand { get; }

        public MakeReservationViewModel(Hotel hotel)
        {
            SubmitCommand = new MakeReservationCommand(this, hotel);
            CancelCommand = new CancelMakeReservationCommand();
        }
    }
}
