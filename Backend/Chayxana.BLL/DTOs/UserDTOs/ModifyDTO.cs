using System.Text.Json.Serialization;

namespace Chayxana.BLL.DTOs.UserDTOs;

public class ModifyDTO
{
    [JsonPropertyName("firstname")]
    public string FirstName { get; set; }
    [JsonPropertyName("lastname")]
    public string LastName { get; set; }
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }
}