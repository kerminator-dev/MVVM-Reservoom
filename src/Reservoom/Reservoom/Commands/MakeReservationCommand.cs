using Reservoom.Exceptions;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.Stores;
using Reservoom.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Reservoom.Commands
{
    public class MakeReservationCommand : AsyncCommandBase
    {
        private readonly HotelStore _hotelStore;
        private readonly MakeReservationViewModel _makeReservationViewModel;
        private readonly NavigationService<ReservationListingViewModel> _reservationViewNavigationService;

        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel,
                                      HotelStore hotelStore,
                                      NavigationService<ReservationListingViewModel> reservationViewNavigationService)
        {
            _makeReservationViewModel = makeReservationViewModel;
            _hotelStore = hotelStore;

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

        public async override Task ExecuteAsync(object? parameter)
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
                await _hotelStore.MakeReservation(reservation);

                MessageBox.Show
                (
                    messageBoxText: "Бронирование выполнено успешно!",
                    caption: "Уведомление",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Information
                );

                // _reservationViewNavigationService.Navigate();
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
            catch (Exception ex)
            {
                MessageBox.Show
                (
                    messageBoxText: "Ошибка при создании бронирования!",
                    caption: "Ошибка",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Error
                );
            }

        }
    }
}
