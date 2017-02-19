using Microsoft.AspNetCore.Mvc;
using NorthWind.Application.Interfaces;
using System.Dynamic;

namespace NorthWind.WebService.Controllers
{
    /* This Controller uses ExpandoObject Approach + DynamicMap */

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
                        
            return Ok(expando.categories);                        
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
                return NotFound();
            }
            return Ok(expando.category);
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

            if (!expando.category.ValidationResult.IsValid)
            {
                return BadRequest(expando.category);
            }

            return CreatedAtRoute("GetCategory", new { id = expando.category.CategoryId }, expando);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] ExpandoObject category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            dynamic expando = categoryAppService.Update(category);
            if (!expando.category.ValidationResult.IsValid)
            {
                return BadRequest(expando.category);
            }

            return NoContent();
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            if (categoryAppService.Remove(id))
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
