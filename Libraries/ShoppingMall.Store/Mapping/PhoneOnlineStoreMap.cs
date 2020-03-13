using ShoppingMall.Store.Models;
using System.Data.Entity.ModelConfiguration;

namespace ShoppingMall.Store.Mapping
{
    public class PhoneOnlineStoreMap : EntityTypeConfiguration<PhonesOnlineStore>
    {
        public PhoneOnlineStoreMap()
        {
            ToTable("_PhoneOnlineStore", "dbo");

            HasKey(hk => new { hk.OnlineStoreId, hk.PhoneStoreId });
            Property(p => p.OnlineStoreId).HasColumnName("_idOnlineStore");
            Property(p => p.PhoneStoreId).HasColumnName("_idPhoneStore");
        }
    }
}
