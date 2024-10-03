using System.Text.Json.Serialization;
using Chayxana.BLL.DTOs.RoomDTOs;
using Chayxana.BLL.DTOs.UserDTOs;
using Chayxana.Domain.Enums;

namespace Chayxana.BLL.DTOs.BranchDTOs;

public class BranchDTO
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("address")]
    public string Address { get; set; }
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }
    [JsonPropertyName("password")]
    public string Pasword { get; set; }
    [JsonPropertyName("start_date")]
    public DateTime StartDate { get; set; }
    [JsonPropertyName("end_date")]
    public DateTime EndDate { get; set; }
    [JsonPropertyName("status")]
    public Status Status { get; set; }
    [JsonPropertyName("type")]
    public BranchType Type { get; set; }
    [JsonPropertyName("employees")]
    public ICollection<EmployeeDTO> Employees { get; set; }
    [JsonPropertyName("rooms")]
    public ICollection<RoomDTO> Rooms { get; set; }
    //public ICollection<BranchFeedback> Feedbacks { get; set; }
}