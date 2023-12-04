using Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class CouponsMap
    {
        public CouponsMap(EntityTypeBuilder<Coupons> entityBuilder) 
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Code).IsRequired();
            entityBuilder.Property(t => t.DiscountType).IsRequired();
            entityBuilder.Property(t => t.MaxUses).IsRequired();
            entityBuilder.Property(t => t.Uses).IsRequired();
            entityBuilder.Property(t=> t.IsEnabled).IsRequired();
            entityBuilder.Property(t=>t.Value).IsRequired();  
            entityBuilder.Property(t=>t.ExpirationDate).IsRequired();
        }
    }
}
