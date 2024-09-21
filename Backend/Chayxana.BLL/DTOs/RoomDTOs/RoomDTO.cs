using Chayxana.Domain.Enums;
using System.Text.Json.Serialization;

namespace Chayxana.BLL.DTOs.RoomDTOs;

public class RoomDTO
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("branch_id")]
    public long BranchId { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("price")]
    public double Price { get; set; }
    //public ICollection<Booking> Bookings { get; set; }
    [JsonPropertyName("status")]
    public Status Status { get; set; }
}
