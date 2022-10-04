using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW.Repositories
{
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// Méthode récupérant toutes les entités d'un type spécifique
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Méthode récupérant l'entité d'un type spécifique
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Méthode ajoutant une entité d'un type spécifique
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);
        
        /// <summary>
        /// Méthode modifiant une entité d'un type spécifique
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Méthode supprimant une entité d'un type spécifique
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);
    }
}
