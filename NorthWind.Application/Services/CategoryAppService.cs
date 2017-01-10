using NorthWind.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using NorthWind.Domain.Interfaces.Service;
using NorthWind.Domain.Entities;
using AutoMapper;

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
            categoryService.Dispose();
            GC.SuppressFinalize(this);
        }

        public ExpandoObject GetAll()
        {
            // var result = Mapper.Map<IEnumerable<Category>, IEnumerable<DynamicObject>>(categoryService.GetAll());
            //var result2 = Mapper.Map<IEnumerable<DynamicObject>>(categoryService.GetAll());
            dynamic test = new ExpandoObject();
            test.categoryList = categoryService.GetAll();
            //dynamic test = categoryService.GetAll();
            return test;
        }
    }
}
