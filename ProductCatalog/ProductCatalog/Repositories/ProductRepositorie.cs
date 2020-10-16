﻿using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;
using ProductCatalog.ViewModels.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Repositories
{
    public class ProductRepositorie
    {
        private readonly StoreDataContext _context;

        public ProductRepositorie(StoreDataContext context)
        {
            _context = context;
        }


        public IEnumerable<ListProductViewModel> Get()
        {
            return _context.Products
               .Include(x => x.Category)
               .Select(x => new ListProductViewModel
               {
                   Id = x.Id,
                   Title = x.Title,
                   Price = (decimal)x.Price,
                   Category = x.Category.Title,
                   CategoryId = x.Category.Id,
               })
           .AsNoTracking()
           .ToList();
        }

        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }

        public void Save(Product product)
        {
            _context.Products.Add(product);

            _context.SaveChanges();

        }

        public void Update(Product product)
        {
            _context.Entry<Product>(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
