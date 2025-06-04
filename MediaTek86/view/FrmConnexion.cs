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
    /// fenêtre de connexion (seul le responsable peut accéder à l'application)
    /// </summary>
    public partial class FrmConnexion : Form
    {
        /// <summary>
        /// contrôleur de la fenêtre
        /// </summary>
        private FrmConnexionController controller;

        /// <summary>
        /// construction des composants graphiques et appel des autres initialisations
        /// </summary>
        public FrmConnexion()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// initialisation : création du contrôleur
        /// </summary>
        private void Init()
        {
            controller = new FrmConnexionController();
        }

        /// <summary>
        /// demande au contrôleur de contrôler la connexion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            String nom = txtLogin.Text;
            String pwd = txtPwd.Text;
            if (String.IsNullOrEmpty(nom) || String.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("Tous les champs doivent être remplis.", "Information");
            }
            else
            {
                Responsable responsable = new Responsable(nom, pwd);
                if (controller.ControleConnexion(responsable))
                {
                    FrmGestionPersonnel frm = new FrmGestionPersonnel();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Authentification incorrecte ou vous n'êtes pas responsable", "Alerte");
                }
            }
        }
    }
}
