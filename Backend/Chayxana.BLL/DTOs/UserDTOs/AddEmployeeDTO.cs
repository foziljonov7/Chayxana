using System.Text.Json.Serialization;

namespace Chayxana.BLL.DTOs.UserDTOs;

public class AddEmployeeDTO
{
    public long UserId { get; set; }
    [JsonPropertyName("birth_date")]
    public DateTime Birthdate { get; set; }
    [JsonPropertyName("address")]
    public string Address { get; set; }
    [JsonPropertyName("daily_wage")]
    public double DailyWage { get; set; }
    [JsonPropertyName("branch_id")]
    public  long BranchId { get; set; }
}