using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickResponder.Domain;

namespace QuickResponder.Infrastructure.Configurations;

public class ResponderConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.ID);

        builder.Property<string>(e => e.FullName).HasMaxLength(60);
        builder.Property<string>(e => e.Password).HasMaxLength(255);
        builder.Property<string>(e => e.Email).HasMaxLength(320);
        builder.Property<string>(e => e.Phone).HasMaxLength(15);
    }
}