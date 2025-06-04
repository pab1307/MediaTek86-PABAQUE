using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTek86.model
{
    /// <summary>
    /// classe métier interne pour mémoriser les absences
    /// </summary>
    public class Absence
    {
        /// <summary>
        /// Initialise les propriétés de l’absence
        /// </summary>
        /// <param name="idpersonnel">Identifiant du personnel concerné</param>
        /// <param name="datedebut">Date de début de l’absence</param>
        /// <param name="datefin">Date de fin de l’absence</param>
        /// <param name="motif">Motif associé à l’absence</param>
        public Absence(int idpersonnel, DateTime datedebut, DateTime datefin, Motif motif)
        {
            this.Idpersonnel = idpersonnel;
            this.Datedebut = datedebut;
            this.Datefin = datefin;
            this.Motif = motif;
            // Propriétés additionnelles initialisées par défaut
            this.Commentaire = string.Empty;
        }

        /// <summary>
        /// Identifiant du personnel (colonne idpersonnel)
        /// </summary>
        public int Idpersonnel { get; }

        /// <summary>
        /// Date de début de l’absence (colonne datedebut)
        /// </summary>
        public DateTime Datedebut { get; set; }

        /// <summary>
        /// Date de fin de l’absence (colonne datefin)
        /// </summary>
        public DateTime Datefin { get; set; }

        /// <summary>
        /// Motif de l’absence (objet lié à la table motif)
        /// </summary>
        public Motif Motif { get; set; }

        /// <summary>
        /// Commentaire libre associé à l’absence (nouvelle propriété)
        /// </summary>
        public string Commentaire { get; set; }

        /// <summary>
        /// Durée calculée de l’absence en jours (propriété calculée)
        /// </summary>
        public int DureeEnJours
        {
            get
            {
                // Si la date de fin est antérieure à la date de début, renvoyer 0
                if (Datefin < Datedebut)
                    return 0;
                return (Datefin.Date - Datedebut.Date).Days + 1;
            }
        }

        /// <summary>
        /// Fournit un résumé textuel de l’absence
        /// </summary>
        /// <returns>Chaîne formatée</returns>
        public override string ToString()
        {
            return $"Absence [IDPers={Idpersonnel}] du {Datedebut:yyyy-MM-dd} au {Datefin:yyyy-MM-dd} " +
                   $"(Motif: {Motif?.Libelle ?? "inconnu"}, Durée: {DureeEnJours} jour(s))";
        }
    }
}