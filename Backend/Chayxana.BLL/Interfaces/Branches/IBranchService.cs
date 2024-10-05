using Chayxana.BLL.DTOs.BranchDTOs;
using Chayxana.BLL.DTOs.UserDTOs;

namespace Chayxana.BLL.Interfaces.Branches;

public interface IBranchService
{
    Task<IEnumerable<BranchDTO>> RetrieveAllBranchesAsync(CancellationToken cancellationToken = default);
    Task<BranchDTO> RetrieveBranchAsync(long id, CancellationToken cancellationToken = default);
    Task<string> LoginBranchAsync(LoginBranchDTO login, CancellationToken cancellation = default);
    Task<BranchDTO> AddBranchAsync(AddBranchDTO newBranch, CancellationToken cancellationToken = default);
    Task<bool> RemoveBranchAsync(long id, CancellationToken cancellationToken = default);
    Task<BranchDTO> ModifyBranchAsync(long id, ModifyBranchDTO branch, CancellationToken cancellationToken = default);
    Task<IEnumerable<EmployeeDTO>> RetrieveEmployeesByBranchIdAsync(long id, CancellationToken cancellationToken = default);
    //Task<IEnumerable<RoomDTO>> RetrieveRoomsByBranchIdAsync(long id, CancellationToken cancellationToken = default);
}