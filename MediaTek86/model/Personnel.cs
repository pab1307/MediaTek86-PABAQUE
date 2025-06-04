using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTek86.model
{
    /// <summary>
    /// classe métier interne pour mémoriser les informations du personnel
    /// (table "personnel" en base)
    /// </summary>
    public class Personnel
    {
        /// <summary>
        /// Initialise les propriétés du personnel
        /// </summary>
        /// <param name="idpersonnel">Identifiant unique du personnel (clé primaire table "personnel")</param>
        /// <param name="nom">Nom du personnel</param>
        /// <param name="prenom">Prénom du personnel</param>
        /// <param name="tel">Numéro de téléphone</param>
        /// <param name="mail">Adresse e-mail</param>
        /// <param name="service">Objet Service associé (table "service")</param>
        public Personnel(int idpersonnel, string nom, string prenom, string tel, string mail, Service service)
        {
            this.Idpersonnel = idpersonnel;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Tel = tel;
            this.Mail = mail;
            this.Service = service;
            // Par défaut, CodePersonnel est initialisé à une chaîne vide
            this.CodePersonnel = string.Empty;
        }

        /// <summary>
        /// Identifiant interne du personnel (colonne idpersonnel)
        /// </summary>
        public int Idpersonnel { get; }

        /// <summary>
        /// Nom du personnel
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prénom du personnel
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Téléphone du personnel
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// Email du personnel
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Objet Service auquel appartient le personnel (correspond à la table "service")
        /// </summary>
        public Service Service { get; set; }

        /// <summary>
        /// Code optionnel du personnel (nouvelle propriété)
        /// </summary>
        public string CodePersonnel { get; set; }
    }
}