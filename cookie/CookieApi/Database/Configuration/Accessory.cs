using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookieApi.Database.Configuration;

public class Accessory : IEntityTypeConfiguration<Models.Accessory>
{
    public void Configure(EntityTypeBuilder<Models.Accessory> builder)
    {
        builder.Property(x => x.VotesCount)
            .HasDefaultValue(0);

        builder.HasOne(x => x.Rating)
            .WithOne();
    }
}