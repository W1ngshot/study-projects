using CookieApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookieApi.Database.Configuration;

public class CpuConfiguration : IEntityTypeConfiguration<Cpu>
{
    public void Configure(EntityTypeBuilder<Cpu> builder)
    {
        builder.Property(x => x.Manufacturer)
            .HasColumnName("manufacturer");
    }
}