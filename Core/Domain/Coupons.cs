namespace Core.Domain;
public class Coupons
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public int DiscountType { get; set; }
    public int MaxUses { get; set; }
    public int Uses { get; set; }
    public DateTime ExpirationDate { get; set; }
    public bool IsEnabled { get; set; }
    public int Value { get; set; }
}