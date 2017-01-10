using System;

namespace NorthWind.Infra.Data.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
    }
}
