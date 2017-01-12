using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Domain.Entities;
using Infra.Data.Context;
using NorthWind.Application.Interfaces;
using System.Dynamic;

namespace NorthWind.WebService.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryAppService categoryAppService;
        
        public CategoriesController(ICategoryAppService categoryAppService)
        {
            this.categoryAppService = categoryAppService;
        }

        // GET api/categories
        [HttpGet]
        public IActionResult Get()
        {               
            dynamic expando = categoryAppService.GetAll();

            if (expando.categories != null && expando.categories.Count <= 0)
            {
                return NoContent();
            }
                        
            return Ok(expando);                        
        }

        // GET api/categories/5
        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            dynamic expando = categoryAppService.GetById(id);

            if (expando.category == null)
            {
                return NoContent();
            }
            return Ok(expando);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] ExpandoObject category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            dynamic expando = categoryAppService.Add(category);

            return CreatedAtRoute("GetCategory", new { id = expando.category.CategoryId }, expando);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
