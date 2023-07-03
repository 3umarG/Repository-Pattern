using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Core.Interfaces;
using Movies.Core.Models;

namespace ApiWithRepositroy.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private readonly IBaseRepository<Book> _booksRepository;

		public BooksController(IBaseRepository<Book> booksRepository)
		{
			_booksRepository = booksRepository;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var book = await _booksRepository.GetByIdAsync(id, new string[] { "Author" });

			if (book == null)
			{
				return new NotFoundObjectResult("Not Found Result");
			}

			return Ok(book);

		}

		[HttpGet("GetByName")]
		public async Task<IActionResult> GetByName(string name)
		{
			var book = await _booksRepository.GetByNameAsync(B => B.Title.Contains(name), new string[] { "Author" });
			if (book == null)
			{
				return Ok($"There is no Book with Name : {name}");
			}

			return Ok(book);
		}


		[HttpGet("GetAllWithName")]
		public async Task<IActionResult> GetAllWithNameAsync(string name)
		{
			var books = await _booksRepository.GetAllWithNameAsync(B => B.Title.Contains(name), new string[] { "Author" });
			return Ok(books);
		}
	}
}
