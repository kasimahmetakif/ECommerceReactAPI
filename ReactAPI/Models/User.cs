namespace ReactAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsStatus { get; set; }

        public List<Blog>? Blogs { get; set; }

        public List<Order>? Orders { get; set; }

        public Cart? Cart { get; set; }


    }

}
