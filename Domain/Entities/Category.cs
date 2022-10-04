using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Classe Category représentant une catégorie sur le forum
    /// </summary>
    public class Category : Entity
    {
        /// <summary>
        /// Propriété du nom de la catégorie
        /// </summary>
        public string Name { get; set; }
    }
}
