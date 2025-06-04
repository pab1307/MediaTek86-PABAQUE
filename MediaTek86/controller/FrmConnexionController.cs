using MediaTek86.dal;
using MediaTek86.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTek86.controller
{
    /// <summary>
    /// contrôleur de FrmConnexion
    /// </summary>
    class FrmConnexionController
    {
        /// <summary>
        /// objet d'accès aux opérations possibles sur Personnel
        /// </summary>
        private readonly PersonnelAccess personnelAccess;

        /// <summary>
        /// récupère l'accès aux données
        /// </summary>
        public FrmConnexionController()
        {
            personnelAccess = new PersonnelAccess();
        }

        /// <summary>
        /// vérifie la connexion
        /// </summary>
        /// <param name="responsable">objet contenant les informations de connection</param>
        /// <returns>vrai si les informations de connection sont correctes</returns>
        public Boolean ControleConnexion(Responsable responsable)
        {
            return personnelAccess.ControleConnexion(responsable);
        }
    }
}
