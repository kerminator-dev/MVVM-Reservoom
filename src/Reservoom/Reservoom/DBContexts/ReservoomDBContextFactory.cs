using Microsoft.EntityFrameworkCore;

namespace Reservoom.DBContexts
{
    public class ReservoomDBContextFactory
    {
        private readonly string _connectionString;

        public ReservoomDBContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public ReservoomDBContext CreateDBContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder()
                                               .UseSqlite(_connectionString)
                                               .Options;

            return new ReservoomDBContext(options);

        }
    }
}
