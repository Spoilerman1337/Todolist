using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.IdentityServer.Infrastructure.Identity;

namespace TodoList.IdentityServer.Infrastructure.Persistence.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(fn => fn.FirstName).HasMaxLength(200);
            builder.Property(fn => fn.LastName).HasMaxLength(200);
        }
    }
}
