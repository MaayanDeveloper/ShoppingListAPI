using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Security.Cryptography;

namespace ShoppingListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
        
    {
        private readonly IProductService _productService;
    

        private readonly IDataContext _Context;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return OK(_productService.GetProduct());
        }

        //GET api/<ProductController>/id
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var p = _productService.GetById(id);
            if (p != null)
            {
                return Ok(p);
            }
            return NotFound();
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult Post([FromBody] Product value)
        {
            var e= _Context.product.Find(x => x.Id==value.Id);
            if (e != null)
            {
                return Conflict();
            }
           _productService.Add(value); 
            return Ok(value);
        }
        
        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product value)
        {
            var p = _productService.FindIndex(x => x.Id == id);
            if(p!= -1)
            {
               _productService[p].Id = value.Id;
                _productService[p].Name = value.Name;
                _productService[p].Category = value.Category;
                return Ok(_productService[p]);
            }
            return NotFound();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var p = _productService.Find(y => y.Id == id);
            if(p != null)
            {
                _productService.Remove(p);
                return Ok();
            }
            return NotFound();
        }
    }
}
