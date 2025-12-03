using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI;
using ShoppingListAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace productTest
{
    public class productControllerTest
    {
        private readonly FakeContext fakeContext= new FakeContext();
        [Fact]
        public void Get_ReturnList() // בודקת שהפונקציה מחזירה רשימת מוצרים
        {
            //AAA

            //ARRANGE - מה הפונקציה מקבלת

            //ACT - מפעילה את הפונקציה
            var controller = new ProductController(fakeContext);
            var result= controller.Get();

            //ASSERT - מכריזה מה אני מצפה לקבל מהפונקציה
            Assert.IsType<List<Product>>(result);
        }

        [Fact]
        public void GetById_ReturnOK() //שהפונקציה מחזירה ok ל id נכון
        {
            var id = 80;

            var controller = new ProductController(fakeContext);
            var result = controller.Get(id);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_ReturnNotFound() //שהפונקציה מחזירה notFound ל id לא נכון
        {
            var id = 9;

            var controller = new ProductController(fakeContext);
            var result = controller.Get(id);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Add_ReturnOK() //בדיקה אם ההוספה הצליחה
        {
            var p= new Product{Id=3, Name="cheese", Category= "milk", IsAvailable=true};

            var controller= new ProductController(fakeContext);
            controller.Post(p);

            var allProducts= controller.Get();
            Assert.Contains(allProducts, x => x.Id == 3);
        }

        [Fact]
        public void putById_Succeeded() // בדיקה האם השינוי הצליח
        {
            var p = new Product { Id = 85, Name = "banana", Category = "fruits", IsAvailable = true };

            var controller= new ProductController(fakeContext);
            controller.Put(80, p);

            var allProducts= controller.Get();
            Assert.Contains(allProducts, x => x.Id == 85 && x.Name == "banana" && x.Category == "fruits");
        }

        [Fact]
        public void Delete_ById() //בדיקה האם המחיקה הצליחה
        {
            var id = 3;

            var controller = new ProductController(fakeContext);
            controller.Delete(id);
            var allProducts = controller.Get();
            Assert.DoesNotContain(allProducts, x => id == x.Id);
        }
    }
}
