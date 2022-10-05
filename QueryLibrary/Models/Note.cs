namespace QueryLibrary.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public string Label { get; set; }
        public string Text { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
