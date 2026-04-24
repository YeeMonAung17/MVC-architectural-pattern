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
    }
}
