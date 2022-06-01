using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntitiyRepositoryBase<Product, NorthwindContex>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContex contex = new NorthwindContex())
            {
                var result = from p in contex.Products
                             join c in contex.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto { ProductId = p.ProductId, ProductName = p.ProductName, UnitsInStock = p.UnitsInStock, CategoryName = c.CategoryName };
                return result.ToList();
            }
        }
    }
}
