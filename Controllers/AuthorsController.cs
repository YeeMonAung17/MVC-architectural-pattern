using Microsoft.AspNetCore.Mvc;
using MVC.Services;
using System;
using MVC.Models;

namespace MVC.Controllers
{
    // Setting up controller and route

    [Route("/[controller]")] //the app know the route is authors by adding[controller]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        // Set up instance of AuthorService as a dependency

        private readonly AuthorServices _authorService;

        public AuthorsController (AuthorServices authorService)
        {
            _authorService = authorService;
        }


        // Creating an action Method

        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            var authors = _authorService.GetAllAuthors(); //controller only know about service 
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorsById(int id)
        {
            var authors = _authorService.GetAuthorById(id);
            if(authors == null)
            {
                return NotFound();
            }
            return Ok(authors);
        }

        [HttpPost]
        public IActionResult AddAuthor(Author author)
        {

            var addedAuthor = _authorService.AddAuthor(author);
            if (author == null) return BadRequest();
            return Ok(addedAuthor);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthorById(int id)
        {
            var authorDeleted = _authorService.RemoveAuthorById(id);
            if (authorDeleted == null)
            {
                return NotFound();
            }

            // SUCCESS: Return 204 No Content
            return NoContent();
        }
    }
}
