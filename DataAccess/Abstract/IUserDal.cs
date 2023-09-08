﻿using System;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;

namespace DataAccess.Abstract
{
	
        public interface IUserDal : IEntityRepository<User>
        {
            List<OperationClaim> GetClaims(User user);
        }
    
}

