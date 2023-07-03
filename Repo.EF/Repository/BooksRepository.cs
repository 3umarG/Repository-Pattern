using Microsoft.EntityFrameworkCore;
using Movies.Core.Interfaces;
using Movies.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.EF.Repository
{
	public class BooksRepository : BaseRepository<Book> , IBooksRepository
	{
		private readonly ApplicationDbContext _context;
		public BooksRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Book>> GetAllBooksWithAuthorIdAsync(int id)
		{
			return await _context.Books.Where(B => B.AuthorId == id).Include(B => B.Author).ToListAsync();
		}
	}
}
