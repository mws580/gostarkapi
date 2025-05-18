namespace StarkAPI.Models
{
    public class Joke
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string? Leadin { get; set; }
        public string? Hit { get; set; }
        public string? Category { get; set; }
    }   
}