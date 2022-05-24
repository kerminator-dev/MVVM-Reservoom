using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Reservoom.DBContexts
{
    public class ReservoomDesignTimeDBContextFactory : IDesignTimeDbContextFactory<ReservoomDBContext>
    {
        public ReservoomDBContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder()
                                           .UseSqlite("Data Source=reservoom.db")
                                           .Options;

            return new ReservoomDBContext(options);
        }

    }
}
