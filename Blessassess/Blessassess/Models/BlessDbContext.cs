using Microsoft.EntityFrameworkCore;

namespace Blessassess.Models
{
    public class BlessDbContext:DbContext
    {
        public BlessDbContext(DbContextOptions<BlessDbContext> options) : base(options)
        {

        }
        public DbSet<UserInformation> userinformation { get; set; }
        public DbSet<Movie> movie { get; set; }
    }
}
