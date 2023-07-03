using Microsoft.EntityFrameworkCore;
using Movies.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.EF.Repository
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{

		private readonly ApplicationDbContext _context;

		public BaseRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			var result = await _context.Set<T>().ToListAsync();
			return result;
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}
	}
}
