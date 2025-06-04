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
    /// Contrôleur de FrmAbsences, gère les appels à la couche DAL pour les absences et les motifs.
    /// </summary>
    public class FrmAbsencesController
    {
        /// <summary>
        /// Objet d'accès aux opérations possibles sur Absence.
        /// </summary>
        private readonly AbsenceAccess absenceAccess;

        /// <summary>
        /// Objet d'accès aux opérations possibles sur Motif.
        /// </summary>
        private readonly MotifAccess motifAccess;

        /// <summary>
        /// Initialise une nouvelle instance de <see cref="FrmAbsencesController"/>, 
        /// en configurant les accès aux données pour les absences et les motifs.
        /// </summary>
        public FrmAbsencesController()
        {
            absenceAccess = new AbsenceAccess();
            motifAccess = new MotifAccess();
        }

        /// <summary>
        /// Retourne la liste des absences pour le personnel identifié par <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Identifiant du personnel dont on souhaite récupérer les absences.</param>
        /// <returns>Liste d’objets <see cref="Absence"/> associés à ce personnel.</returns>
        public List<Absence> GetLesAbsences(int id)
        {
            return absenceAccess.GetLesAbsences(id);
        }

        /// <summary>
        /// Retourne la liste de tous les motifs d’absence.
        /// </summary>
        /// <returns>Liste d’objets <see cref="Motif"/> représentant tous les motifs disponibles.</returns>
        public List<Motif> GetLesMotifs()
        {
            return motifAccess.GetLesMotifs();
        }

        /// <summary>
        /// Demande la suppression d’une absence spécifiée.
        /// </summary>
        /// <param name="absence">Instance de <see cref="Absence"/> à supprimer.</param>
        public void DelAbsence(Absence absence)
        {
            absenceAccess.DelAbsence(absence);
        }

        /// <summary>
        /// Demande l’ajout d’une nouvelle absence.
        /// </summary>
        /// <param name="absence">Instance de <see cref="Absence"/> à ajouter.</param>
        public void AddAbsence(Absence absence)
        {
            absenceAccess.AddAbsence(absence);
        }

        /// <summary>
        /// Demande la mise à jour d’une absence existante.
        /// </summary>
        /// <param name="absence">Instance de <see cref="Absence"/> contenant les nouvelles données.</param>
        public void UpdateAbsence(Absence absence)
        {
            absenceAccess.UpdateAbsence(absence);
        }

        /// <summary>
        /// Stocke temporairement les anciennes dates de début et de fin d’une absence
        /// en mémoire pour pouvoir cibler l’enregistrement à modifier.
        /// </summary>
        /// <param name="dateDebut">Ancienne date de début de l’absence.</param>
        /// <param name="dateFin">Ancienne date de fin de l’absence.</param>
        public void StockageDates(DateTime dateDebut, DateTime dateFin)
        {
            absenceAccess.StockageDates(dateDebut, dateFin);
        }
    }
}