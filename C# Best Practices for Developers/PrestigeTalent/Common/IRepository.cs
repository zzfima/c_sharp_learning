using System.Collections.Generic;

namespace Common
{
    /// <summary>
    /// CRUD interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Add Entity to repository
        /// </summary>
        /// <param name="entity">entity to add</param>
        void Add(T entity);

        /// <summary>
        /// Read repository Entity
        /// </summary>
        IEnumerable<T> ReadAll();

        /// <summary>
        /// Update Entity of repository
        /// </summary>
        /// <param name="entity">entity to update</param>
        void Update(T oldEntity, T newEntity);

        /// <summary>
        /// Remove Entity from repository
        /// </summary>
        /// <param name="entity">entity to remove</param>
        void Remove(T entity);
    }
}
