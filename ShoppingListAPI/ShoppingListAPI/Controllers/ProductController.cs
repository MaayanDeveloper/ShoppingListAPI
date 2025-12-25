using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Core.Models;
using ShoppingListAPI.Core.Services;
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
    

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_productService.GetProduct());
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
            var e= _productService.GetById(value.Id);
            if (e != null)
            {
                return Conflict();
            }
           var s= _productService.Add(value); 
            return Ok(s);
        }
        
        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product value)
        {
            var p = _productService.GetById(id);
            if(p==null)
            {
                return NotFound();
            }
            return Ok(_productService.Update(id, value));
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var p = _productService.GetById(id);
            if(p != null)
            {
                _productService.Delete(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
