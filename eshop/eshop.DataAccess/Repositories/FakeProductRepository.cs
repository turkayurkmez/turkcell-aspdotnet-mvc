﻿using eshop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.DataAccess.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            return new List<Product>()
            {
                new(){ Id=1, Name="Ürün A1", Price=1, Description="Ürün A1'nın açıklaması", DiscountRate=0.15m, Stock=100, CriticalLevel=15},
                new(){ Id=2, Name="Ürün A2", Price=5, Description="Ürün A2'nın açıklaması", DiscountRate=0.15m, Stock=100, CriticalLevel=15},
                new(){ Id=3, Name="Ürün A3", Price=10, Description="Ürün A3'nın açıklaması", DiscountRate=0.15m, Stock=100, CriticalLevel=15},
                new(){ Id=4, Name="Ürün A4", Price=20, Description="Ürün A4'nın açıklaması", DiscountRate=0.15m, Stock=100, CriticalLevel=15},

            };

        }

        public IEnumerable<Product> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}