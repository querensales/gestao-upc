﻿using Microsoft.EntityFrameworkCore;
using Repository.Entity;

namespace Repository;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();

        base.OnConfiguring(optionsBuilder);
    }

    public virtual DbSet<User> User { get; set; }
    public virtual DbSet<Account> Account { get; set; }
    public virtual DbSet<Category> Category { get; set; }
    public virtual DbSet<CreditCard> CreditCard { get; set; }
    public virtual DbSet<Record> Record { get; set; }
    public virtual DbSet<SubCateegory> SubCategory { get; set; }
}
