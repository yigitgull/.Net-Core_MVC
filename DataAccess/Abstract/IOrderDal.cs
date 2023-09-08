using System;
using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using Entities;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {


    }
}

