using Microsoft.EntityFrameworkCore.Metadata.Builders;
using split_timer_api.Configuration;
using split_timer_api.Entities;

namespace split_timer_api.Configurations
{
    public class RunDefinitionConfiguration : BaseConfiguration<RunDefinition>
    {
        public override void Configure(EntityTypeBuilder<RunDefinition> builder)
        {
            base.Configure(builder);
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name);
            builder.Property(p => p.Game);
            builder.Property(p => p.Category);
            builder.HasOne(r => r.User).WithMany(rd => rd.RunDefinitions).HasForeignKey(fk => fk.UserId);
            builder.HasMany(r => r.Runs).WithOne(s => s.RunDefinition).HasForeignKey(fk => fk.RunDefinitionId);
            builder.HasMany(r => r.SplitDefinitions).WithOne(s => s.RunDefinition).HasForeignKey(fk => fk.RunDefinitionId);
        }
    }
}