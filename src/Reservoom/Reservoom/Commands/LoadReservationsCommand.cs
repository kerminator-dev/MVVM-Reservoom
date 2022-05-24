using Reservoom.Models;
using Reservoom.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace Reservoom.Commands
{
    public class LoadReservationsCommand : AsyncCommandBase
    {
        private readonly ReservationListingViewModel _viewModel;
        private readonly Hotel _hotel;

        public LoadReservationsCommand(ReservationListingViewModel viewModel, Hotel hotel)
        {
            _viewModel = viewModel;
            _hotel = hotel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                IEnumerable<Reservation> reservations = await _hotel.GetAllReservations();

                _viewModel.UpdateReservations(reservations);
            }
            catch (Exception ex)
            {
                MessageBox.Show
                (
                    messageBoxText: "Ошибка при загрузке бронирования",
                    caption: "Ошибка",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Error
                );
            }

        }
    }
}
