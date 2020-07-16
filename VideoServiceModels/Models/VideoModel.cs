namespace VideoService.Models.Models
{
    public class VideoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int CategoryId { get; set; }
        public string Status { get; set; }
        public bool IsCorrect { get; set; } = false;
    }
}
