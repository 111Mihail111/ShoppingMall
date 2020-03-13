using ShoppingMall.Store.Models;
using System.Data.Entity.ModelConfiguration;

namespace ShoppingMall.Store.Mapping
{
    public class EmailOnlineStoreMap : EntityTypeConfiguration<EmailOnlineStore>
    {
        public EmailOnlineStoreMap()
        {
            ToTable("_EmailOnlineStore", "dbo");

            HasKey(hk => new { hk.OnlineStoreId, hk.EmailStoreId });
            Property(p => p.OnlineStoreId).HasColumnName("_idOnlineStore");
            Property(p => p.EmailStoreId).HasColumnName("_idEmailStore");
        }
    }
}
