using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserManagement.Presentation.RestApi.Mappings
{
    public class UsersMapping : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(a => a.UserName).IsRequired().HasMaxLength(50);
            builder.Property(a => a.FullName).IsRequired().HasMaxLength(50);
        }
    }
}
