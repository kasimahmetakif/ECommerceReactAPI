namespace ReactAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public bool IsStatus { get; set; }
        public DateTime Date { get; set; }
        //public List<ProductGallery> Gallery { get; set; }
        //public List<ProductFilter> Filter { get; set; }
    }

}
