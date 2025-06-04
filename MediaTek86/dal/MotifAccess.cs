using MediaTek86.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTek86.dal
{
    /// <summary>
    /// Accès aux données pour la table "motif" : récupération et gestion des motifs d’absences.
    /// </summary>
    public class MotifAccess
    {
        /// <summary>
        /// Instance unique de l’accès aux données (singleton pour la connexion).
        /// </summary>
        private readonly Access access = null;

        /// <summary>
        /// Initialise une nouvelle instance de <see cref="MotifAccess"/> et obtient l’instance d’accès aux données.
        /// </summary>
        public MotifAccess()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Récupère et retourne la liste de tous les motifs d’absence en base.
        /// </summary>
        /// <returns>
        /// Liste d’objets <see cref="Motif"/> correspondant à tous les enregistrements
        /// de la table "motif", triés par libellé.
        /// </returns>
        public List<Motif> GetLesMotifs()
        {
            List<Motif> lesMotifs = new List<Motif>();
            if (access.Manager != null)
            {
                // On récupère toutes les colonnes de la table "motif" (idmotif, libelle)
                string req = "select * from motif order by libelle;";
                try
                {
                    List<object[]> records = access.Manager.ReqSelect(req);
                    if (records != null)
                    {
                        foreach (object[] record in records)
                        {
                            // record[0] => idmotif, record[1] => libelle
                            Motif motif = new Motif((int)record[0], (string)record[1]);
                            // Propriété CodeMotif initialisée à string.Empty par le constructeur de Motif

                            lesMotifs.Add(motif);
                        }
                    }
                }
                catch (Exception e)
                {
                    // En cas d’erreur, on affiche le message et termine l’application
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
            return lesMotifs;
        }
    }
}