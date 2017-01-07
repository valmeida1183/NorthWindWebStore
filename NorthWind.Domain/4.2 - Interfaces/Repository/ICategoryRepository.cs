using NorthWind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Domain.Interfaces.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
    }
}
