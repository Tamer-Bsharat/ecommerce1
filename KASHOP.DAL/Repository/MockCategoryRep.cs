using KASHOP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Repository
{
    internal class MockCategoryRep : ICategoryRepository
    {
        public Category Create(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Category> CreateAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
