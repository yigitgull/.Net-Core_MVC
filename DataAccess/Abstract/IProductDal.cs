using System;
using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();


    }
}

