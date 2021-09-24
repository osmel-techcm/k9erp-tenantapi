using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tenantCore.Entities;

namespace tenantInfrastructure.Data.Configuration
{
    public class ConfigConfig : IEntityTypeConfiguration<Config>
    {
        public void Configure(EntityTypeBuilder<Config> builder)
        {
            builder.ToTable("Config");

            builder.HasKey(k => k.id);

            builder.Property(e => e.propName).IsRequired().HasMaxLength(250);

            builder.Property(e => e.propValue).IsRequired();
        }
    }
}

