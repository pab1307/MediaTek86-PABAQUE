using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTek86.model
{
    /// <summary>
    /// classe métier interne pour mémoriser les informations sur le service
    /// (table "service" en base)
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Identifiant interne du service (colonne idservice)
        /// </summary>
        public int Idservice { get; }

        /// <summary>
        /// Nom (libellé) du service (colonne nom)
        /// </summary>
        public string Nom { get; }

        /// <summary>
        /// Code optionnel du service (nouvelle propriété)
        /// </summary>
        public string CodeService { get; set; }

        /// <summary>
        /// Initialise les propriétés du service
        /// </summary>
        /// <param name="idservice">Identifiant unique du service</param>
        /// <param name="nom">Libellé du service</param>
        public Service(int idservice, string nom)
        {
            this.Idservice = idservice;
            this.Nom = nom;
            // Par défaut, CodeService est initialisé à une chaîne vide
            this.CodeService = string.Empty;
        }

        /// <summary>
        /// Affiche le nom (libellé) du service (utile dans les listes déroulantes)
        /// </summary>
        /// <returns>Nom du service</returns>
        public override string ToString()
        {
            return this.Nom;
        }
    }
}