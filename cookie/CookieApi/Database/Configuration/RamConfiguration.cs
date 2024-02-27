using CookieApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookieApi.Database.Configuration;

public class RamConfiguration : IEntityTypeConfiguration<Ram>
{
    public void Configure(EntityTypeBuilder<Ram> builder)
    {
        builder.Property(x => x.Manufacturer)
            .HasColumnName("manufacturer");
    }
}