using Microsoft.EntityFrameworkCore;
using Reservoom.DTOs;

namespace Reservoom.DBContexts
{
    public class ReservoomDBContext : DbContext
    {
        public ReservoomDBContext(DbContextOptions options) : base(options) { }

        public DbSet<ReservationDTO> Reservations { get; set; }
    }
}
