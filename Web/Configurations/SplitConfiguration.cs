using Microsoft.EntityFrameworkCore.Metadata.Builders;
using split_timer_api.Configuration;
using split_timer_api.Entities;

namespace split_timer_api.Configurations
{
    public class SplitConfiguration : BaseConfiguration<Split>
    {
        public override void Configure(EntityTypeBuilder<Split> builder)
        {
            base.Configure(builder);
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Time);
            builder.HasOne(r => r.SplitDefinition).WithMany(rd => rd.Splits).HasForeignKey(fk => fk.SplitDefinitionId);
            builder.HasOne(r => r.Run).WithMany(rd => rd.Splits).HasForeignKey(fk => fk.SplitDefinitionId);
        }
    }
}