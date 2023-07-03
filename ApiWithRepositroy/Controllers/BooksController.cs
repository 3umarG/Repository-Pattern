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
			var book = await  _booksRepository.GetByIdAsync(id);

			if (book == null)
			{
				return new NotFoundObjectResult("Not Found Result");
			}

			return Ok(book);

		}
	}
}
