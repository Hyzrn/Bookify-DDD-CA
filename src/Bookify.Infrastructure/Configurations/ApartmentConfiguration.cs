using Bookify.Domain.Apartments;
using Bookify.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Infrastructure.Configurations;

internal sealed class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> builder)
    {
        builder.ToTable("apartments");

        builder.HasKey(x => x.Id);
        
        builder.OwnsOne(c => c.Address);

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .HasConversion(
                c => c.Value, 
                value => new Name(value)
            );
        
        builder.Property(x => x.Description)
            .HasMaxLength(2000)
            .HasConversion(
                c => c.Value, 
                value => new Description(value)
            );

        builder.OwnsOne(c => c.Price, priceBuilder =>
        {
            priceBuilder.Property(m => m.Currency)
                .HasConversion(
                    cc => cc.Code, 
                    code => Currency.FromCode(code)
                );
        });
        
        builder.OwnsOne(c => c.CleaningFee, priceBuilder =>
        {
            priceBuilder.Property(m => m.Currency)
                .HasConversion(
                    cc => cc.Code, 
                    code => Currency.FromCode(code)
                );
        });

        builder.Property<uint>("Version").IsRowVersion();
    }
}