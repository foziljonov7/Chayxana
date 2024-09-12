using Chayxana.BLL.DTOs.UserDTOs;

namespace Chayxana.BLL.Interfaces.Users;

public interface IRevenueService
{
    Task<IEnumerable<RevenueDTO>> RetrieveAllRevenuesAsync(CancellationToken cancellationToken = default);
    Task<RevenueDTO> RetrieveRevenueByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<RevenueDTO> AddRevenueAsync(AddRevenueDTO newRevenue, CancellationToken cancellationToken = default);
    Task<bool> WithHoldingOfRevenueAsync(long employeeId, DateTime date, double Amount, CancellationToken cancellationToken = default); 
}