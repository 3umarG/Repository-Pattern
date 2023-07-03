using Movies.Core.Interfaces;
using Movies.Core.Models;
using Movies.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.EF
{
	public class UnitOfWork : IUnitOfWork
	{
		public IBaseRepository<Author> Authors { get; private set; }

		public IBaseRepository<Book> Books { get; private set; }

		private readonly ApplicationDbContext _context;

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
			Books = new BaseRepository<Book>(_context);
			Authors = new BaseRepository<Author>(_context);
		}

		public int Complete()
		{
			return _context.SaveChanges();
		}

		public void Dispose() => _context.Dispose();
	}
}
