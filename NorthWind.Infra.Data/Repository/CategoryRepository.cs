using NorthWind.Domain.Entities;
using NorthWind.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Infra.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

    }
}
