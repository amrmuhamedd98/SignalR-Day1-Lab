namespace ProductsApp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
    }
}
