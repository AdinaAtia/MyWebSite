using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryServices : ICategoryServices
    {
        ICategoryRepository repository;
        public CategoryServices(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Category>> Get()
        {
            return await repository.Get();
        }
        //public async Task<Category> GetById(int id)
        //{
        //    return await repository.GetById(id);
        //}

    }
}
