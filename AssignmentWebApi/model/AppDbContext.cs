using AssignmentWebApi.Entities;
using AssignmentWebApi.model.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssignmentWebApi.model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<SubCategoryEntity> SubCategories { get; set; }
    }
}
