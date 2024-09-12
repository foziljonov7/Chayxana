using System.Text.Json.Serialization;

namespace Chayxana.BLL.DTOs.UserDTOs;
public class RevenueDTO
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("employee_id")]
    public long EmployeeId { get; set; }
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }
    [JsonPropertyName("amount")]
    public double Amount { get; set; }
}