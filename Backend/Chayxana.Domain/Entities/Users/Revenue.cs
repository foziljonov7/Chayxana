namespace Chayxana.Domain.Entities.Users;

public class Revenue : BaseEntity
{
    public required long EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public DateTime Date { get; set; }
    public required double Amount { get; set; }
}