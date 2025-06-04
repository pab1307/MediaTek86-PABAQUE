using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MediaTek86.bddmanager
{
    /// <summary>
    /// Gestionnaire unique de la connexion et des requêtes vers la base de données MySQL.
    /// Implementé en singleton pour s’assurer qu’une seule connexion est ouverte.
    /// </summary>
    public class BddManager
    {
        /// <summary>
        /// Instance unique de la classe BddManager.
        /// </summary>
        private static BddManager instance = null;

        /// <summary>
        /// Objet de connexion à la base de données MySQL.
        /// </summary>
        private readonly MySqlConnection connection;

        /// <summary>
        /// Constructeur privé pour initialiser et ouvrir la connexion MySQL à partir de la chaîne fournie.
        /// </summary>
        /// <param name="stringConnect">Chaîne de connexion MySQL (par exemple "server=localhost;uid=user;pwd=pass;database=nomBDD;").</param>
        private BddManager(string stringConnect)
        {
            connection = new MySqlConnection(stringConnect);
            connection.Open();
        }

        /// <summary>
        /// Retourne l’unique instance de BddManager, en créant la connexion si elle n’existe pas encore.
        /// </summary>
        /// <param name="stringConnect">Chaîne de connexion MySQL. Nécessaire uniquement lors de la première création de l’instance.</param>
        /// <returns>Instance singleton de BddManager.</returns>
        public static BddManager GetInstance(string stringConnect)
        {
            if (instance == null)
            {
                instance = new BddManager(stringConnect);
            }
            return instance;
        }

        /// <summary>
        /// Exécute une requête SQL de type INSERT, UPDATE ou DELETE.
        /// </summary>
        /// <param name="stringQuery">Requête SQL (INSERT, UPDATE ou DELETE) à exécuter.</param>
        /// <param name="parameters">
        /// (Optionnel) Dictionnaire de paramètres à ajouter à la commande MySqlCommand. 
        /// La clé est le nom du paramètre (avec le “@”), et la valeur est l’objet à lier.
        /// </param>
        public void ReqUpdate(string stringQuery, Dictionary<string, object> parameters = null)
        {
            MySqlCommand command = new MySqlCommand(stringQuery, connection);
            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                }
            }
            command.Prepare();
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Exécute une requête SQL de type SELECT et retourne les résultats sous forme de liste de tableaux d’objets.
        /// </summary>
        /// <param name="stringQuery">Requête SQL SELECT à exécuter.</param>
        /// <param name="parameters">
        /// (Optionnel) Dictionnaire de paramètres à ajouter à la commande MySqlCommand.
        /// La clé est le nom du paramètre (avec le “@”), et la valeur est l’objet à lier.
        /// </param>
        /// <returns>
        /// Liste de tableaux d’objets. Chaque tableau correspond à une ligne du résultat, 
        /// avec autant d’éléments que de colonnes dans la requête.
        /// </returns>
        public List<object[]> ReqSelect(string stringQuery, Dictionary<string, object> parameters = null)
        {
            MySqlCommand command = new MySqlCommand(stringQuery, connection);
            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                }
            }
            command.Prepare();
            MySqlDataReader reader = command.ExecuteReader();
            int nbCols = reader.FieldCount;
            List<object[]> records = new List<object[]>();
            while (reader.Read())
            {
                object[] attributs = new object[nbCols];
                reader.GetValues(attributs);
                records.Add(attributs);
            }
            reader.Close();
            return records;
        }
    }
}