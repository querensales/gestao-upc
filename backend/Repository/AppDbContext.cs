using Microsoft.EntityFrameworkCore;
using Repository.Entity;

namespace Repository;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> User { get; set; }
    public DbSet<Account> Account { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<CreditCard> CreditCard { get; set; }
    public DbSet<Record> Record { get; set; }
    public DbSet<SubCateegory> SubCategory { get; set; }
}
