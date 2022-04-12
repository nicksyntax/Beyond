using System;
using System.Collections.Generic;
using System.Linq;
using Beyond.IntegrationServices.PostsService;
using Beyond.IntegrationServices.PostsService.Payloads;
using Beyond.Entities;

namespace Beyond.Business
{
    public class ProductsBusiness
    {
        ProductsDao ProductsDao = new ProductsDao();
        public List<ProductEntity> GetAllProducts()
        {
            var data = ProductsDao.GetAll();
            return new List<ProductEntity>();
        }
    }
}
