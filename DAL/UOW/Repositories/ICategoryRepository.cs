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
    }
}