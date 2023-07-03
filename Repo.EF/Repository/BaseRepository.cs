using Microsoft.EntityFrameworkCore;
using Movies.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

		public async Task<T?> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<T?> GetByIdAsync(int id, string[] includes)
		{
			
			IQueryable<T> query = _context.Set<T>();


            foreach (var include in includes)
            {
				query = query.Include(include);
            }
            await query.LoadAsync();

			return await _context.FindAsync<T>(id);

			
		


		}

		public async Task<T?> GetByNameAsync(Expression<Func<T, bool>> predicate)
		{
			return await _context.Set<T>().FirstOrDefaultAsync(predicate);
		}
	}
}
