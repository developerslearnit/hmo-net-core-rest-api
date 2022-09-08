using Newtonsoft.Json;

namespace AvonHMO.API.Models
{
    public class ErrorViewModel
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
