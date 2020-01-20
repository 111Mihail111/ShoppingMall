using ShoppingMall.Store.Models;
using System.Data.Entity.ModelConfiguration;

namespace ShoppingMall.Store.Mapping
{
    internal class TypeCategoryStoreMap : EntityTypeConfiguration<TypeCategoryStore>
    {
        public TypeCategoryStoreMap()
        {
            ToTable("TypeCategoryStore", "dbo");
            HasKey(hk => hk.TypeCategoryStoryId);

            Property(p => p.TypeCategoryStoryId).HasColumnName("idTypeCategoryStory");
            Property(p => p.TypeCategoryName).HasColumnName("nameCategory");

            HasMany(x => x.CategoryStores).WithRequired().HasForeignKey(x => x.TypeCategoryId);
        }
    }
}
