using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Core.DTO;
using ShoppingListAPI.Core.Models;
using ShoppingListAPI.Core.Services;
using ShoppingListAPI.Models;
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
        public async Task<ActionResult> Get()
        {
            var product = await _productService.GetProductAsync();
            if (product == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<productDTO>>(product));
        }

        //GET api/<ProductController>/id
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var p = await _productService.GetByIdAsync(id);
            if (p != null)
            {
                var pro= _mapper.Map<productDTO>(p);
                return Ok(pro);
            }
            return NotFound();
        }

        // POST api/<ProductController>
        [HttpPost]
        public  async Task<ActionResult> Post([FromBody] ProductPostModels value)
        {
            var p= await _productService.GetByIdAsync(value.Id);
            if (p != null)
            {
                return Conflict();
            }
            var e = _mapper.Map<Product>(value);
            var s = await _productService.AddAsync(e);
            return Ok(s);

        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductPostModels value)
        {
            //מביא את המוצר מהמסד נתונים לפי ה ID
            //ואז עושה בדיקה אם הוא שווה NULL
            var p = await _productService.GetByIdAsync(id);
            if(p == null)
            {
                //var product= _mapper.Map<Product>(value);
                return Conflict();
            }
            //את המוצר DTO שקיבלנו הופך למוצר רגיל ומעדכן
            var e = _mapper.Map<Product>(value);
            var updated = await _productService.UpdateAsync(id, e);
            return Ok(updated);

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var p = await _productService.GetByIdAsync(id);
            if(p != null)
            {
                await _productService.DeleteAsync(id);
                return Ok();
            }
            return NotFound();
        }
    }
}





