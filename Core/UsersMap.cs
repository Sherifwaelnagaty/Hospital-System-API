using Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Data
{
    public class UsersMap
    {
        public UsersMap(EntityTypeBuilder<Users> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Email).IsRequired();
            entityBuilder.Property(t => t.FirstName).IsRequired();
            entityBuilder.Property(t => t.LastName).IsRequired();
            entityBuilder.Property(t => t.gender).IsRequired();
            entityBuilder.Property(t=>t.Phone).IsRequired();
            entityBuilder.Property(t => t.UserName).IsRequired();
            entityBuilder.Property(t => t.Password).IsRequired();
            entityBuilder.Property(t =>t.ConfirmPassword).IsRequired();
            entityBuilder.Property(t => t.Dateofbirth).IsRequired();
            entityBuilder.Property(t => t.Image).IsRequired();
        }
    }
}
