using System.Dynamic;

namespace NorthWind.Application.Interfaces
{
    public interface ICategoryAppService
    {
        ExpandoObject GetAll();
    }
}
