﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> { 
            new Product{ProductId =1, CategoryId=1, ProductName="BARDAK", UnitPrice=15, UnitsInStock=15},
            new Product{ProductId =2, CategoryId=1, ProductName="KAMERA", UnitPrice=500, UnitsInStock=3},
            new Product{ProductId =3, CategoryId=2, ProductName="TELEFON", UnitPrice=1500, UnitsInStock=2},
            new Product{ProductId =4, CategoryId=2, ProductName="KLAVYE", UnitPrice=150, UnitsInStock=65},
            new Product{ProductId =5, CategoryId=2, ProductName="FARE", UnitPrice=85, UnitsInStock=1}

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ -Language Intedrated Query
            //Lambda
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
            
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void UpDate(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAllBycategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}