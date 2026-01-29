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
        public async Task<ActionResult > Get()
        {
            var product = await _productService.GetProductAsync();
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
        public  async Task<ActionResult> Post([FromBody] Product value)
        {
            var e= await _productService.GetByIdAsync(value.Id);
            if (e != null)
            {
                return Conflict();
            }
            var s = await _productService.AddAsync(value);
            return Ok(s);

        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Product value)
        {
            var p = await _productService.GetByIdAsync(id);
            if(p == null)
            {
                var product= _mapper.Map<Product>(value);
                return Conflict();
            }
            var updated = await _productService.UpdateAsync(id, value);
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




//הערות לפרוייקט// מעיין בוקריץ וחיה שפרונג:
//•	אנחנו מגישות את הפרוייקט יחד באישור המורה. 

//•	דבר נוסף, יש לנו 3 מחלקות אך כרגע רק אחת מתוכן (product) ממומשת כי יש בהן קשרי גומלין. (שאלנו, ואמרת לנו כרגע לא לעשות, אם אפשר כבר לעשות נעבוד על זה בקרוב ממש בעז"ה...)

//•	בקשר לשיעור האחרון, הרבה פונקציות עשינו אסינכרוניות (אע"פ שלפי הכללים לא אמור להיות, אבל בדקנו עם GPT וזה הדבר היחיד שתיקן את השגיאות...)

//תודה רבה!!!
