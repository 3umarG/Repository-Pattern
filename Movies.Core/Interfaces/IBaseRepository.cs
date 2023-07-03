using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.Interfaces
{
	public interface IBaseRepository<T> where T : class
	{
		Task<T> GetByIdAsync(int id);

		Task<IEnumerable<T>> GetAllAsync();
	}
}
