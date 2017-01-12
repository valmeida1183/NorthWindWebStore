using System.Dynamic;

namespace NorthWind.Application.Interfaces
{
    public interface ICategoryAppService
    {
        ExpandoObject GetAll();
        ExpandoObject GetById(int id);
        ExpandoObject Add(ExpandoObject category);
    }
}
