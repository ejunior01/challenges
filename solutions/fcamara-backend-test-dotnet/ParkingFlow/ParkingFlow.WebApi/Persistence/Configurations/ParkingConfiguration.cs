using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ParkingFlow.WebApi.Domain.Parkings;

namespace ParkingFlow.WebApi.Persistence.Configurations;

public class ParkingConfiguration : IEntityTypeConfiguration<Parking>
{
    public void Configure(EntityTypeBuilder<Parking> builder)
    {

        builder.HasKey(v => v.Id);

        builder.Property(v => v.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasMaxLength(100);

        builder.Property(v => v.Phone)
            .IsRequired()
            .HasColumnName("phone")
            .HasMaxLength(15);

        builder.Property(v => v.CapacityCar)
            .IsRequired()
            .HasColumnName("capacity_car")
            .HasDefaultValue(0);

        builder.Property(v => v.CapacityMotorcycle)
             .IsRequired()
             .HasColumnName("capacity_motorcycle")
             .HasDefaultValue(0);

        builder.OwnsOne(v => v.CNPJ, plate =>
        {
            plate.WithOwner();

            plate.Property(p => p.Value)
                .HasColumnName("cnpj")
                .HasMaxLength(14)
                .IsRequired();

            plate.HasIndex(p => p.Value)
                .IsUnique()
                .HasDatabaseName("IX_Parking_CNPJ");
        });

        builder.Property(v => v.Street)
            .IsRequired()
            .HasColumnName("street")
            .HasMaxLength(100);

        builder.Property(v => v.Number)
            .IsRequired()
            .HasColumnName("number")
            .HasMaxLength(10);

        builder.Property(v => v.District)
            .IsRequired()
            .HasColumnName("district")
            .HasMaxLength(100);


        builder.Property(v => v.City)
            .IsRequired()
            .HasColumnName("City")
            .HasMaxLength(100);

        builder.Property(v => v.State)
            .IsRequired()
            .HasColumnName("state")
            .HasMaxLength(100);

        builder.Property(v => v.Postcode)
            .IsRequired()
            .HasColumnName("postcode")
            .HasMaxLength(20);
    }
}

