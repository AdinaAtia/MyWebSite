
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repositories
{
    public class ProductsRepository: IProductsRepository
    {
        CatagoryContext Manger_DB_context;
        public ProductsRepository(CatagoryContext Manger_DB_context)
        {
            this.Manger_DB_context = Manger_DB_context;
        }
    //public async Task<List<Product>> Get()
    //{
    //        List<Product> products = await Manger_DB_context.Products.ToListAsync();
    //        return products;
    //    }
        public async Task<List<Product>> Get(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            var query = Manger_DB_context.Products.Where(Product =>
              (desc == null ? (true) : (Product.ProductName.Contains(desc)))
              && ((minPrice == null) ? (true) : (Product.Price >= minPrice))
              && ((maxPrice == null) ? (true) : (Product.Price <= maxPrice))
              && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(Product.CategoryId))))




             .OrderBy(Product => Product.Price).Include(c => c.Category);
            Console.WriteLine(query.ToQueryString());
            List<Product> products = await query.ToListAsync();
               return products;
            //List<Product> product = await myShop.Products.Include(c => c.Category).ToListAsync();
            //return product;
        }
    }
}

//public async Task<List<Product>> Get(int? minPrice, int? maxPrice, int?[] categoryIds, string? desc)
//{

//    var query = _ManagerDBcontext.Products.Where(Product =>
//    (desc == null ? (true) : (Product.ProductName.Contains(desc)))
//     && (minPrice == null ? (true) : (Product.Price >= minPrice))
//     && ((maxPrice == null) ? (true) : (Product.Price <= maxPrice))
//     && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(Product.CategoryId))))



//    .OrderBy(Product => Product.Price).Include(p => p.Category);
//    Console.WriteLine(query.ToQueryString());
//    List<Product> products = await query.ToListAsync();
//    return products;

//}




















//public int ProductsId { get; set; }

//public int CategoryId { get; set; }

//public string ProductName { get; set; } = null!;

//public string? Decripition { get; set; }

//public int Price { get; set; }

//public string? ImgPath { get; set; }

//public int? Quentity { get; set; }
//public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();


//public virtual Category Category { get; set; } = null!;
//}
