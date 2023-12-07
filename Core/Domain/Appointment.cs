using System;
using System.Collections.Generic;

namespace Core.Models;
public class Appointment
{
    public string Id { get; set; }
    public DateTime Date { get; set; }
    public List<string> Time { get; set; }
    public List<string> Days { get; set; }
    public decimal Price { get; set; }
}