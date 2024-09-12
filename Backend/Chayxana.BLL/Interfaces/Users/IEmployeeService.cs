using Chayxana.BLL.DTOs.UserDTOs;

namespace Chayxana.BLL.Interfaces.Users;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDTO>> RetrieveAllEmployeesAsync(CancellationToken cancellationToken = default);
    Task<EmployeeDTO> RetrieveEmployeeByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<EmployeeDTO> AddEmployeeAsync(AddEmployeeDTO newEmployee, CancellationToken cancellationToken = default);
    Task<bool> RemoveEmployeeAsync(long id, CancellationToken cancellationToken = default);
    Task<IEnumerable<EmployeeDTO>> RetrieveEmployeesByBranchIdAsync(long branchId, CancellationToken cancellationToken = default);
}