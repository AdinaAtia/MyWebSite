using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        CatagoryContext Manger_DB_context;
        public CategoryRepository(CatagoryContext Manger_DB_context)
        {
            this.Manger_DB_context = Manger_DB_context;
        }
        public async Task<List<Category>> Get()
        {
            List<Category> category = await Manger_DB_context.Categories.ToListAsync();
            return category;
        }
        //public async Task<Category> GetById(int id)
        //{
        //    Category category = await Manger_DB_context.Categories.FirstOrDefaultAsync(currentCategory => currentCategory.Id == id);
        //    return category;
        //}
    }
}

//using Entities;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Repositories
//{
//    public class CategoryRepository : ICategoryRepository
//    {
//        private readonly IDbContextFactory<CatagoryContext> _contextFactory;

//        public CategoryRepository(IDbContextFactory<CatagoryContext> contextFactory)
//        {
//            _contextFactory = contextFactory;
//        }

//        public async Task<List<Category>> Get()
//        {
//            using (var context = _contextFactory.CreateDbContext())
//            {
//                return await context.Categories.ToListAsync();
//            }
//        }
//    }
//}


//using Entities;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Repositories
//{
//    public class CategoryRepository : ICategoryRepository
//    {
//        private readonly IDbContextFactory<CatagoryContext> _contextFactory;

//        public CategoryRepository(IDbContextFactory<CatagoryContext> contextFactory)
//        {
//            _contextFactory = contextFactory;
//        }

//        public async Task<List<Category>> Get()
//        {
//            using (var context = _contextFactory.CreateDbContext())
//            {
//                return await context.Categories.ToListAsync();
//            }
//        }
//    }
//}