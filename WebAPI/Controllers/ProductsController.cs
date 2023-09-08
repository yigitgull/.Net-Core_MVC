using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Absract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.Inmemory;




namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        

        [HttpGet("getall")]
        public IActionResult Get()
        {   
            
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            Console.WriteLine("************");
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Post(Product product)
        {
            Console.WriteLine("************");
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

