using MediaTek86.bddmanager;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaTek86
{
    /// <summary>
    /// Application de gestion du personnel de MediaTek86
    /// </summary>
    internal class NamespaceDoc { }
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // 1) Définir la chaîne de connexion correspondant à votre configuration XAMPP
            string chaineConnexion = "server=127.0.0.1;port=3306;database=script;uid=root;password=;";

            try
            {
                // 2) Appeler le singleton une seule fois avec la bonne chaîne
                BddManager bdd = BddManager.GetInstance(chaineConnexion);

                // (Optionnel) : si vous voulez fermer immédiatement la connexion, 
                // vous pouvez ajouter et appeler ici une méthode Close() dans BddManager.
                // bdd.Close();
            }
            catch (MySqlException ex)
            {
                // Si la connexion échoue, on affiche une MessageBox et on quitte
                MessageBox.Show(
                    "Impossible de se connecter à la base de données :\n" + ex.Message,
                    "Erreur de connexion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            // ────────────────────────────────────────────────────────────────────

            // 3) Si tout est OK, on peut à présent lancer le formulaire de connexion
            Application.Run(new view.FrmConnexion());
        }
    }
}