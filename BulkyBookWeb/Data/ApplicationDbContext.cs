using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            /*parameters in the constructor are needed
             since we are declaring that is going to receive some options.
            And those options will be passed to the base class which is DbContext

            */
        }

        public DbSet<Category> Categories { get; set; }
    }
}
