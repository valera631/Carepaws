using CarePaws.Domain.Entities;
using CarePaws.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CarePaws.Infrastructure
{
    public class ApplicationDbContext(IConfiguration configuration) : DbContext 
    {
        private const string DATABASE = "Database";

        public DbSet<Volunteer> Volunteers => Set<Volunteer>();
        public DbSet<SocialNetwork> SocialNetworks => Set<SocialNetwork>();
        public DbSet<PaymentDetails> PaymentDetails => Set<PaymentDetails>();
        public DbSet<Pet> Pets => Set<Pet>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Volunteer>(builder =>
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
            });

            modelBuilder.Entity<Pet>(builder =>
            {
                builder.HasKey(p => p.Id);

                builder.OwnsMany(p => p.PaymentDetails, pd =>
                {
                    pd.WithOwner();
                    pd.Property<string>("Title").IsRequired();
                    pd.Property<string>("Description").IsRequired();
                });

                builder.OwnsMany(p => p.Photos, pp =>
                {
                    pp.WithOwner();  // Указывает, что Pet владеет PetPhoto
                    pp.Property(p => p.FilePath).IsRequired();  // Путь к файлу обязателен
                    pp.Property(p => p.IsMainPhoto);  // Индикатор основного фото
                });
            });
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DATABASE"));
            optionsBuilder.UseSnakeCaseNamingConvention();
            optionsBuilder.UseLoggerFactory(CreateLoggerFactory());
        }
        private ILoggerFactory CreateLoggerFactory() =>
            LoggerFactory.Create(builder => { builder.AddConsole(); });
    }
}
