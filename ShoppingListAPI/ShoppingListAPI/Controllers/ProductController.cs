using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Core.DTO;
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
        private readonly IMapper _mapper;
    

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;

        }
        [HttpGet]
        public ActionResult Get()
        {
            var product = _productService.GetProduct();
            return Ok(_mapper.Map<List<productDTO>>(product));
        }

        //GET api/<ProductController>/id
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var p = _productService.GetById(id);
            if (p != null)
            {
                var pro= _mapper.Map<productDTO>(p);
                return Ok(pro);
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
            if(p == null)
            {
                var product= _mapper.Map<Product>(value);
                return Conflict();
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
