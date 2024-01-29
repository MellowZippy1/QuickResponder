using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickResponder.Domain;

namespace QuickResponder.Infrastructure.Configurations;

public class ResponderConfiguration : IEntityTypeConfiguration<Responder>
{
    public void Configure(EntityTypeBuilder<Responder> builder)
    {
        builder.HasKey(e => e.ResponderID);

        builder.Property<string>(e => e.FullName).HasMaxLength(60);
        builder.Property<string>(e => e.Password).HasMaxLength(255);
        builder.Property<string>(e => e.Email).HasMaxLength(320);
        builder.Property<string>(e => e.Phone).HasMaxLength(15);

        builder
            .HasMany<Incident>(e => e.PatientHistory)
            .WithOne(e => e.Responder)
            .HasForeignKey(e => e.ResponderID);
    }
}