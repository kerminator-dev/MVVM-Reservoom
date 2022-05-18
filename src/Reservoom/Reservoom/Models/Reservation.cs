﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    public class Reservation
    {
        public RoomID RoomID { get; }
        public string Username { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }

        public TimeSpan Length => EndTime - StartTime;

        public Reservation(RoomID roomID, string usernmae, DateTime startTime, DateTime endTime)
        {
            RoomID = roomID;
            Username = usernmae;
            StartTime = startTime;
            EndTime = endTime;
        }

        internal bool Conflicts(Reservation reservation)
        {
            if (reservation.RoomID != RoomID)
                return true;

            return reservation.StartTime > EndTime;
        }
    }
}
