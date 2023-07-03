using Microsoft.EntityFrameworkCore;
using Movies.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.EF
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public virtual DbSet<Author> Authors { get; set; }
		public virtual DbSet<Book> Books { get; set; }
	}
}
