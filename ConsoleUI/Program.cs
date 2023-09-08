// using System;

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.Inmemory;
using Entities.Concrete;

class Program
{
    static void Main(string[] args)
    {

        ProductTest();
    }

   

    private static void ProductTest()
    {
        ProductManager productManager = new ProductManager(new EfproductDal(), new CategoryManager(new EfCategoryDal()));
        Product product = new Product();
        
        product.ProductName = "ert";
        product.CategoryId = 3;
        product.UnitPrice = 23;
        product.UnitsInStock = 12;

        var result = productManager.Add(product);

        Console.WriteLine("------");
        Console.WriteLine(result);

       /* if (result.Success == true)
        {
            foreach (var product in result.Data)
            {
                Console.WriteLine(product.ProductName);

            }
        }
        else
        {
            Console.WriteLine(result.Message);
        } */

        
    }
}