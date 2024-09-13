namespace Chayxana.BLL.Commons;

public class CustomException(int code, string message) : Exception(message)
{
    public int Code { get; set; } = code;
}