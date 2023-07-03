using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.Interfaces
{
	public interface IBaseRepository<T> where T : class
	{
		Task<T?> GetByIdAsync(int id);
		Task<T?> GetByIdAsync(int id , string[] includes);

		Task<IEnumerable<T>> GetAllAsync();

		Task<T?> GetByNameAsync(Expression<Func<T, bool>> predicate);
	}
}
