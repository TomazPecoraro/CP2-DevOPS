using Sprint3.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Sprint3.Models.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("USERS"); 

            builder.HasKey(p => p.Id); 

            builder.Property(p => p.Id)
                   .HasColumnName("ID"); 

            builder.Property(p => p.Nome)
                   .HasColumnName("NAME") 
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Email)
                   .HasColumnName("EMAIL") 
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}