using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Serialization;
using System.Text.Json;
using System.Linq;

namespace MVC.Models
{
    public class AuthorsModel
    {
        private string _filePath = ".\\Resources\\Authors.json";

        public List<Author> GetAllAuthors()
        {
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Author>>(json) ?? new List<Author>();
        }

        public void AddAuthor(Author author)
        {
            // 1. Get the current list
            var authors = GetAllAuthors();

            // 2. Add the new one
            authors.Add(author);

            // 3. Serialize with "WriteIndented" so it's readable
            var options = new JsonSerializerOptions { WriteIndented = true };
            string updatedJson = JsonSerializer.Serialize(authors, options);

            // 4. Write back to file
            File.WriteAllText(_filePath, updatedJson);
        }


       public void RemoveAuthorById(int id)
        {
            var authorsList = GetAllAuthors();

            var updatedList = authorsList.Where (a=>a.Id != id).ToList();
            var options = new JsonSerializerOptions { WriteIndented = true };
            string updatedJson = JsonSerializer.Serialize(updatedList, options);

            File.WriteAllText(_filePath, updatedJson);


        }
    }
}
