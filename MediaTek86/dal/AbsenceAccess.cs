using MediaTek86.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTek86.dal
{
    /// <summary>
    /// classe permettant de gérer les demandes concernant les absences
    /// </summary>
    public class AbsenceAccess
    {
        /// <summary>
        /// Date de début avant modification (stockée temporairement par StockageDates)
        /// </summary>
        public DateTime DateDebutAvant;

        /// <summary>
        /// Date de fin avant modification (stockée temporairement par StockageDates)
        /// </summary>
        public DateTime DateFinAvant;

        /// <summary>
        /// instance unique de l'accès aux données
        /// </summary>
        private readonly Access access = null;

        /// <summary>
        /// constructeur pour créer l'accès aux données
        /// </summary>
        public AbsenceAccess()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// récupère et retourne la liste des absences pour un personnel donné
        /// </summary>
        /// <param name="id">identifiant du personnel (clé primaire table "personnel")</param>
        /// <returns>liste des absences</returns>
        public List<Absence> GetLesAbsences(int id)
        {
            List<Absence> lesAbsences = new List<Absence>();
            if (access.Manager != null)
            {
                // On récupère : idpersonnel, datedebut, datefin, idmotif et libellé du motif
                string req =
                    "select a.idpersonnel as idpersonnel, " +
                           "a.datedebut as datedebut, " +
                           "a.datefin as datefin, " +
                           "m.idmotif as idmotif, " +
                           "m.libelle as motif " +
                    "from absence a " +
                    "join motif m on (a.idmotif = m.idmotif) " +
                    "where a.idpersonnel = @idpersonnel " +
                    "order by a.datefin desc;";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@idpersonnel", id }
                };
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req, parameters);
                    if (records != null)
                    {
                        foreach (Object[] record in records)
                        {
                            // Vérification et conversion des dates
                            if (record[1] is DateTime datedebut && record[2] is DateTime datefin)
                            {
                                // record[3] => idmotif, record[4] => libellé du motif
                                Motif motif = new Motif((int)record[3], (string)record[4]);
                                // On crée une Absence avec (idpersonnel, datedebut, datefin, motif)
                                Absence uneAbsence = new Absence(
                                    (int)record[0],
                                    datedebut,
                                    datefin,
                                    motif
                                );
                                lesAbsences.Add(uneAbsence);
                            }
                            else
                            {
                                Console.WriteLine("Erreur de conversion des dates dans GetLesAbsences.");
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
            return lesAbsences;
        }

        /// <summary>
        /// demande de suppression d'une absence
        /// </summary>
        /// <param name="absence">objet Absence à supprimer</param>
        public void DelAbsence(Absence absence)
        {
            if (access.Manager != null)
            {
                string req =
                    "delete from absence " +
                    "where idpersonnel = @idpersonnel " +
                    "  and datedebut = @datedebut " +
                    "  and datefin = @datefin;";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@idpersonnel", absence.Idpersonnel },
                    { "@datedebut", absence.Datedebut },
                    { "@datefin", absence.Datefin }
                };
                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// demande d'ajout d'une absence
        /// </summary>
        /// <param name="absence">objet Absence à ajouter</param>
        public void AddAbsence(Absence absence)
        {
            if (access.Manager != null)
            {
                string req =
                    "insert into absence(idpersonnel, datedebut, datefin, idmotif) " +
                    "values (@idpersonnel, @datedebut, @datefin, @idmotif);";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@idpersonnel", absence.Idpersonnel },
                    { "@datedebut", absence.Datedebut },
                    { "@datefin", absence.Datefin },
                    { "@idmotif", absence.Motif.Idmotif }
                };
                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// stocke temporairement les anciennes dates (avant modification) pour pouvoir faire un WHERE sur ces colonnes
        /// </summary>
        /// <param name="dateDebut">ancienne date de début</param>
        /// <param name="dateFin">ancienne date de fin</param>
        public void StockageDates(DateTime dateDebut, DateTime dateFin)
        {
            DateDebutAvant = dateDebut;
            DateFinAvant = dateFin;
        }

        /// <summary>
        /// demande de modification d'une absence
        /// </summary>
        /// <param name="absence">objet Absence à modifier</param>
        public void UpdateAbsence(Absence absence)
        {
            if (access.Manager != null)
            {
                string req =
                    "update absence set " +
                        "idpersonnel = @idpersonnel, " +
                        "datedebut   = @datedebut, " +
                        "datefin     = @datefin, " +
                        "idmotif     = @idmotif " +
                    "where idpersonnel = @idpersonnel " +
                    "  and datedebut   = @datedebutavant " +
                    "  and datefin     = @datefinavant;";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@idpersonnel",      absence.Idpersonnel },
                    { "@datedebut",        absence.Datedebut },
                    { "@datefin",          absence.Datefin },
                    { "@idmotif",          absence.Motif.Idmotif },
                    { "@datedebutavant",   DateDebutAvant },
                    { "@datefinavant",     DateFinAvant }
                };
                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
        }
    }
}