
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Core.DTO;
using ShoppingListAPI.Core.Models;
using ShoppingListAPI.Core.Services;
using ShoppingListAPI.Models;
using ShoppingListAPI.Service;

namespace ShoppingListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductInLIstController : ControllerBase
    {
        private readonly IProductInListService _productInListService;
        private readonly IMapper _mapper;

        public ProductInLIstController(IProductInListService ProductInListService, IMapper mapper)
        {
            _productInListService = ProductInListService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductInListPostModel type)
        {
            var itemToAdd = _mapper.Map<ProductInLIst>(type);
            var result = await _productInListService.AddProductToListAsync(itemToAdd);
            var dtoToReturn = _mapper.Map<ProductInListDTO>(result);
            return Ok(dtoToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var isDeleted = await _productInListService.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound("המוצר לא נמצא ברשימה");
            }
            return NoContent(); 
        }
    }
}
