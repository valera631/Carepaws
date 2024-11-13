using CarePaws.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarePaws.Infrastructure.Configurations
{
    public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
    {
        public void Configure(EntityTypeBuilder<Volunteer> builder)
        {
            builder.HasKey(v => v.Id);
            builder.Property(v => v.FullName).IsRequired();
            builder.Property(v => v.Email).IsRequired();
            builder.Property(v => v.PasswordHash).IsRequired();
            builder.Property(v => v.Description).IsRequired();
            builder.Property(v => v.PhoneNumber).IsRequired();

            // Конфигурация PaymentDetails как owned type
            builder.OwnsMany(v => v.PaymentDetails, pd =>
            {
                pd.WithOwner();
                pd.Property<string>("Title").IsRequired();
                pd.Property<string>("Description").IsRequired();
            });

            // Конфигурация SocialNetworks как owned type
            builder.OwnsMany(v => v.SocialNetworks, sn =>
            {
                sn.WithOwner();
                sn.Property<string>("Name").IsRequired();
                sn.Property(s => s.Url).IsRequired();
            });

            builder.HasMany(v => v.OwnedPets)
                .WithOne()
                .HasForeignKey("VolunteerId")
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
