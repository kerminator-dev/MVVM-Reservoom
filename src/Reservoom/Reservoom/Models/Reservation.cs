using System;

namespace Reservoom.Models
{
    public class Reservation
    {
        public RoomID RoomID { get; }
        public string Username { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public TimeSpan Length => EndDate - StartDate;

        public Reservation(RoomID roomID, string usernmae, DateTime startDate, DateTime endDate)
        {
            RoomID = roomID;
            Username = usernmae;
            StartDate = startDate;
            EndDate = endDate;
        }

        internal bool Conflicts(Reservation reservation)
        {
            if (reservation.RoomID != RoomID)
                return true;

            return reservation.StartDate > EndDate;
        }
    }
}
