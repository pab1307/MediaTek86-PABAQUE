using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTek86.model
{
    /// <summary>
    /// classe métier interne pour mémoriser les motifs d'absences
    /// (correspond à la table "motif" en base : colonnes idmotif, libelle)
    /// </summary>
    public class Motif
    {
        /// <summary>
        /// Identifiant unique du motif (colonne idmotif)
        /// </summary>
        public int Idmotif { get; }

        /// <summary>
        /// Libellé du motif (colonne libelle)
        /// </summary>
        public string Libelle { get; }

        /// <summary>
        /// Code libre du motif (propriété additionnelle, non persistée)
        /// </summary>
        public string CodeMotif { get; set; }

        /// <summary>
        /// Date de création/instanciation de l'objet Motif
        /// </summary>
        public DateTime DateCreation { get; private set; }

        /// <summary>
        /// Indique si ce motif est considéré comme un congé payé
        /// (exemple : "vacances", "congé parental", etc.)
        /// </summary>
        public bool EstCongePayé { get; set; }

        /// <summary>
        /// Initialise un nouveau motif avec son identifiant et son libellé.
        /// </summary>
        /// <param name="idmotif">Identifiant du motif</param>
        /// <param name="libelle">Libellé du motif</param>
        public Motif(int idmotif, string libelle)
        {
            this.Idmotif = idmotif;
            this.Libelle = libelle ?? throw new ArgumentNullException(nameof(libelle));
            this.CodeMotif = string.Empty;
            this.DateCreation = DateTime.Now;
            this.EstCongePayé = DetermineSiCongéPayé(libelle);
        }

        /// <summary>
        /// Détermine, à partir du libellé, si ce motif est un congé payé.
        /// </summary>
        /// <param name="libelle">Le libellé du motif</param>
        /// <returns>True si le motif est considéré comme congé payé, false sinon.</returns>
        private bool DetermineSiCongéPayé(string libelle)
        {
            if (string.IsNullOrWhiteSpace(libelle))
                return false;

            // On suppose que les libellés contenant "vacances", "congé parental", "congé payé" sont des congés payés
            string l = libelle.ToLowerInvariant();
            return l.Contains("vacances")
                   || l.Contains("congé parental")
                   || l.Contains("congé payé");
        }

        /// <summary>
        /// Renvoie une version abrégée du libellé (par exemple, 10 premiers caractères).
        /// </summary>
        public string LibelleCourt
        {
            get
            {
                const int max = 10;
                if (string.IsNullOrEmpty(Libelle))
                    return string.Empty;
                return Libelle.Length <= max ? Libelle : Libelle.Substring(0, max) + "...";
            }
        }

        /// <summary>
        /// Renvoie le "type" de motif : "Congé" ou "Autre"
        /// </summary>
        /// <returns>Chaîne décrivant le type de motif</returns>
        public string GetTypeMotif()
        {
            return EstCongePayé ? "Congé" : "Autre";
        }

        /// <summary>
        /// Fournit une représentation textuelle détaillée du motif
        /// </summary>
        /// <returns>Chaîne contenant l'ID, le libellé, et éventuellement le code</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"[#{Idmotif}] {Libelle}");
            if (!string.IsNullOrEmpty(CodeMotif))
            {
                sb.Append($" (Code:{CodeMotif})");
            }
            sb.Append($" - Créé le {DateCreation:yyyy-MM-dd}");
            return sb.ToString();
        }

        /// <summary>
        /// Détermine si deux objets Motif sont égaux (même Idmotif et même Libelle)
        /// </summary>
        /// <param name="obj">L’objet à comparer</param>
        /// <returns>True si identiques, false sinon</returns>
        public override bool Equals(object obj)
        {
            if (obj is Motif other)
            {
                return this.Idmotif == other.Idmotif
                    && string.Equals(this.Libelle, other.Libelle, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        /// <summary>
        /// Calcul du hashcode basé sur l'identifiant et le libellé
        /// </summary>
        /// <returns>Valeur de hash</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Idmotif.GetHashCode();
                hash = hash * 23 + (Libelle?.ToLowerInvariant().GetHashCode() ?? 0);
                return hash;
            }
        }
    }
}