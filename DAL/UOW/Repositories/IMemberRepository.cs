using Domain.Entities;
using System.Threading.Tasks;

namespace DAL.UOW.Repositories
{
    public interface IMemberRepository : IGenericRepository<Member>
    {
        /// <summary>
        /// Méthode vérifiant que l'on puisse obtenir le membre par son pseudonyme
        /// </summary>
        /// <param name="nickname"></param>
        /// <returns></returns>
        Task<bool> IsGettableByNicknameAsync(string nickname);

        /// <summary>
        /// Méthode vérifiant que l'on puisse obtenir le membre par son adresse email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<bool> IsGettableByEmailAsync(string email);

        /// <summary>
        /// Méthode récupérant le membre par son pseudonyme et son mot de passe
        /// </summary>
        /// <param name="nickname"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<Member> GetByNicknameAndPasswordAsync(string nickname, string password);

        /// <summary>
        /// Méthode mettant à jour le mot de passe du membre
        /// </summary>
        /// <param name="memberModified"></param>
        /// <returns></returns>
        Task<Member> UpdatePasswordAsync(Member memberModified);
    }
}