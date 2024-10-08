using AutoMapper;
using Chayxana.BLL.Commons;
using Chayxana.BLL.DTOs.BranchDTOs;
using Chayxana.BLL.Interfaces.Branches;
using Chayxana.Domain.Entities.Branches;
using Chayxana.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Chayxana.BLL.Services.Branches;

public class BranchFeedBackService(
    IRepository<BranchFeedback> repository,
    IMapper mapper) : IBranchFeedbackService
{
    public async Task<bool> AddFeedBackAsync(AddBranchFeedBackDTO newFeedBack, CancellationToken cancellationToken = default)
    {
        try
        {
            var mapped = mapper.Map<BranchFeedback>(newFeedBack);

            await repository.AddAsync(mapped, cancellationToken);
            await repository.SaveAsync(cancellationToken);

            return true;
        }
        catch(Exception ex)
        {
            throw new CustomException(404, $"Invalid operation, {ex.Message}");
        }
    }

    public async Task<bool> DeleteFeedBackAsync(long id, long branchId, CancellationToken cancellationToken = default)
    {
        var feedbackExits = await repository.ExistsAsync(id, cancellationToken);

        if(!feedbackExits)
            return false;

        await repository.DeleteAsync(id, cancellationToken);
        await repository.SaveAsync(cancellationToken);

        return true;
    }

    public async Task<IEnumerable<BranchFeedBackDTO>> RetrieveAllFeedBackAsync(CancellationToken cancellationToken = default)
    {
        var feedbackQuery = await repository.SelectAllAsync(null, null, cancellationToken);

        var feedbacks = feedbackQuery
            .AsNoTracking()
            .ToListAsync();

        return mapper.Map<IEnumerable<BranchFeedBackDTO>>(feedbacks);
    }

    public async Task<BranchFeedBackDTO> RetrieveFeedBackAsync(long id, CancellationToken cancellationToken = default)
    {
        var feedback = await repository.SelectAsync(x => x.Id == id, null, cancellationToken);

        if (feedback is null)
            throw new CustomException(404, "Branch not found");

        return mapper.Map<BranchFeedBackDTO>(feedback);
    }
}
