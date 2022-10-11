using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.UOW.Repositories
{
    public interface IResponseRepository : IGenericRepository<Response>
    {
        /// <summary>
        /// Méthode récupérant toutes les réponses associé à un sujet spécifique
        /// </summary>
        /// <param name="topicId"></param>
        /// <returns></returns>
        Task<IEnumerable<Response>> GetResponsesByTopicIdAsync(int topicId);

        /// <summary>
        /// Méthode supprimant toutes les réponses associé à un sujet spécifique
        /// </summary>
        /// <param name="topicId"></param>
        /// <returns></returns>
        Task<bool> DeleteByTopicIdAsync(int topicId);
    }
}