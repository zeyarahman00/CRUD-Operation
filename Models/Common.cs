
namespace LPInfotech.Models
{
    public class Common
    {
    }
    public class ServiceResponse
    {
        public int Status { get; set; }
        public string Message { get; set; } = "";
        public object? Data { get; set; }
    }
}
