using AutoMapper;
using Chayxana.BLL.Commons;
using Chayxana.BLL.DTOs.UserDTOs;
using Chayxana.BLL.Interfaces.Users;
using Chayxana.Domain.Entities.Users;
using Chayxana.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chayxana.BLL.Services.Users;

public class EmployeeService(
    IRepository<Employee> repository,
    IRepository<User> userRepository,
    IMapper mapper) : IEmployeeService
{
    public async Task<EmployeeDTO> AddEmployeeAsync(AddEmployeeDTO newEmployee, CancellationToken cancellationToken = default)
    {
        var userExists = await userRepository.ExistsAsync(newEmployee.UserId, cancellationToken);
        if (!userExists)
            throw new CustomException(404, "User does not exist");

        var employee = mapper.Map<Employee>(newEmployee);
        await repository.AddAsync(employee, cancellationToken);
        await repository.SaveAsync(cancellationToken);

        return mapper.Map<EmployeeDTO>(employee);
    }

    public async Task<bool> ExistsEmployeeAsync(long id, CancellationToken cancellationToken = default)
    {
        var employee = await repository.ExistsAsync(id, cancellationToken);
        if (!employee)
            throw new CustomException(404, "Employee does not exist");
            
        return true;
    }

    public async Task<bool> RemoveEmployeeAsync(long id, CancellationToken cancellationToken = default)
    {
        var employee = await repository.ExistsAsync(id, cancellationToken);
        if (!employee)
            throw new CustomException(404, "Employee does not exist");
        
        await repository.DeleteAsync(id, cancellationToken);
        return await repository.SaveAsync(cancellationToken);
    }

    public async Task<IEnumerable<EmployeeDTO>> RetrieveAllEmployeesAsync(CancellationToken cancellationToken = default)
    {
        var employeeQuery = await repository.SelectAllAsync(null, null, cancellationToken);

        var employees = await employeeQuery
            .AsNoTracking()
            .ToListAsync();

        if(employees is null)
            throw new CustomException(404, "Employees not found");

        return mapper.Map<IEnumerable<EmployeeDTO>>(employees);
    }

    public async Task<EmployeeDTO> RetrieveEmployeeByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var employee = await repository.SelectAsync(x => x.Id == id, null, cancellationToken);

        if(employee is null)
            throw new CustomException(404, "Employee not found");

        return mapper.Map<EmployeeDTO>(employee);
    }

    public async Task<IEnumerable<EmployeeDTO>> RetrieveEmployeesByBranchIdAsync(long branchId, CancellationToken cancellationToken = default)
    {
        var employeeQuery = await repository.SelectAllAsync(null, null, cancellationToken);

        var employees = await employeeQuery
            .Where(x => x.BranchId == branchId)
            .AsNoTracking()
            .ToListAsync();

        if(employees is null)
            throw new CustomException(404, "Employees not found");

        return mapper.Map<IEnumerable<EmployeeDTO>>(employees);
    }
}
