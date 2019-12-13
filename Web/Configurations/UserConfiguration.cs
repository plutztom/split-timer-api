using Microsoft.EntityFrameworkCore.Metadata.Builders;
using split_timer_api.Configuration;
using split_timer_api.Entities;

namespace split_timer_api.Configurations
{
    public class UserConfiguration : BaseConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name);
            builder.HasMany(u => u.RunDefinitions).WithOne(u => u.User).HasForeignKey(fk => fk.UserId);
        }
    }
}