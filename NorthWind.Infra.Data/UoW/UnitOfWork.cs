using Infra.Data.Context;
using NorthWind.Infra.Data.Interface;
using System;

namespace NorthWind.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NorthWindContext context;
        private bool disposed;

        public UnitOfWork(NorthWindContext context)
        {
            this.context = context;
        }

        public void BeginTransaction()
        {
            disposed = false;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            // não é obrigatório, significa que o esta classe está etiquetada como "para ser removida". 
            // Quando o GC passar esta classe já está marcada para ser removida, caso contrário ele primeiro marcaria para ser removida.
            // e posteriormente o GC em outro ciclo removeria da memória.
        }
    }
}
