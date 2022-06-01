using Reservoom.Commands;
using Reservoom.Services;
using Reservoom.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace Reservoom.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private string _username = string.Empty;
        private int _floorNumber;
        private int _roomNumber;
        private DateTime _startDate = new DateTime(DateTime.Now.Year, 1, 1);
        private DateTime _endDate = new DateTime(DateTime.Now.Year, 1, 2);
        private Dictionary<string, List<string>> _propertyNameToErrorsDictionary;

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

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


                ClearErrors(nameof(StartDate));
                ClearErrors(nameof(EndDate));

                if (EndDate < StartDate)
                {
                    AddErrorToProperty(nameof(EndDate), "Дата начала не может быть после даты окончания.");
                }
            }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));

                ClearErrors(nameof(EndDate));

                if (EndDate < StartDate)
                {
                    AddErrorToProperty(nameof(EndDate), "Дата окончания не может быть до даты начала.");
                }
            }
        }

        public ICommand SubmitCommand { get; }

        public ICommand CancelCommand { get; }

        public bool HasErrors => _propertyNameToErrorsDictionary.Any();

        public MakeReservationViewModel(HotelStore hotelStore, NavigationService<ReservationListingViewModel> reservationViewNavigationService)
        {
            _propertyNameToErrorsDictionary = new Dictionary<string, List<string>>();
            SubmitCommand = new MakeReservationCommand(this, hotelStore, reservationViewNavigationService);
            CancelCommand = new NavigateCommand<ReservationListingViewModel>(reservationViewNavigationService);
        }

        private void ClearErrors(string propertyName)
        {
            _propertyNameToErrorsDictionary.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void AddErrorToProperty(string propertyName, string errorMessage)
        {
            if (!_propertyNameToErrorsDictionary.ContainsKey(propertyName))
            {
                _propertyNameToErrorsDictionary.Add(propertyName, new List<string>());
            }

            _propertyNameToErrorsDictionary[propertyName].Add(errorMessage);

            OnErrorsChanged(nameof(propertyName));
        }

        public IEnumerable GetErrors(string? propertyName)
        {
            return _propertyNameToErrorsDictionary.GetValueOrDefault(propertyName, new List<string>());
        }
    }
}
