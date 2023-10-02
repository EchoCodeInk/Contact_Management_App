using Modele;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace Data_Access_Layer
{


    static public class ConnectionALaBD
    {


        static string connectionString = $@"Data Source=" + System.Environment.MachineName + "\\SQLEXPRESS;" + "Initial Catalog=db_TP_CSharp;" + "Integrated Security=true;" + "Connect Timeout=5";

        static public void CreationDeCompte()
        {
            using (SqlConnection connect = new SqlConnection(ConnectionALaBD.connectionString))
            {
                connect.Open();
                SqlCommand requeteSQL = new SqlCommand($"INSERT Members (utilisateur, password) VALUES ( '{Membre.Utilisateur}', '{Membre.Password}')");
                requeteSQL.Connection = connect;
                int nbLignes = requeteSQL.ExecuteNonQuery();

                Console.WriteLine($"{nbLignes} ligne(s) ont ete modifiees");
            }
        }

        static public bool VerificationUtilisateurEtPassword()

        {
            bool utilisateurAndPasswordCorrect = false;

            using (SqlConnection connect = new SqlConnection(ConnectionALaBD.connectionString))
            {
               
                connect.Open();
                using (SqlCommand requeteSQLUtilisateur = connect.CreateCommand())
                {
                    requeteSQLUtilisateur.CommandText = "SELECT * FROM Members WHERE utilisateur = @utilisateur AND password = @password";
                    requeteSQLUtilisateur.Parameters.AddWithValue("@utilisateur", Membre.Utilisateur);
                    requeteSQLUtilisateur.Parameters.AddWithValue("@password", Membre.Password);

                    using (SqlDataReader readerUtilisateur = requeteSQLUtilisateur.ExecuteReader())
                    {
                        if (readerUtilisateur.HasRows)
                        {
                            while (readerUtilisateur.Read())
                            {
                                Membre.Utilisateur = (string)readerUtilisateur["utilisateur"];
                                Membre.Password = (string)readerUtilisateur["password"];
                                Membre.ID = (int)readerUtilisateur["id"];
                            }
                            utilisateurAndPasswordCorrect = true;
                        }
                    }
                }
            }

            return utilisateurAndPasswordCorrect;
        }


        static public void CreationDeContact(Contact newContact)
        {
            using (SqlConnection connect = new SqlConnection(ConnectionALaBD.connectionString))
            {
                connect.Open();
                using (SqlCommand requeteSQL = connect.CreateCommand())
                {
                    requeteSQL.CommandText = "INSERT Contacts (prenom, nom, adresse, ville, code_postal,cell_phone, mail, member_utilisateur) VALUES ( @prenom, @nom, @adresse, @ville, @codePostal, @cellPhone, @mail, @contactDuMembre)";
                    requeteSQL.Parameters.AddWithValue("@prenom", newContact.Prenom);
                    requeteSQL.Parameters.AddWithValue("@nom", newContact.Nom);
                    requeteSQL.Parameters.AddWithValue("@adresse", newContact.Adresse);
                    requeteSQL.Parameters.AddWithValue("@ville", newContact.Ville);
                    requeteSQL.Parameters.AddWithValue("@codePostal", newContact.CodePostal);
                    requeteSQL.Parameters.AddWithValue("@cellPhone", newContact.CellPhone);
                    requeteSQL.Parameters.AddWithValue("@mail", newContact.Mail);
                    requeteSQL.Parameters.AddWithValue("@contactDuMembre", newContact.ContactDuMembre);

                    int nbLignes = requeteSQL.ExecuteNonQuery();

                    Console.WriteLine($"{nbLignes} ligne(s) ont ete modifiees");
                }
            }
        }



        static public void ModificationDeContact(Contact contactAMondifier)
        {
            using (SqlConnection connect = new SqlConnection(ConnectionALaBD.connectionString))
            {
                connect.Open();
                using (SqlCommand requeteSQL = connect.CreateCommand())
                {
                    requeteSQL.CommandText = $"UPDATE Contacts SET prenom = @prenom ,nom = @nom, adresse = @adresse, ville = @ville, code_postal = @codePostal, cell_phone = @cellPhone, mail = @mail WHERE id = @id AND member_utilisateur = '{Membre.Utilisateur}' ";
                    requeteSQL.Parameters.AddWithValue("@id", contactAMondifier.Id);
                    requeteSQL.Parameters.AddWithValue("@prenom", contactAMondifier.Prenom);
                    requeteSQL.Parameters.AddWithValue("@nom", contactAMondifier.Nom);
                    requeteSQL.Parameters.AddWithValue("@adresse", contactAMondifier.Adresse);
                    requeteSQL.Parameters.AddWithValue("@ville", contactAMondifier.Ville);
                    requeteSQL.Parameters.AddWithValue("@codePostal", contactAMondifier.CodePostal);
                    requeteSQL.Parameters.AddWithValue("@cellPhone", contactAMondifier.CellPhone);
                    requeteSQL.Parameters.AddWithValue("@mail", contactAMondifier.Mail);

                    int nbLignes = requeteSQL.ExecuteNonQuery();

                    Console.WriteLine($"{nbLignes} ligne(s) ont ete modifiees");
                }
            }

        }
        public static List<Contact> LoadContactDeLaBD()
        {
            List<Contact> liste = new List<Contact>();

            using (SqlConnection connect = new SqlConnection(ConnectionALaBD.connectionString))
            {
                connect.Open();

                SqlCommand requeteSQL = connect.CreateCommand();
                requeteSQL.CommandText = $"SELECT * FROM Contacts WHERE member_utilisateur = '{Membre.Utilisateur}'";

                SqlDataReader reader = requeteSQL.ExecuteReader();

                while (reader.Read())
                {
                    Contact table = new Contact();

                    table.Prenom = (string)reader["prenom"];
                    table.Nom = (string)reader["nom"];
                    table.Adresse = (string)reader["adresse"];
                    table.Ville = (string)reader["ville"];
                    table.CodePostal = (string)reader["code_postal"];
                    table.CellPhone = (string)reader["cell_phone"];
                    table.Mail = (string)reader["mail"];
                    table.Id = (int)reader["id"];
                    table.ContactDuMembre = (string)reader["member_utilisateur"];

                    liste.Add(table);
                }
            }

            return liste;
        }

        public static void DeleteUnContact(Contact contactADeleter)
        {
            using (SqlConnection connect = new SqlConnection(ConnectionALaBD.connectionString))
            {
                connect.Open();
                using (SqlCommand requeteSQL = connect.CreateCommand())
                {
                    requeteSQL.CommandText = $"DELETE FROM Contacts WHERE id = '{contactADeleter.Id}' AND member_utilisateur = '{Membre.Utilisateur}'";

                    int nbLignes = requeteSQL.ExecuteNonQuery();

                    Console.WriteLine($"{nbLignes} ligne(s) ont ete modifiees");
                }
            }

        }
        public static Contact SearchOneContactByID(Contact searchContactByID)
        {
            using (SqlConnection connect = new SqlConnection(ConnectionALaBD.connectionString))
            {
                connect.Open();
                using (SqlCommand requeteSQL = connect.CreateCommand())
                {
                    requeteSQL.CommandText = $"SELECT * FROM Contacts WHERE id = @id AND member_utilisateur = '{Membre.Utilisateur}' ";
                    requeteSQL.Parameters.AddWithValue("@id", searchContactByID.Id);

                    SqlDataReader reader = requeteSQL.ExecuteReader();
                    while (reader.Read())
                    {
                        searchContactByID.Prenom = (string)reader["prenom"];
                        searchContactByID.Nom = (string)reader["nom"];
                        searchContactByID.Adresse = (string)reader["adresse"];
                        searchContactByID.Ville = (string)reader["ville"];
                        searchContactByID.CodePostal = (string)reader["code_postal"];
                        searchContactByID.CellPhone = (string)reader["cell_phone"];
                        searchContactByID.Mail = (string)reader["mail"];
                        searchContactByID.Id = (int)reader["id"];
                        searchContactByID.ContactDuMembre = (string)reader["member_utilisateur"];
                    }
                }

            }

            return searchContactByID;
        }
        static public bool VerificationUtilisateurOnly()

        {
            bool utilisateurAndPasswordCorrect = false;

            using (SqlConnection connect = new SqlConnection(ConnectionALaBD.connectionString))
            {
                connect.Open();
                using (SqlCommand requeteSQLUtilisateur = connect.CreateCommand())
                {
                    requeteSQLUtilisateur.CommandText = "SELECT * FROM Members WHERE utilisateur = @utilisateur ";
                    requeteSQLUtilisateur.Parameters.AddWithValue("@utilisateur", Membre.Utilisateur);


                    using (SqlDataReader readerUtilisateur = requeteSQLUtilisateur.ExecuteReader())
                    {
                        if (readerUtilisateur.HasRows)
                        {
                            utilisateurAndPasswordCorrect = true;
                        }
                    }
                }
            }

            return utilisateurAndPasswordCorrect;
        }

        public static List<Contact> SearchBarLoadContactDeLaBD(string text)
        {
            List<Contact> liste = new List<Contact>();

            using (SqlConnection connect = new SqlConnection(ConnectionALaBD.connectionString))
            {
                connect.Open();

                SqlCommand requeteSQL = connect.CreateCommand();
                requeteSQL.CommandText = $"SELECT * FROM Contacts WHERE member_utilisateur = '{Membre.Utilisateur}' AND (nom like '{text}%' OR prenom like '{text}%' OR adresse like '{text}%' OR ville like '{text}%' OR code_postal like '{text}%' OR mail like '{text}%' OR cell_phone like '{text}%')";

                SqlDataReader reader = requeteSQL.ExecuteReader();

                while (reader.Read())
                {
                    Contact table = new Contact();

                    table.Prenom = (string)reader["prenom"];
                    table.Nom = (string)reader["nom"];
                    table.Adresse = (string)reader["adresse"];
                    table.Ville = (string)reader["ville"];
                    table.CodePostal = (string)reader["code_postal"];
                    table.CellPhone = (string)reader["cell_phone"];
                    table.Mail = (string)reader["mail"];
                    table.Id = (int)reader["id"];
                    table.ContactDuMembre = (string)reader["member_utilisateur"];


                    liste.Add(table);
                }
            }

            return liste;
        }
        static public Contact LoadInfoDuProfilDuMembre(Contact infoDuMembre)

        {
            using (SqlConnection connect = new SqlConnection(ConnectionALaBD.connectionString))
            {
                connect.Open();
                using (SqlCommand requeteSQLUtilisateur = connect.CreateCommand())
                {
                    requeteSQLUtilisateur.CommandText = "SELECT TOP 1 * FROM Contacts WHERE member_utilisateur = @utilisateur";
                    requeteSQLUtilisateur.Parameters.AddWithValue("@utilisateur", Membre.Utilisateur);

                    using (SqlDataReader readerUtilisateur = requeteSQLUtilisateur.ExecuteReader())
                    {

                        while (readerUtilisateur.Read())
                        {
                            infoDuMembre.Prenom = (string)readerUtilisateur["prenom"];
                            infoDuMembre.Nom = (string)readerUtilisateur["nom"];
                            infoDuMembre.Adresse = (string)readerUtilisateur["adresse"];
                            infoDuMembre.Ville = (string)readerUtilisateur["ville"];
                            infoDuMembre.CodePostal = (string)readerUtilisateur["code_postal"];
                            infoDuMembre.CellPhone = (string)readerUtilisateur["cell_phone"];
                            infoDuMembre.Mail = (string)readerUtilisateur["mail"];
                            infoDuMembre.Id = (int)readerUtilisateur["id"];
                            infoDuMembre.ContactDuMembre = (string)readerUtilisateur["member_utilisateur"];
                        }
                    }
                }
            }
            return infoDuMembre;
        }
    }


}
