using Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models;
public class Coupons
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    public string Code { get; set; }
    public DiscountType DiscountType { get; set; }
    public int MaxUses { get; set; }
    public int Uses { get; set; }
    public DateTime ExpirationDate { get; set; }
    public bool IsEnabled { get; set; }
    public string Value { get; set; }

}