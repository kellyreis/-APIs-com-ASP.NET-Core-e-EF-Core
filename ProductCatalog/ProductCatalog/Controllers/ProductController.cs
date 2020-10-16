using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;
using ProductCatalog.Repositories;
using ProductCatalog.ViewModels.ProductViewModels;
namespace ProductCatalog.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepositorie _repositorie;
        public ProductController(ProductRepositorie repositorie)
        {
            _repositorie = repositorie;
        }


        [Route("v1/products")]
        [HttpGet]

        public IEnumerable<ListProductViewModel> Get()
        {
            return _repositorie.Get();

        }

        [Route("v1/products/{id}")]
        [HttpGet]

        public Product Get(int id)
        {
            return _repositorie.Get(id);
        }

        [Route("v1/products")]
        [HttpPost]
        public ResultViewModel Post([FromBody]EditorProductViewModel model)
        {
            model.Validate();

            if (model.Invalid)
                return new ResultViewModel
                {
                    Sucess = false,
                    Message = "Não foi possível cadastrar o produto",
                    Data = model.Notifications

                };

            var product = new Product();
            product.Title = model.Title;
            product.CategoryId = model.CategoryId;
            product.CreateDate = DateTime.Now;
            product.description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now;
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            _repositorie.Save(product);

            return new ResultViewModel
            {
                Sucess = true,
                Message = "Produto cadastrado com sucesso!",
                Data = product
            };
        
        }

        [Route("v1/products")]
        [HttpPut]

        public ResultViewModel Put([FromBody] EditorProductViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Sucess = false,
                    Message = "Não foi possível alterar o produto",
                    Data = model.Notifications
                };

            var product = _repositorie.Get(model.Id);
            product.Title = model.Title;
            product.CategoryId = model.CategoryId;
            product.description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now;
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            _repositorie.Update(product);

            return new ResultViewModel
            {
                Sucess = true,
                Message = "Alteração realizada com sucesso",
                Data = product
            };
        }

    }
}
