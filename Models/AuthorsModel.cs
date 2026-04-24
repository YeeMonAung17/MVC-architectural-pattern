using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace MVC.Models
{
    public class AuthorsModel
    {
      
        public List<Author> GetAllAuthors()
        {
            var json = File.ReadAllText(".\\Resources\\Authors.json");

            return JsonConvert.DeserializeObject<List<Author>>(json)
               ?? new List<Author>();
        }
    }
}
