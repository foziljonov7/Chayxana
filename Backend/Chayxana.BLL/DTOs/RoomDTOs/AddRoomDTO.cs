using System.Text.Json.Serialization;

namespace Chayxana.BLL.DTOs.RoomDTOs;

public class AddRoomDTO
{
    [JsonPropertyName("branch_id")]
    public long BranchId { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("price")]
    public double Price { get; set; }
}
