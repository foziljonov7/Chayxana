using System.Text.Json.Serialization;

namespace Chayxana.BLL.DTOs.BranchDTOs;

public class AddBranchFeedBackDTO
{
    [JsonPropertyName("branch_id")]
    public long BranchId { get; set; }
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    [JsonPropertyName("comment")]
    public string Comment { get; set; }
    [JsonPropertyName("rating")]
    public int Rating { get; set; }
}
