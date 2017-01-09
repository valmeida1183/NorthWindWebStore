using NorthWind.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using NorthWind.Domain.Interfaces.Service;

namespace NorthWind.Application.Services
{
    public class CategoryAppService : ApplicationService, ICategoryAppService
    {
        private readonly ICategoryService categoryService;
        public CategoryAppService(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExpandoObject> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
