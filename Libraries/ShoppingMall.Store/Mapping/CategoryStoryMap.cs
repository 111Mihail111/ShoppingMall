using ShoppingMall.Store.Models;
using System.Data.Entity.ModelConfiguration;

namespace ShoppingMall.Store.Mapping
{
    public class CategoryStoreMap : EntityTypeConfiguration<CategoryStore>
    {
        public CategoryStoreMap()
        {
            ToTable("CategoryStore", "dbo");
            HasKey(hk => hk.CategoryStoreId);

            Property(p => p.CategoryStoreId).HasColumnName("idCategoryStore");
            Property(p => p.TypeCategoryId).HasColumnName("idTypeCategory");
            Property(p => p.CategoryName).HasColumnName("nameCategory");
        }
    }
}
