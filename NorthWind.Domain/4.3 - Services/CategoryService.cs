using NorthWind.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthWind.Domain.Entities;
using NorthWind.Domain.Interfaces.Repository;

namespace NorthWind.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        
        public IEnumerable<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }
    }
}
