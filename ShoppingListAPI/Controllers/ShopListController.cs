using Microsoft.AspNetCore.Mvc;

namespace ShoppingListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopListController : ControllerBase
    {
        private readonly IShopListService _ShopListService;

        public static List<ShopList> shopList = new List<ShopList>
        {new ShopList {Id= 1,
            Title="for shabat",
            //ProductsArr= new List<Product>
            //{
            //    new Product { Id = 10, Name = "bread", Category = "bakery", IsAvailable = true },
            //    new Product {Id= 11, Name= "yogurt", Category= "dairy", IsAvailable=true }
            //} },
            //new ShopList {Id= 1,
            //Title= "birthDay",
            //ProductsArr= new List<Product>
            //{
            //    new Product { Id = 20, Name = "cake", Category = "bakery", IsAvailable = true },
            //    new Product {Id= 21, Name= "candles", Category= "decoration", IsAvailable=true }
            //}
        } };

        // GET: api/<ShopListController>
        [HttpGet]
        public IEnumerable<ShopList> Get()
        {
            return shopList;
        }

        //GET api/<ShopListController>/id
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var p = shopList.Find(x => x.Id == id);
            if (p != null)
            {
                return Ok(p);
            }
            return NotFound();
        }

        // POST api/<ShopListController>
        [HttpPost]
        public void Post([FromBody] ShopList value)
        {
            shopList.Add(value);
        }

        // PUT api/<ShopListController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ShopList value)
        {
            var p = shopList.FindIndex(x => x.Id == id);
            if (p != -1)
            {
                shopList[p].Id = value.Id;
                shopList[p].Title = value.Title;
                //shopList[p].ProductsArr = value.ProductsArr;

                return Ok(shopList[p]);
            }
            return NotFound();
        }

        // DELETE api/<ShopListController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var p = shopList.Find(y => y.Id == id);
            if (p != null)
            {
                shopList.Remove(p);
                return Ok();
            }
            return NotFound();
        }
    }
}


//החלקים שנמצאים בהערה זה המערך של המוצרים שנוסיף בהמשך
