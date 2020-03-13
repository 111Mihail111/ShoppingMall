using ShoppingMall.Store.Models;
using System.Data.Entity.ModelConfiguration;

namespace ShoppingMall.Store.Mapping
{
    public class RegionalStoreDataMap : EntityTypeConfiguration<RegionalStoreData>
    {
        public RegionalStoreDataMap()
        {
            ToTable("RegionalStore", "dbo");
            
            HasKey(hk => hk.RegionalDateStoreId);
            Property(p => p.RegionalDateStoreId).HasColumnName("idRegionalStore");
            HasRequired(hr => hr.City).WithMany();
            Property(p => p.RegionalSubdomain).HasColumnName("subdomain");
            
            Ignore(i => i.Addresses);
            Ignore(i => i.PhoneStores);
            Ignore(i => i.EmailStores);
        }
    }
}
