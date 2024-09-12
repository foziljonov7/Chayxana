using System.Text.Json.Serialization;

namespace Chayxana.BLL.DTOs.UserDTOs;

public class RoleDTO
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
}