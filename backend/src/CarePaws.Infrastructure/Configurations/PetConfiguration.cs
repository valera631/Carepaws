using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using CarePaws.Domain.Entities;
using CarePaws.Domain.ValueObjects;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        // Настраиваем Photos как JSON
        builder.Property(p => p.Photos)
               .HasConversion(
                   v => JsonConvert.SerializeObject(v),
                   v => JsonConvert.DeserializeObject<List<PetPhoto>>(v) ?? new List<PetPhoto>())
               .HasColumnType("jsonb"); // Это для PostgreSQL, замените на "json" для других СУБД

        builder.Property(p => p.PaymentDetails)
       .HasConversion(
           v => JsonConvert.SerializeObject(v),
           v => JsonConvert.DeserializeObject<List<PaymentDetails>>(v) ?? new List<PaymentDetails>())
       .HasColumnType("jsonb");
    }
}