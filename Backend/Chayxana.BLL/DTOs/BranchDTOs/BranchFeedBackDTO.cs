using Chayxana.BLL.DTOs.UserDTOs;
using System.Text.Json.Serialization;

namespace Chayxana.BLL.DTOs.BranchDTOs;

public class BranchFeedBackDTO
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("branch_id")]
    public long BranchId { get; set; }
    [JsonPropertyName("branch")]
    public BranchDTO Branch { get; set; }
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    [JsonPropertyName("user")]
    public UserDTO User { get; set; }
    [JsonPropertyName("comment")]
    public string Comment { get; set; }
    [JsonPropertyName("rating")]
    public int Rating { get; set; }
}
