using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Classe Member représentant un membre sur le forum
    /// </summary>
    public class Member : Entity
    {
        /// <summary>
        /// Propriété du pseudonyme du membre
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Propriété du type du membre
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Propriété de l'adresse email du membre
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Propriété du mot de passe du membre
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Propriété de la date de création du membre
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Propriété de la date de mise à jour du membre
        /// </summary>
        public DateTime UpdateAt { get; set; }
    }
}
