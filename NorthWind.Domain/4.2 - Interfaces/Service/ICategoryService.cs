using NorthWind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Domain.Interfaces.Service
{
    public interface ICategoryService : IDisposable
    {
        IEnumerable<Category> GetAll();
    }
}
