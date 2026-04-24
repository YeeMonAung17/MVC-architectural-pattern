namespace MVC.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }

        public List<string> Books { get; set; } = new List<string>();
    }
}
