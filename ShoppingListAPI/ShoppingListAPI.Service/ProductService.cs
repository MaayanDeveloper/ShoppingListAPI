using ShoppingListAPI.Core.Services;
using ShoppingListAPI.Core.Models;
using ShoppingListAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetProduct()
        {
            return _productRepository.GetProduct();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Product Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public Product Update(int id, Product product)
        {
            _productRepository.Save();
            return _productRepository.Update(id, product);
        }

        public void Delete(int id)
        {
            _productRepository.Save();
            _productRepository.Delete(id);
        }
    }
}
