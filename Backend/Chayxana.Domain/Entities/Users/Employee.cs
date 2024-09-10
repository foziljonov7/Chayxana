using Chayxana.Domain.Entities.Branches;

namespace Chayxana.Domain.Entities.Users;

public class Employee : BaseEntity
{
    public required long UserId { get; set; }
    public User User { get; set; }
    public DateTime Birthdate { get; set; }
    public string Address { get; set; }
    public double DailyWage { get; set; }
    public required long BranchId { get; set; }
    public Branch Branch { get; set; }
    public ICollection<Revenue> Revenues { get; set; }
}