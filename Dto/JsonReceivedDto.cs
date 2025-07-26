namespace API_PPE.Dto
{
    public class JsonReceivedDto
    {
        public string JsonName { get; set; } = string.Empty;
        public string JsonValue { get; set; } = string.Empty;
        public int? IsProcessed { get; set; }  // Optional, default null
    }
}
