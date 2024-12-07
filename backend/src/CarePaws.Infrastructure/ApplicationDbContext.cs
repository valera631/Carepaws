using CarePaws.Domain.Entities;
using CarePaws.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CarePaws.Infrastructure
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        private readonly IConfiguration _configuration;
        private const string DATABASE = "Database";


        public DbSet<Volunteer> Volunteers => Set<Volunteer>();
        public DbSet<SocialNetwork> SocialNetworks => Set<SocialNetwork>();
        public DbSet<PaymentDetails> PaymentDetails => Set<PaymentDetails>();
        public DbSet<Pet> Pets => Set<Pet>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            // Применяем конфигурации из сборки
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        private ILoggerFactory CreateLoggerFactory() =>
            LoggerFactory.Create(builder => { builder.AddConsole(); });
    }
}
