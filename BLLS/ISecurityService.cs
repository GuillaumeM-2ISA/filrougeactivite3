using System.Threading.Tasks;

namespace BLLS
{
    public interface ISecurityService
    {
        /// <summary>
        /// Renvoie le token généré par le serveur
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<string> SigninAsync(string username, string password);
    }
}