using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Chayxana.BLL.Commons;
using Chayxana.BLL.DTOs.UserDTOs;
using Chayxana.BLL.Interfaces.Users;
using Chayxana.Domain.Entities.Users;
using Chayxana.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chayxana.BLL.Services.Users;

public class RevenueService(
    IRepository<Revenue> repository,
    IEmployeeService employeeService,
    IMapper mapper) : IRevenueService
{
    public async Task<RevenueDTO> AddRevenueAsync(AddRevenueDTO newRevenue, CancellationToken cancellationToken = default)
    {
        var existsEmployee = await employeeService.ExistsEmployeeAsync(newRevenue.EmployeeId, cancellationToken);

        if(!existsEmployee)
            throw new CustomException(404, "Employee not found");

        var revenue = mapper.Map<Revenue>(newRevenue);
        await repository.AddAsync(revenue, cancellationToken);
        await repository.SaveAsync(cancellationToken);

        return mapper.Map<RevenueDTO>(revenue);
    }

    public async Task<IEnumerable<RevenueDTO>> RetrieveAllRevenuesAsync(CancellationToken cancellationToken = default)
    {
        var revenueQuery = await repository.SelectAllAsync(null, null, cancellationToken);

        var revenues = await revenueQuery
            .AsNoTracking()
            .ToListAsync();

        if(revenues is null)
            throw new CustomException(404, "No revenues found");

        return mapper.Map<IEnumerable<RevenueDTO>>(revenues);
    }

    public async Task<RevenueDTO> RetrieveRevenueByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var revenue = await repository.SelectAllAsync(x => x.Id == id, null, cancellationToken);

        if(revenue is null)
            throw new CustomException(404, "Revenue not found");

        return mapper.Map<RevenueDTO>(revenue);
    }

    public async Task<bool> WithHoldingOfRevenueAsync(long revenueId, double amount, CancellationToken cancellationToken = default)
    {
        var revenue = await repository.SelectAsync(x => x.Id == revenueId, null, cancellationToken);
        if(revenue is null)
            throw new CustomException(404, "Revenue not found");

        if(revenue.Amount < amount)
            throw new CustomException(400, "Insufficient amount in revenue");

        revenue.Amount -= amount;

        return await repository.SaveAsync(cancellationToken);
    }
}
