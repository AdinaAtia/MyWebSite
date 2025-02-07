using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using Repositories;
using Zxcvbn;

namespace Services
{

    public class ProductsServices : IProductsServices
    {
        IProductsRepository repository;
    public ProductsServices(IProductsRepository repository)
    {
        this.repository = repository;
        }
        
        public async Task<List<Product>> Get(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return await repository.Get(  desc,   minPrice,   maxPrice,  categoryIds);
    }
       

    }
}
