namespace AvonHMO.API.Models
{
    public class DefaultResponse
    {
        public object Data { get; set; }

        public bool hasError { get; set; }

        public string Message { get; set; }

        public int StatusCode { get; set; }
    }
}
