using MediaTek86.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTek86.dal
{
    /// <summary>
    /// classe permettant de gérer les demandes concernant le personnel
    /// </summary>
    public class PersonnelAccess
    {
        /// <summary>
        /// instance unique de l'accès aux données
        /// </summary>
        private readonly Access access = null;

        /// <summary>
        /// constructeur pour créer l'accès aux données
        /// </summary>
        public PersonnelAccess()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// récupère et retourne la liste du personnel
        /// </summary>
        /// <returns>liste du personnel</returns>
        public List<Personnel> GetLePersonnel()
        {
            List<Personnel> lePersonnel = new List<Personnel>();
            if (access.Manager != null)
            {
                // On récupère l'id du personnel, ses coordonnées et l'id + le nom du service associé
                string req =
                    "select p.idpersonnel as idpersonnel, " +
                           "p.nom as nom, " +
                           "p.prenom as prenom, " +
                           "p.tel as tel, " +
                           "p.mail as mail, " +
                           "s.idservice as idservice, " +
                           "s.nom as service " +
                    "from personnel p " +
                    "join service s on (p.idservice = s.idservice) " +
                    "order by p.nom, p.prenom;";
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req);
                    if (records != null)
                    {
                        foreach (Object[] record in records)
                        {
                            // record[5] => idservice, record[6] => nom du service
                            Service service = new Service((int)record[5], (string)record[6]);
                            // Le constructeur de Service initialise CodeService = string.Empty par défaut

                            // record[0..4] : idpersonnel, nom, prenom, tel, mail
                            Personnel personnel = new Personnel(
                                (int)record[0],
                                (string)record[1],
                                (string)record[2],
                                (string)record[3],
                                (string)record[4],
                                service
                            );
                            // Le constructeur de Personnel initialise CodePersonnel = string.Empty par défaut

                            lePersonnel.Add(personnel);
                        }
                    }
                }
                catch (Exception e)
                {
                    // En cas d’erreur, on loggue et on quitte l’application
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
            return lePersonnel;
        }

        /// <summary>
        /// demande de suppression d'un membre du personnel
        /// </summary>
        /// <param name="personnel">objet Personnel à supprimer</param>
        public void DelPersonnel(Personnel personnel)
        {
            if (access.Manager != null)
            {
                string req = "delete from personnel where idpersonnel = @idpersonnel;";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@idpersonnel", personnel.Idpersonnel }
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
        /// demande d'ajout d'un membre du personnel
        /// </summary>
        /// <param name="personnel">objet Personnel à ajouter</param>
        public void AddPersonnel(Personnel personnel)
        {
            if (access.Manager != null)
            {
                string req =
                    "insert into personnel(nom, prenom, tel, mail, idservice) " +
                    "values (@nom, @prenom, @tel, @mail, @idservice);";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@nom", personnel.Nom },
                    { "@prenom", personnel.Prenom },
                    { "@tel", personnel.Tel },
                    { "@mail", personnel.Mail },
                    { "@idservice", personnel.Service.Idservice }
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
        /// demande de modification d'un membre du personnel
        /// </summary>
        /// <param name="personnel">objet Personnel à modifier</param>
        public void UpdatePersonnel(Personnel personnel)
        {
            if (access.Manager != null)
            {
                string req =
                    "update personnel " +
                    "set nom = @nom, prenom = @prenom, tel = @tel, mail = @mail, idservice = @idservice " +
                    "where idpersonnel = @idpersonnel;";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    // Note : on utilise "@idpersonnel" pour coller exactement au nom de la colonne
                    { "@idpersonnel", personnel.Idpersonnel },
                    { "@nom", personnel.Nom },
                    { "@prenom", personnel.Prenom },
                    { "@tel", personnel.Tel },
                    { "@mail", personnel.Mail },
                    { "@idservice", personnel.Service.Idservice }
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
        /// contrôle si l'utilisateur a le droit de se connecter
        /// </summary>
        /// <param name="responsable">objet Responsable avec Login/Pwd</param>
        /// <returns>vrai si l'utilisateur est responsable</returns>
        public Boolean ControleConnexion(Responsable responsable)
        {
            if (access.Manager != null)
            {
                string req =
                    "select * from responsable r " +
                    "where r.login = @login and r.pwd = SHA2(@pwd, 256);";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@login", responsable.Login },
                    { "@pwd", responsable.Pwd }
                };
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req, parameters);
                    if (records != null)
                    {
                        return (records.Count > 0);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
            return false;
        }
    }
}