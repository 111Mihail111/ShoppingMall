using ShoppingMall.Store.Models;
using System.Data.Entity.ModelConfiguration;

namespace ShoppingMall.Store.Mapping
{
    public class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            ToTable("City", "dbo");
            
            HasKey(hk => hk.Id);
            Property(p => p.Id).HasColumnName("idCity");
            Property(p => p.RegionId).HasColumnName("idRegion");
            Property(p => p.Name).HasColumnName("name");
        }
    }
}
