using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.UOW.Repositories
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Méthode récupérant toutes les catégories
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Category>> GetAllAsync();

        /// <summary>
        /// Méthode récupérant une catégorie spécifique par son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Category> GetByIdAsync(int id);
    }
}