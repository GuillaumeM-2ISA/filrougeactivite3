using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.UOW.Repositories
{
    public interface ITopicRepository : IGenericRepository<Topic>
    {
        /// <summary>
        /// Méthode récupérant tous les sujets associé à une catégorie spécifique
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<IEnumerable<Topic>> GetTopicsByCategoryIdAsync(int categoryId);
    }
}