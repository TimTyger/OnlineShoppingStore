using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace OnlineShoppingStore.Repository
{
    public interface IRepository<Entity> where Entity:class
    {
        /// <summary>
        /// Gets all records.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Entity> GetAllRecords();

        IEnumerable<Entity> GetRecordsToShow(int PageNo, int PageSize, int CurrentPage, Expression<Func<Entity, bool>>wherePredict, Expression<Func<Entity, int>> OrderByPredict);

        
        /// <summary>
        /// Gets all records count.
        /// </summary>
        /// <returns></returns>
        int GetAllRecordsCount();

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(Entity entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(Entity entity);

        /// <summary>
        /// Updates the by where clause.
        /// </summary>
        /// <param name="wherePredict">The where predict.</param>
        /// <param name="ForEachPredictt">For each predictt.</param>
        void UpdateByWhereClause(Expression<Func<Entity, bool>> wherePredict, Action<Entity> ForEachPredictt);

        /// <summary>
        /// Gets the firstor default.
        /// </summary>
        /// <param name="recordId">The record identifier.</param>
        /// <returns></returns>
        Entity GetFirstorDefault(int recordId);

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Remove(Entity entity);

        /// <summary>
        /// Removes the by where clause.
        /// </summary>
        /// <param name="wherePredict">The where predict.</param>
        void RemoveByWhereClause(Expression<Func<Entity, bool>> wherePredict);

        /// <summary>
        /// Removeranges the by where clause.
        /// </summary>
        /// <param name="wherePredict">The where predict.</param>
        void RemoverangeByWhereClause(Expression<Func<Entity, bool>> wherePredict);

        /// <summary>
        /// Inactives the and delete mark by where clause.
        /// </summary>
        /// <param name="wherePredict">The where predict.</param>
        /// <param name="ForEachPredict">For each predict.</param>
        void InactiveAndDeleteMarkByWhereClause(Expression<Func<Entity, bool>> wherePredict, Action<Entity> ForEachPredict);

        /// <summary>
        /// Gets the firstor default by parameter.
        /// </summary>
        /// <param name="wherePredict">The where predict.</param>
        /// <returns></returns>
        Entity GetFirstorDefaultByParameter(Expression<Func<Entity, bool>> wherePredict);

        /// <summary>
        /// Gets the list parameter.
        /// </summary>
        /// <param name="wherePredict">The where predict.</param>
        /// <returns></returns>
        IEnumerable<Entity> GetListParameter(Expression<Func<Entity, bool>> wherePredict);

        /// <summary>
        /// Gets the list by SQL procedure.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        IEnumerable<Entity> GetListBySqlProcedure(string query, params object[] parameters);
    }
}