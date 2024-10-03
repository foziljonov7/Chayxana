using Chayxana.Domain.Enums;
using System.Text.Json.Serialization;

namespace Chayxana.BLL.DTOs.BranchDTOs;

public class ModifyBranchDTO
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("address")]
    public string Address { get; set; }
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }
    [JsonPropertyName("type")]
    public BranchType Type { get; set; }
}