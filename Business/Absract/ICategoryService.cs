using System;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Absract
{
	public interface ICategoryService
	{
		IDataResult<List<Category>> GetAll();

		IDataResult<Category> GetById(int categoryId);
	}
}

