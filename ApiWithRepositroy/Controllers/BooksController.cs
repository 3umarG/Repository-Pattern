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
		private readonly IUnitOfWork _unitOfWork;

		public BooksController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var book = await _unitOfWork.Books.GetByIdAsync(id, new string[] { "Author" });

			if (book == null)
			{
				return new NotFoundObjectResult("Not Found Result");
			}

			return Ok(book);

		}

		[HttpGet("GetByName")]
		public async Task<IActionResult> GetByName(string name)
		{
			var book = await _unitOfWork.Books.GetByNameAsync(B => B.Title.Contains(name), new string[] { "Author" });
			if (book == null)
			{
				return Ok($"There is no Book with Name : {name}");
			}

			return Ok(book);
		}


		[HttpGet("GetAllWithName")]
		public async Task<IActionResult> GetAllWithNameAsync(string name)
		{
			var books = await _unitOfWork.Books.GetAllWithNameAsync(B => B.Title.Contains(name), new string[] { "Author" });
			return Ok(books);
		}


		[HttpGet("GetAllBooksWithAuthorId/{id}")]
		public async Task<IActionResult> GetAllBooksWithAuthorIdAsync(int id)
		{
			var books = await _unitOfWork.Books.GetAllBooksWithAuthorIdAsync(id);
			return Ok(books);
		}
	}
}
