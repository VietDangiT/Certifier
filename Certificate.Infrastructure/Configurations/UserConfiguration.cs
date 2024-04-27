using Certificate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Certificate.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.Property(x => x.pdfFile).HasMaxLength(int.MaxValue);
        }
    }
}
