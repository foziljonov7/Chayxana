using Chayxana.Domain.Entities.Users;

namespace Chayxana.Domain.Entities.Branches;

public class BranchFeedback : BaseEntity
{
    public long BranchId { get; set; }
    public Branch Branch { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
}
