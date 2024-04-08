using Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models;
public class Coupons
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Code is required.")]
    public string Code { get; set; }

    [Required(ErrorMessage = "Value is required.")]
    public int Value { get; set; }

    [Required(ErrorMessage = "Discount Type is required.")]
    [EnumDataType(typeof(DiscountType))]
    public DiscountType DiscountType { get; set; }

    [Required(ErrorMessage = "Minimum Requests is required.")]
    [Range(0, int.MaxValue)]
    public int MinimumRequiredBookings { get; set; }

    public DateTime ExpirationDate { get; set; }

    [Required(ErrorMessage = "IsActivated is required.")]
    public bool IsEnabled { get; set; }
}