using System;
using Entities.Concrete;
using System.Collections.Generic;
using Core.DataAccess.EntityFramework;

namespace DataAccess.Abstract
{
	public interface ICategoryDal : IEntityRepository<Category>
    {
      
    }
}

