using Microsoft.EntityFrameworkCore.Metadata.Builders;
using split_timer_api.Configuration;
using split_timer_api.Entities;

namespace split_timer_api.Configurations
{
    public class RunConfiguration : BaseConfiguration<Run>
    {
        public override void Configure(EntityTypeBuilder<Run> builder)
        {
            base.Configure(builder);
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.TotalTime);
            builder.HasOne(r => r.RunDefinition).WithMany(rd => rd.Runs).HasForeignKey(fk => fk.RunDefinitionId);
            builder.HasMany(r => r.Splits).WithOne(s => s.Run).HasForeignKey(fk => fk.RunId);
        }
    }
}