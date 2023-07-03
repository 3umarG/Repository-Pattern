using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.Models
{
	public class Book
	{
		public int Id { get; set; }

		[Required , MaxLength(300)]
		public string Title { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
