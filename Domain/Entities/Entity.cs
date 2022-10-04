using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Classe abstraite représentant les entités
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Propriété de l'id des entités
        /// </summary>
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Entity entity &&
                   Id == entity.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
