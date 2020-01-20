using ShoppingMall.Store.Models;
using System.Data.Entity.ModelConfiguration;

namespace ShoppingMall.Store.Mapping
{
    internal class OnlineStoreMap : EntityTypeConfiguration<OnlineStore>
    {
        public OnlineStoreMap()
        {
            ToTable("OnlineStore", "dbo");
            HasKey(h => h.StoreId);

            Ignore(h => h.Phones);
            Ignore(h => h.Emails);
            Property(p => p.UrlStore).HasColumnName("urlStore");
            Property(p => p.StoreName).HasColumnName("nameStore");
            Property(p => p.LogoStore).HasColumnName("logoStore");
            Property(p => p.Description).HasColumnName("description");
            
        }
    }
}
