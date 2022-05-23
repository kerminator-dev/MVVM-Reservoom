using Reservoom.Exceptions;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.ViewModels;
using System.Windows;

namespace Reservoom.Commands
{
    public class MakeReservationCommand : CommandBase
    {
        private readonly Hotel _hotel;
        private readonly MakeReservationViewModel _makeReservationViewModel;
        private readonly NavigationService _reservationViewNavigationService;

        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel,
                                      Hotel hotel,
                                      NavigationService reservationViewNavigationService)
        {
            _makeReservationViewModel = makeReservationViewModel;
            _hotel = hotel;

            _makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _reservationViewNavigationService = reservationViewNavigationService;
        }

        private void OnViewModelPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeReservationViewModel.Username))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_makeReservationViewModel.Username) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            var reservation = new Reservation
            (
                roomID: new RoomID
                (
                    floorNumber: _makeReservationViewModel.FloorNumber,
                    roomNumber: _makeReservationViewModel.RoomNumber
                ),
                usernmae: _makeReservationViewModel.Username,
                startDate: _makeReservationViewModel.StartDate,
                endDate: _makeReservationViewModel.EndDate
            );

            try
            {
                _hotel.MakeReservation(reservation);

                MessageBox.Show
                (
                    messageBoxText: "Бронирование выполнено успешно!",
                    caption: "Уведомление",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Information
                );

                _reservationViewNavigationService.Navigate();
            }
            catch (ReservationConflictException)
            {
                MessageBox.Show
                (
                    messageBoxText: "Неверно указаны данные!",
                    caption: "Ошибка",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Error
                );
            }

        }
    }
}
