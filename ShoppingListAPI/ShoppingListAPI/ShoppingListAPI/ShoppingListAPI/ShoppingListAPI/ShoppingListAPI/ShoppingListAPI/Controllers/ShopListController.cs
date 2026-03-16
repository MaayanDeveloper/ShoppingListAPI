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
    public class ShopListController : ControllerBase
    {
        private readonly IShopListService _ShopListService;
        private readonly IMapper _mapper;

        public ShopListController(IShopListService ShopListService, IMapper mapper)
        {
            _ShopListService = ShopListService;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lists = await _ShopListService.GetAllListsAsync();
            return Ok(_mapper.Map<List<shopListDTO>>(lists));
        }

        [HttpGet("all-names")]
        public async Task<ActionResult> GetAllNames()
        {
            var lists = await _ShopListService.GetAllNanesListsAsync();
            return Ok(_mapper.Map<List<shopListNamesDTO>>(lists));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var list = await _ShopListService.GetShopListByIdAsync(id);
            if (list == null)
                return NotFound();
            return Ok(_mapper.Map<shopListDTO>(list));
        }
        [HttpGet("title/{title}")]
        public async Task<ActionResult> GetByTitle(string title)
        {
            var list = await _ShopListService.GetListByTitleAsync(title);
            if (list == null)
                return NotFound();
            return Ok(_mapper.Map<shopListDTO>(list));
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ShopListPostModel value)
        {
            var p = await _ShopListService.GetShopListByIdAsync(value.Id);
            if (p != null)
            {
                return Conflict();
            }
            var e = _mapper.Map<ShopList>(value);
            e.UserOKey = 2;
            var s = await _ShopListService.AddShopListAsync(e);
            return Ok(s);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ShopListPostModel value)
        {
            var p = await _ShopListService.GetShopListByIdAsync(id);
            if (p == null)
            {
                return NotFound();
            }
            var e = _mapper.Map<ShopList>(value);
            var updated = await _ShopListService.UpdateShopListAsync(id, e);
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var p = await _ShopListService.GetShopListByIdAsync(id);
            if (p != null)
            {
                await _ShopListService.DeleteShopListAsync(id);
                return Ok();
            }
            return NotFound();
        }
    }
}