using ShoppingMall.Store.Models;
using System.Data.Entity.ModelConfiguration;

namespace ShoppingMall.Store.Mapping
{
    public class CategoriesOnlineStoreMap : EntityTypeConfiguration<CategoriesOnlineStore>
    {
        public CategoriesOnlineStoreMap()
        {
            ToTable("_CategoriesOnlineStore", "dbo");

            HasKey(hk => new { hk.OnlineStoreId, hk.CategoryStoreId });
            Property(p => p.OnlineStoreId).HasColumnName("_idOnlineStore");
            Property(p => p.CategoryStoreId).HasColumnName("_idCategoryStore");
        }
    }
}
