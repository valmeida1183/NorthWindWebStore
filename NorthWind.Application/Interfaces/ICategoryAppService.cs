using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Application.Interfaces
{
    public interface ICategoryAppService : IDisposable
    {
        ExpandoObject GetAll();
    }
}
