using OnlineShoppingStore.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace OnlineShoppingStore.Repository
{
    public class GenericRepository<Entity> : IRepository<Entity> where Entity : class
    {
        /// <summary>
        /// The dbset
        /// </summary>
        DbSet<Entity> dbset;

        /// <summary>
        /// The database entites
        /// </summary>
        private ShoppingStoreEntities DBEntity;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{Entity}"/> class.
        /// </summary>
        /// <param name="dbEntity">The database entity.</param>
        public GenericRepository(ShoppingStoreEntities dbEntity)
        {
            DBEntity = dbEntity;
            dbset = DBEntity.Set<Entity>();
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(Entity entity)
        {
            dbset.Add(entity);
            DBEntity.SaveChanges();

        }

        /// <summary>
        /// Gets all records.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Entity> GetAllRecords()
        {
            return dbset.ToList();
        }

        /// <summary>
        /// Gets all records count.
        /// </summary>
        /// <returns></returns>
        public int GetAllRecordsCount()
        {
            return dbset.Count();
        }

       

        /// <summary>
        /// Gets the firstor default.
        /// </summary>
        /// <param name="recordId">The record identifier.</param>
        /// <returns></returns>
        public Entity GetFirstorDefault(int recordId)
        {
            return dbset.Find(recordId);
        }

        /// <summary>
        /// Gets the firstor default by parameter.
        /// </summary>
        /// <param name="wherePredict">The where predict.</param>
        /// <returns></returns>
        public Entity GetFirstorDefaultByParameter(Expression<Func<Entity, bool>> wherePredict)
        {
            return dbset.Where(wherePredict).FirstOrDefault();
        }

        /// <summary>
        /// Gets the list by SQL procedure.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public IEnumerable<Entity> GetListBySqlProcedure(string query, params object[] parameters)
        {
            if (parameters != null)
            {
                return DBEntity.Database.SqlQuery<Entity>(query, parameters).ToList();
            }
            else
            {
                return DBEntity.Database.SqlQuery<Entity>(query).ToList();
            }
        }

        /// <summary>
        /// Gets the list parameter.
        /// </summary>
        /// <param name="wherePredict">The where predict.</param>
        /// <returns></returns>
        public IEnumerable<Entity> GetListParameter(Expression<Func<Entity, bool>> wherePredict)
        {
            return dbset.Where(wherePredict).ToList();
        }

        /// <summary>
        /// Gets the records to show.
        /// </summary>
        /// <param name="PageNo">The page no.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="CurrentPage">The current page.</param>
        /// <param name="wherePredict">The where predict.</param>
        /// <param name="OrderByPredict">The order by predict.</param>
        /// <returns></returns>
        public IEnumerable<Entity> GetRecordsToShow(int PageNo, int PageSize, int CurrentPage, Expression<Func<Entity, bool>> wherePredict, Expression<Func<Entity, int>> OrderByPredict)
        {
            if (wherePredict != null)
            {
                return dbset.OrderBy(OrderByPredict).Where(wherePredict).ToList();
            }
            else
            {
                return dbset.OrderBy(OrderByPredict).ToList();
            }
        }

        /// <summary>
        /// Inactives the and delete mark by where clause.
        /// </summary>
        /// <param name="wherePredict">The where predict.</param>
        /// <param name="ForEachPredict">For each predict.</param>
        public void InactiveAndDeleteMarkByWhereClause(Expression<Func<Entity, bool>> wherePredict, Action<Entity> ForEachPredict)
        {
           dbset.Where(wherePredict).ToList().ForEach(ForEachPredict);
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(Entity entity)
        {
            if (DBEntity.Entry(entity).State == EntityState.Detached)
            {
                dbset.Attach(entity);

            }
            dbset.Remove(entity);
            //DBEntity.SaveChanges();
        }

        /// <summary>
        /// Removes the by where clause.
        /// </summary>
        /// <param name="wherePredict">The where predict.</param>
        public void RemoveByWhereClause(Expression<Func<Entity, bool>> wherePredict)
        {
            Entity entity = dbset.Where(wherePredict).FirstOrDefault();
            Remove(entity);
        }

        /// <summary>
        /// Removeranges the by where clause.
        /// </summary>
        /// <param name="wherePredict">The where predict.</param>
        public void RemoverangeByWhereClause(Expression<Func<Entity, bool>> wherePredict)
        {
            List<Entity> entity = dbset.Where(wherePredict).ToList();
            foreach(var ent in entity)
            {
                Remove(ent);
            }

            
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(Entity entity)
        {
            dbset.Attach(entity);
            DBEntity.Entry(entity).State = EntityState.Modified;
            DBEntity.SaveChanges();
        }

        public void UpdateByWhereClause(Expression<Func<Entity, bool>> wherePredict, Action<Entity> ForEachPredictt)
        {
            dbset.Where(wherePredict).ToList().ForEach(ForEachPredictt);
        }
    }
}