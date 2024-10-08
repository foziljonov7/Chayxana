using Chayxana.BLL.DTOs.BranchDTOs;

namespace Chayxana.BLL.Interfaces.Branches;

public interface IBranchFeedbackService
{
    Task<IEnumerable<BranchFeedBackDTO>> RetrieveAllFeedBackAsync(CancellationToken cancellationToken = default);
    Task<bool> AddFeedBackAsync(AddBranchFeedBackDTO newFeedBack, CancellationToken cancellationToken = default);
    Task<bool> DeleteFeedBackAsync(long id, long branchId, CancellationToken cancellationToken = default);
    Task<BranchFeedBackDTO> RetrieveFeedBackAsync(long id, CancellationToken cancellationToken = default);
}
