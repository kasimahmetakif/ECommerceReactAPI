namespace ReactAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageSlug { get; set; }
        public bool IsStatus { get; set; }
    }

}
