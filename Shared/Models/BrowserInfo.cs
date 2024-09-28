namespace Shared.Models
{
    public class BrowserInfo
    {
        public string BrowserName { get; set; } = string.Empty;
        public string OS { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public double? Latitude { get; set; } 
        public double? Longitude { get; set; }
        public string RedirectedTo { get; set; } = string.Empty;
        public string RedirectedFrom { get; set; } = string.Empty;
    }
}
