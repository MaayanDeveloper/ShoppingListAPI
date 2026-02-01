using Microsoft.Extensions.DependencyInjection;
using ShoppingListAPI;
using ShoppingListAPI.Core.Repositories;
using ShoppingListAPI.Core.Services;
using ShoppingListAPI.Data;
using ShoppingListAPI.Data.Repositories;
using ShoppingListAPI.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddDbContext<DataContext>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//הערות לפרוייקט// מעיין בוקריץ וחיה שפרונג:
//•	אנחנו מגישות את הפרוייקט יחד באישור המורה. 

//•	דבר נוסף, יש לנו 3 מחלקות אך כרגע רק אחת מתוכן (product) ממומשת כי יש בהן קשרי גומלין. (שאלנו, ואמרת לנו כרגע לא לעשות, אם אפשר כבר לעשות נעבוד על זה בקרוב ממש בעז"ה...)


