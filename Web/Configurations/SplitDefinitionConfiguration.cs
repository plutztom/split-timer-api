using Microsoft.EntityFrameworkCore.Metadata.Builders;
using split_timer_api.Configuration;
using split_timer_api.Entities;

namespace split_timer_api.Configurations
{
    public class SplitDefinitionConfiguration : BaseConfiguration<SplitDefinition>
    {
        public override void Configure(EntityTypeBuilder<SplitDefinition> builder)
        {
            base.Configure(builder);
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name);
            builder.Property(p => p.Order).IsRequired();
            builder.HasOne(r => r.RunDefinition).WithMany(rd => rd.SplitDefinitions).HasForeignKey(fk => fk.RunDefinitionId);
            builder.HasMany(r => r.Splits).WithOne(s => s.SplitDefinition).HasForeignKey(fk => fk.SplitDefinitionId);
        }
    }
}