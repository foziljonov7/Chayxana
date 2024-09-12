using System.Text.Json.Serialization;

namespace Chayxana.BLL.DTOs.UserDTOs;

public class LoginDTO
{
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }
}