namespace Core.Domain;
public class Appointment{
    public int Id {get; set;}
    public DateTime Date {get; set;}
    public List<string> Time {get; set;}
    public List<string> Days {get; set;}
    public decimal Price {get; set;}
}