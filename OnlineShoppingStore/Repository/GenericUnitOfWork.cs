using OnlineShoppingStore.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Repository
{
    public class GenericUnitOfWork : IDisposable
    {
        private ShoppingStoreEntities DBEntity = new ShoppingStoreEntities();

        /// <summary>
        /// Gets the repository instance.
        /// </summary>
        /// <typeparam name="EntityType">The type of the ntity type.</typeparam>
        /// <returns></returns>
        public IRepository<EntityType> GetRepositoryInstance<EntityType>() where EntityType : class
        {
            return new GenericRepository<EntityType>(DBEntity);
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void  SaveChanges()
        {
            DBEntity.SaveChanges();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DBEntity.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
    }
}