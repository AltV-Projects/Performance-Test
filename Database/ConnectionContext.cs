using Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class ConnectionContext : DbContext
    {
        public DbSet<User> User { get; set; } = default!;
        private static string GetConnectionString()
        {
            Config SQLConfig = new Config();
            return $"server={SQLConfig.Host};" +
                $"port={SQLConfig.Port};" +
                $"database={SQLConfig.Database};" +
                $"user={SQLConfig.Username};" +
                $"password={SQLConfig.Password}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ServerVersion sv = ServerVersion.AutoDetect(GetConnectionString());
            optionsBuilder.UseMySql(GetConnectionString(), sv);
        }
    }
}
