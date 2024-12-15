using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        CatagoryContext Manger_DB_context;
        public CategoryRepository(CatagoryContext Manger_DB_context)
        {
            this.Manger_DB_context = Manger_DB_context;
        }
        public async Task<List<Category>> Get()
        {
            //List<Category> category = 
                return await Manger_DB_context.Categories.ToListAsync();
            //return category;
        }
        //public async Task<Category> GetById(int id)
        //{
        //    Category category = await Manger_DB_context.Categories.FirstOrDefaultAsync(currentCategory => currentCategory.Id == id);
        //    return category;
        //}
    }
}

