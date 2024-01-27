using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickResponder.Domain;

namespace QuickResponder.Infrastructure.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(e => e.ID);

        builder.Property<string>(e => e.FullName).HasMaxLength(60);

        builder
            .HasMany<Prescription>(e => e.Prescriptions)
            .WithOne(e => e.Patient)
            .HasForeignKey(e => e.PatientId);
        
        builder
            .HasMany<Allergy>(e => e.Allergies);
    }
}