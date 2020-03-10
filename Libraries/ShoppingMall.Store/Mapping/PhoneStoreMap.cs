using ShoppingMall.Store.Models;
using System.Data.Entity.ModelConfiguration;

namespace ShoppingMall.Store.Mapping
{
    public class PhoneStoreMap : EntityTypeConfiguration<PhoneStore>
    {
        public PhoneStoreMap()
        {
            ToTable("PhoneStore", "dbo");
            HasKey(hs => hs.PhoneStoreId);

            Property(p => p.PhoneStoreId).HasColumnName("idPhone");
            Property(p => p.PhoneStoreName).HasColumnName("name");
        }
    }
}
