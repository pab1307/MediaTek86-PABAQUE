using MediaTek86.controller;
using MediaTek86.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaTek86.view
{
    /// <summary>
    /// fenêtre de gestion des absences
    /// </summary>
    public partial class FrmAbsences : Form
    {
        public DateTime DateDebutAvant;
        public DateTime DateFinAvant;
        public int unId = 0;
        /// <summary>
        /// Booléen pour savoir si une modification est demandée
        /// </summary>
        private Boolean enCoursDeModifAbsence = false;

        /// <summary>
        /// objet pour gérer la liste des absences
        /// </summary>
        private BindingSource bdgAbsences = new BindingSource();

        /// <summary>
        /// objet pour gérer la liste des motifs
        /// </summary>
        private BindingSource bdgMotifs = new BindingSource();

        /// <summary>
        /// contrôleur de la fenêtre
        /// </summary>
        private FrmAbsencesController controller;

        /// <summary>
        /// construction des composants graphiques et appel des autres initialisations
        /// </summary>
        public FrmAbsences(int id)
        {
            InitializeComponent();
            Init(id);
        }

        /// <summary>
        /// création du contrôleur et remplissage des listes
        /// </summary>
        private void Init(int id)
        {
            controller = new FrmAbsencesController();
            RemplirListeAbsences(id);
            RemplirListeMotifs();
            EnCoursModifAbsence(false);
            grpAjouterAbsence.Enabled = false;
            dtpDateDebut.Format = DateTimePickerFormat.Custom;
            dtpDateDebut.CustomFormat = "yyyy'-'MM'-'dd  HH:mm:ss";
            dtpDateFin.Format = DateTimePickerFormat.Custom;
            dtpDateFin.CustomFormat = "yyyy'-'MM'-'dd  HH:mm:ss";
        }

        /// <summary>
        /// Affiche les absences
        /// </summary>
        private void RemplirListeAbsences(int id)
        {
            unId = id;
            List<Absence> lesAbsences = controller.GetLesAbsences(id);
            bdgAbsences.DataSource = lesAbsences;
            dgvAbsences.DataSource = bdgAbsences;
            dgvAbsences.Columns["idpersonnel"].Visible = false;
            dgvAbsences.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        /// <summary>
        /// affiche les motifs
        /// </summary>
        private void RemplirListeMotifs()
        {
            List<Motif> lesMotifs = controller.GetLesMotifs();
            bdgMotifs.DataSource = lesMotifs;
            cmbMotif.DataSource = bdgMotifs;
        }

        /// <summary>
        /// demande de modification d'une absence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifierAbsence_Click(object sender, EventArgs e)
        {
            if (dgvAbsences.SelectedRows.Count > 0)
            {
                grpAjouterAbsence.Enabled = true;
                EnCoursModifAbsence(true);
                Absence absence = (Absence)bdgAbsences.List[bdgAbsences.Position];
                dtpDateDebut.Value = absence.Datedebut;
                dtpDateFin.Value = absence.Datefin;
                cmbMotif.SelectedIndex = cmbMotif.FindStringExact(absence.Motif.Libelle);
                MemoriserDates(absence.Datedebut, absence.Datefin);
            }
            else
            {
                MessageBox.Show("Une ligne doit être sélectionnée.", "Information");
            }
        }

        /// <summary>
        /// demande de suppression d'une absence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprAbsence_Click(object sender, EventArgs e)
        {
            if (dgvAbsences.SelectedRows.Count > 0)
            {
                Absence absence = (Absence)bdgAbsences.List[bdgAbsences.Position];
                if (MessageBox.Show("Voulez-vous vraiment supprimer l'absence du " + absence.Datedebut + " au " + absence.Datefin + " ?", "Confirmation de suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    controller.DelAbsence(absence);
                    RemplirListeAbsences(absence.Idpersonnel);
                }
            }
            else
            {
                MessageBox.Show("Une ligne doit être sélectionnée", "Information");
            }
        }

        /// <summary>
        /// demande d'ajout d'une absence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjouterAbsence_Click(object sender, EventArgs e)
        {
            grpAbsences.Enabled = false;
            grpAjouterAbsence.Enabled = true;
            dtpDateDebut.Focus();
            grpAjouterAbsence.Text = "Ajouter une absence";
            dtpDateDebut.Value = DateTime.Now;
            dtpDateFin.Value = DateTime.Now;
            cmbMotif.SelectedIndex = -1;
        }

        /// <summary>
        /// Demande d'enregistrement de l'ajout ou de la modification d'une absence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnregistrerAbs_Click(object sender, EventArgs e)
        {
            if (dtpDateDebut.Value < dtpDateFin.Value && cmbMotif.SelectedIndex != -1)
            {
                Motif motif = (Motif)bdgMotifs.List[bdgMotifs.Position];
                if (enCoursDeModifAbsence)
                {
                    Absence absence = (Absence)bdgAbsences.List[bdgAbsences.Position];
                    absence.Datedebut = dtpDateDebut.Value;
                    absence.Datefin = dtpDateFin.Value;
                    absence.Motif = motif;
                    if (MessageBox.Show("Voulez-vous vraiment confirmaer la modification ?", "Confirmation de modification", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        controller.StockageDates(DateDebutAvant, DateFinAvant);
                        controller.UpdateAbsence(absence);
                    }
                }
                else
                {
                    Absence absence = new Absence(unId, dtpDateDebut.Value, dtpDateFin.Value, motif);
                    controller.AddAbsence(absence);
                }
                grpAjouterAbsence.Enabled = false;
                RemplirListeAbsences(unId);
                EnCoursModifAbsence(false);
            }
            else
            {
                MessageBox.Show("Tous les champs doivent être remplis.", "Information");
            }
        }

        /// <summary>
        /// annule la demande d'ajout ou de modification d'une absence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnulerAbs_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment annuler ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                EnCoursModifAbsence(false);
                grpAjouterAbsence.Enabled = false;
            }
        }

        private void EnCoursModifAbsence(Boolean modif)
        {
            enCoursDeModifAbsence = modif;
            grpAbsences.Enabled = !modif;
            if (modif)
            {
                grpAjouterAbsence.Text = "Modifier une absence";
            }
            else
            {
                grpAjouterAbsence.Text = "Ajouter une absence";
                dtpDateDebut.Value = DateTime.Now;
                dtpDateFin.Value = DateTime.Now;
                cmbMotif.SelectedIndex = -1;
            }
        }

        private void MemoriserDates(DateTime dateDebut, DateTime dateFin)
        {
            DateDebutAvant = dateDebut;
            DateFinAvant = dateFin;
        }
    }
}
