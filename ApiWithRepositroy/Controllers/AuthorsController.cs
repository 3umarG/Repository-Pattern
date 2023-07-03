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
		private readonly IUnitOfWork _unitOfWork;

		public AuthorsController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var author = await _unitOfWork.Authors.GetByIdAsync(id);

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
				= await _unitOfWork.Authors.GetAllAsync();
			return Ok(result);
		}


		[HttpGet("GetByName")]
		public async Task<IActionResult> GetByNameAsync(string name)
		{
			var author = await _unitOfWork.Authors.GetByNameAsync(a => a.Name.Contains(name));
			if(author == null)
			{
				return Ok($"There is No Authors with name : {name}");
			}

			return Ok(author);
		}
	}
}
