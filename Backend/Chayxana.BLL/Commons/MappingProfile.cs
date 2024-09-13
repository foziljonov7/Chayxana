using AutoMapper;
using Chayxana.BLL.DTOs.UserDTOs;
using Chayxana.Domain.Entities.Users;

namespace Chayxana.BLL.Commons;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<User, LoginDTO>().ReverseMap();
        CreateMap<User, RegisterDTO>().ReverseMap();
        CreateMap<User, ModifyDTO>().ReverseMap(); 
        CreateMap<Employee, EmployeeDTO>().ReverseMap();
        CreateMap<Employee, AddEmployeeDTO>().ReverseMap();
        CreateMap<Revenue, RevenueDTO>().ReverseMap();
        CreateMap<Revenue, AddRevenueDTO>().ReverseMap();
        CreateMap<Role, RoleDTO>().ReverseMap();
        CreateMap<UserRole, UserRoleDTO>().ReverseMap();
    }
}