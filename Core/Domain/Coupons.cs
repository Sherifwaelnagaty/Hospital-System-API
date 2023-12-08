using System;

namespace Core.Models;
public class Coupons
{
    public String Id { get; set; }
    public string Code { get; set; }
    public string DiscountType { get; set; }
    public int MaxUses { get; set; }
    public int Uses { get; set; }
    public DateTime ExpirationDate { get; set; }
    public bool IsEnabled { get; set; }
    public string Value { get; set; }

}