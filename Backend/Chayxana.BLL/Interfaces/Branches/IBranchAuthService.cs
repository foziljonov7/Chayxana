using Chayxana.Domain.Entities.Branches;

namespace Chayxana.BLL.Interfaces.Branches;

public interface IBranchAuthService
{
    string GetGenerateToken(Branch branch);
}
