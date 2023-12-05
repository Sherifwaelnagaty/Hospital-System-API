namespace Algoriza_Project_2023BE83.Models;
public class CouponsModel
{
    public int Id { get; set; }
    public string Code { get; set; }
    public int DiscountType { get; set; }
    public int MaxUses { get; set; }
    public int Uses { get; set; }
    public DateTime ExpirationDate { get; set; }
    public bool IsEnabled { get; set; }    
    public int Value { get; set; }
}