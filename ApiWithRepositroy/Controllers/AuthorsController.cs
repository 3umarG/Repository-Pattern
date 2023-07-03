using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Core.Interfaces;
using Movies.Core.Models;

namespace ApiWithRepositroy.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorsController : ControllerBase
	{
		private readonly IBaseRepository<Author> _authorRepository;

		public AuthorsController(IBaseRepository<Author> authorRepository)
		{
			_authorRepository = authorRepository;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var author = await _authorRepository.GetByIdAsync(id);

			if(author == null)
			{
				return new NotFoundObjectResult("Not Found Result");
			}

			return Ok(author);
		}


		[HttpGet()]
		public async Task<IActionResult> GetAllAsync()
		{
			var result
				= await _authorRepository.GetAllAsync();
			return Ok(result);
		}
	}
}
