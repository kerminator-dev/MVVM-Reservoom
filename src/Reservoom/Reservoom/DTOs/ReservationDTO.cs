﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Reservoom.DTOs
{
    /// <summary>
    /// Data Transfer Object
    /// </summary>
    public class ReservationDTO
    {
        [Key]
        public Guid Id { get; set; }
        public int FloorNumber { get; set; }
        public int RoomNumber { get; set; }
        public string Username { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
