using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLLS
{
    interface IForumService
    {
        /// <summary>
        /// Ajouter une réponse
        /// </summary>
        /// <param name="newResponse"></param>
        /// <returns></returns>
        Task<Response> AddResponseAsync(Response newResponse);

        /// <summary>
        /// Ajouter un sujet
        /// </summary>
        /// <param name="newTopic"></param>
        /// <returns></returns>
        Task<Topic> AddTopicAsync(Topic newTopic);

        /// <summary>
        /// Supprimer une réponse
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteResponseAsync(int id);

        /// <summary>
        /// Supprimer un sujet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteTopicAsync(int id);

        /// <summary>
        /// Obtenir toutes les catégories
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Category>> GetCategoriesAsync();

        /// <summary>
        /// Obtenir une réponse par son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Response> GetResponseByIdAsync(int id);

        /// <summary>
        /// Obtenir toutes les réponses
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Response>> GetResponsesAsync();

        /// <summary>
        /// Obtenir toutes les réponses par son sujet
        /// </summary>
        /// <param name="topicId"></param>
        /// <returns></returns>
        Task<IEnumerable<Response>> GetResponsesByTopicIdAsync(int topicId);

        /// <summary>
        /// Obtenir un sujet par son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Topic> GetTopicByIdAsync(int id);

        /// <summary>
        /// Obtenir tous les sujets
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Topic>> GetTopicsAsync();

        /// <summary>
        /// Obtenir tous les sujets par sa categorie
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<IEnumerable<Topic>> GetTopicsByCategoryIdAsync(int categoryId);

        /// <summary>
        /// Modifier un sujet
        /// </summary>
        /// <param name="modifiedTopic"></param>
        /// <returns></returns>
        Task<Topic> ModifyTopicAsync(Topic modifiedTopic);
    }
}