using System.Text.Json.Serialization;
using Chayxana.Domain.Entities.Users;
using Chayxana.Domain.Enums;

namespace Chayxana.BLL.DTOs.UserDTOs;

public class UserDTO
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("firstname")]
    public string FirstName { get; set; }
    [JsonPropertyName("lastname")]
    public string LastName { get; set; }
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
    [JsonPropertyName("status")]
    public Status Status { get; set; }
    [JsonPropertyName("user_roles")]
    public ICollection<UserRoleDTO> UserRoles { get; set; }
}