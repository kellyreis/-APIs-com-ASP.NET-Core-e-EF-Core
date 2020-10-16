using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;
using ProductCatalog.Repositories;

namespace ProductCatalog.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepositorie _repositorie;

        public CategoryController(CategoryRepositorie repositorie)
        {
            _repositorie = repositorie;
        }

        [Route("v1/categories")]
        [HttpGet]

        public IEnumerable<Category> Get()
        {
          return  _repositorie.Get();
        }

        [Route("v1/categories/{id}")]
        [HttpGet]

        public Category Get(int id)
        {
            return _repositorie.Get(id);
        }

        [Route("v1/categories/{id}/products")]
        [HttpGet]

        public IEnumerable<Product> GetProducts(int id)
        {
            return _repositorie.GetProducts(id);
        }
        [Route("v1/categories")]
        [HttpPost]

        public Category Post([FromBody] Category category)
        {         

             _repositorie.Save(category);

            return category;
        }

        [Route("v1/categories")]
        [HttpPut]

        public Category Put([FromBody] Category category)
        {
            _repositorie.Update(category);

            return category;
        }

        [Route("v1/categories")]
        [HttpDelete]

        public Category Delete([FromBody] Category category)
        {
            _repositorie.Delete(category);
            return category;
        }

    }
}
