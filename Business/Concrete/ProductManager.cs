using System;
using System.Collections.Generic;
using Business.Absract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using Entities.Concrete;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Performance;

namespace Business.Concrete
{
    public class ProductManager : IProductService

	{
        IProductDal _productDal;
        ICategoryService _categoryService;
        
		public ProductManager(IProductDal productDal, ICategoryService categoryService)
		{
            _productDal = productDal;
            _categoryService = categoryService;
		}

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p => p.CategoryId == id));
        }

        

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        [SecuredOperation("admin")]
        //[ValidationAspect(typeof(ProductValidator))]
        //[CacheRemoveAspect("IPRoductService.Get")]
        public IResult Add(Product product)
        {


            //business codes
            IResult result = BusinessRules.Run(CheckIfProductNameExist(product.ProductName),
                                              (CheckIfProductCountOfCAtegory(product.CategoryId)));

            if(result != null)
            {
                return result;
            }


            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }


        [CacheAspect]
        //[PerformanceAspect(5)]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        private IResult CheckIfProductCountOfCAtegory(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductConutOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExist(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExistError);
            }
            return new SuccessResult();
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            _productDal.Update(product);
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}

