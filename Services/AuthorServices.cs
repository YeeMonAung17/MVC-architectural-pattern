using Microsoft.AspNetCore.Http.HttpResults;
using MVC.Models;
using Newtonsoft.Json;

namespace MVC.Services
{
    public class AuthorServices
    {

        private readonly AuthorsModel _authorsModel;

        public AuthorServices (AuthorsModel authorsModel)
        {
            _authorsModel = authorsModel;
        }
        public List<Author> GetAllAuthors ()
        {

            var models = _authorsModel.GetAllAuthors ();
            return models;
           
        }

        public Author? GetAuthorById (int id)
        {
            var models = _authorsModel.GetAllAuthors();
            return models.FirstOrDefault(a => a.Id == id);
        }


        public Author? AddAuthor(Author author)
        {
            var models = _authorsModel.GetAllAuthors();

            // Logic: Find the highest ID and add 1. If no authors exist, start at 1.
            int nextId = models.Any() ? models.Max(a => a.Id) + 1 : 1;
            author.Id = nextId;

            // Send the author with its new ID to the Model to be saved
            _authorsModel.AddAuthor(author);

            return author;
        }


        public Author? RemoveAuthorById(int id)
        {

            var models = GetAuthorById(id);

            if (models == null )
            {
                return null;
            }

            _authorsModel.RemoveAuthorById(id);

            return models;


            
        }
    }
}
