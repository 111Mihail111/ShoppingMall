using ShoppingMall.Store.Models;
using System.Data.Entity.ModelConfiguration;

namespace ShoppingMall.Store.Mapping
{
    public class EmailStoreMap : EntityTypeConfiguration<EmailStore>
    {
        public EmailStoreMap()
        {
            ToTable("EmailStore", "dbo");
            HasKey(hk => hk.Id);

            Property(p => p.Id).HasColumnName("idEmail");
            Property(p => p.Name).HasColumnName("name");
        }
    }
}
