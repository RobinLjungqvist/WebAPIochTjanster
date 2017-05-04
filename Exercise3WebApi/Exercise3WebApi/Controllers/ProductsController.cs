using Exercise3WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Exercise3WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private List<Product> Products { get; set; }

        public ProductsController()
        {
            Products = new List<Product>()
            {
                new Product() { id = 1, Name = "Tomato soup", Category = "Groceries", Price = 1 },
                new Product() { id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
                new Product() { id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M },
            };
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return Products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.id == id);

            if(product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
