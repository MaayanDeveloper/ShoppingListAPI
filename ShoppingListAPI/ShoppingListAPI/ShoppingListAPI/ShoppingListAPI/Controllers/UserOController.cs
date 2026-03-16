//using Microsoft.AspNetCore.Mvc;

//namespace ShoppingListAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserOController : ControllerBase
//    {
//        public static List<UserO> user = new List<UserO> { new UserO {Id= 1, Name="Yosi", Email="5265@gmail.com"},
//        new UserO {Id=2, Name="israel", Email="54541@gmail.com"} };


//        // GET: api/<UserOController>
//        [HttpGet]
//        public IEnumerable<UserO> Get()
//        {
//            return user;
//        }

//        //GET api/<UserOController>/id
//        [HttpGet("{id}")]
//        public ActionResult Get(int id)
//        {
//            var p = user.Find(x => x.Id == id);
//            if (p != null)
//            {
//                return Ok(p);
//            }
//            return NotFound();
//        }

//        // POST api/<UserOController>
//        [HttpPost]
//        public void Post([FromBody] UserO value)
//        {
//            user.Add(value);
//        }

//        // PUT api/<UserOController>/5
//        [HttpPut("{id}")]
//        public ActionResult Put(int id, [FromBody] UserO value)
//        {
//            var p = user.FindIndex(x => x.Id == id);
//            if (p != -1)
//            {
//                user[p].Id = value.Id;
//                user[p].Name = value.Name;
//                user[p].Email = value.Email;
//                return Ok(user[p]);
//            }
//            return NotFound();
//        }

//        // DELETE api/<UserOController>/5
//        [HttpDelete("{id}")]
//        public ActionResult Delete(int id)
//        {
//            var p = user.Find(y => y.Id == id);
//            if (p != null)
//            {
//                user.Remove(p);
//                return Ok();
//            }
//            return NotFound();

//        }
//    }
//}

