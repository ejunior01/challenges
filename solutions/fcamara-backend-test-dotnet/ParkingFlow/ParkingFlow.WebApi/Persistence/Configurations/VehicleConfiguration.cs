using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingFlow.WebApi.Domain.Vehicles;

namespace ParkingFlow.WebApi.Persistence.Configurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(v => v.Id);

        builder.Property(v => v.Brand)
            .IsRequired()
            .HasColumnName("brand")
            .HasMaxLength(50);

        builder.Property(v => v.Model)
            .IsRequired()
            .HasColumnName("model")
            .HasMaxLength(50);

        builder.Property(v => v.Color)
            .IsRequired()
            .HasColumnName("color")
            .HasMaxLength(50);

        builder.Property(v => v.Type)
            .HasConversion<string>()
            .HasColumnName("type")
            .IsRequired();

        builder.OwnsOne(v => v.Plate, plate =>
        {
            plate.WithOwner();

            plate.Property(p => p.Value)
                .HasColumnName("plate")
                .HasMaxLength(10)
                .IsRequired();

            plate.HasIndex(p => p.Value)
                .IsUnique()
                .HasDatabaseName("IX_Vehicle_Plate");
        });
    }
}