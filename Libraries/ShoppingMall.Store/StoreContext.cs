﻿using ShoppingMall.Store.Mapping;
using ShoppingMall.Store.Models;
using System.Data.Entity;

namespace ShoppingMall.Store
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("DbConnect") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<StoreContext>(null);

            modelBuilder.Configurations.Add(new CategoryStoreMap());
            modelBuilder.Configurations.Add(new TypeCategoryStoreMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new PhoneStoreMap());
            modelBuilder.Configurations.Add(new EmailStoreMap());
            modelBuilder.Configurations.Add(new OnlineStoreMap());
        }

        public DbSet<CategoryStore> CategoryStores { get; set; }
        public DbSet<TypeCategoryStore> TypeCategoryStores { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<PhoneStore> PhoneStores { get; set; }
        public DbSet<EmailStore> EmailStores { get; set; }
        public DbSet<OnlineStore> OnlineStores { get; set; }

    }

}