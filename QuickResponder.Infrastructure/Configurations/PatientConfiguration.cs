using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickResponder.Domain;

namespace QuickResponder.Infrastructure.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(e => e.PatientID);

        builder.Property<string>(e => e.FullName).HasMaxLength(60);
        builder.Property<string>(e => e.Password).HasMaxLength(255);
        builder.Property<string>(e => e.Email).HasMaxLength(320);
        builder.Property<string>(e => e.Phone).HasMaxLength(15);

        builder
            .HasMany<Prescription>(e => e.Prescriptions)
            .WithOne(e => e.Patient)
            .HasForeignKey(e => e.PatientId);

        builder
            .HasMany<MedicalDevice>(e => e.MedicalEquipment);

        builder
            .HasMany<MedicalCondition>(e => e.MedicalConditions);

        builder
            .HasMany<Allergy>(e => e.Allergies);

        builder
            .HasMany<Vaccine>(e => e.VaccineHistory);

        builder
            .HasMany<Incident>(e => e.Incidents)
            .WithOne(e => e.Patient)
            .HasForeignKey(e => e.PatientID);
    }
}