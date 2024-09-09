namespace Chayxana.Domain.Entities.Users;

public class Employee : BaseEntity
{
    public long UserId { get; set; }
    public User User { get; set; }
    public DateTime Birthdate { get; set; }
    public string Address { get; set; }
    public double DailyWage { get; set; }
    public double Revenues { get; set; }
}