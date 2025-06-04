using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTek86.model
{
    /// <summary>
    /// Classe métier interne pour mémoriser les informations d’authentification d’un responsable.
    /// </summary>
    public class Responsable
    {
        /// <summary>
        /// Login du responsable (identifiant pour la connexion).
        /// </summary>
        public string Login { get; }

        /// <summary>
        /// Mot de passe du responsable (en clair avant le hachage dans la requête SQL).
        /// </summary>
        public string Pwd { get; }

        /// <summary>
        /// Initialise une nouvelle instance de <see cref="Responsable"/> avec les informations de connexion.
        /// </summary>
        /// <param name="login">Chaîne correspondant au login du responsable.</param>
        /// <param name="pwd">Chaîne correspondant au mot de passe du responsable.</param>
        public Responsable(string login, string pwd)
        {
            this.Login = login;
            this.Pwd = pwd;
        }
    }
}