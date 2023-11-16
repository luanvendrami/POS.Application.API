﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DrinkOrder>().HasKey(key => key.Id);
            modelBuilder.Entity<FriesOrder>().HasKey(key => key.Id);
            modelBuilder.Entity<GrillOrder>().HasKey(key => key.Id);
            modelBuilder.Entity<SaladOrder>().HasKey(key => key.Id);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<DrinkOrder> DrinkOrder { get; set; }
        public DbSet<FriesOrder> FriesOrder { get; set; }
        public DbSet<GrillOrder> GrillOrder { get; set; }
        public DbSet<SaladOrder> SaladOrder { get; set; }
    }
}
