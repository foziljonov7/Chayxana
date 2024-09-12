using System.Text.Json.Serialization;

namespace Chayxana.BLL.DTOs.UserDTOs;

public class UserRoleDTO
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    [JsonPropertyName("role_id")]
    public long RoleId { get; set; }
}