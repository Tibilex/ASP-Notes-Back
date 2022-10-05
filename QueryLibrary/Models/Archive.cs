namespace QueryLibrary.Models
{
    public class Archive
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public string Label { get; set; }
        public string Text { get; set; }
        public DateTime AddToArchive { get; set; }
    }
}
