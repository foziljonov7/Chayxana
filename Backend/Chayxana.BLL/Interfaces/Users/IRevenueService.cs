using Chayxana.BLL.DTOs.UserDTOs;

namespace Chayxana.BLL.Interfaces.Users;

public interface IRevenueService
{
    Task<IEnumerable<RevenueDTO>> RetrieveAllRevenuesAsync(CancellationToken cancellationToken = default);
    Task<RevenueDTO> RetrieveRevenueByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<RevenueDTO> AddRevenueAsync(AddRevenueDTO newRevenue, CancellationToken cancellationToken = default);
    Task<bool> WithHoldingOfRevenueAsync(long revenueId, double amount, DateTime date, CancellationToken cancellationToken = default); 
}