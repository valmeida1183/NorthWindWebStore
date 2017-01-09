using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Domain.Entities;
using Infra.Data.Context;

namespace NorthWind.WebService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly NorthWindContext nortWindContext;

        public ValuesController(NorthWindContext nortWindContext)
        {
            this.nortWindContext = nortWindContext;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            using (var db = nortWindContext)
            {
                var result = db.Categories.ToList();
                return result;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
