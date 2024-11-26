using FirstEmployeeApi.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstEmployeeApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee_data> Employee_data { get; set; }


    }
}
