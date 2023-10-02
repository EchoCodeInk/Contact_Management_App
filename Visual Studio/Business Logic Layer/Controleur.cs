using System.Collections.Generic;
using Data_Access_Layer;
using Modele;

namespace Business_Logic_Layer
{
    public class Controleur 
    {

        public static void CreationDeCompte()
        {
            ConnectionALaBD.CreationDeCompte();
        }

        public static void CreationDeContact(Contact newContact)
        {
            ConnectionALaBD.CreationDeContact(newContact);
        }

        public static void DeleteUnContact(Contact contactADeleter)
        {
            ConnectionALaBD.DeleteUnContact(contactADeleter);
        }

        public static List<Contact> LoadContactDeLaBD()
        {
            return ConnectionALaBD.LoadContactDeLaBD();
        }

        public static void ModificationDeContact(Contact contactAMondifier)
        {
            ConnectionALaBD.ModificationDeContact(contactAMondifier);
        }


        public static bool VerificationUtilisateurEtPassword()
        {
            bool retourMethode;
            retourMethode = ConnectionALaBD.VerificationUtilisateurEtPassword();
            return retourMethode;
        }

        public static Contact SearchOneContactByID(Contact ContactID)
        {
            return ConnectionALaBD.SearchOneContactByID(ContactID);
        }
        static public bool VerificationUtilisateurOnly()
        {
            return ConnectionALaBD.VerificationUtilisateurOnly();
        }

        public static List<Contact> SearchBarLoadContactDeLaBD(string text)
        {
            return ConnectionALaBD.SearchBarLoadContactDeLaBD(text);
        }

        static public Contact LoadInfoDuProfilDuMembre(Contact infoDuMembre)
        {
            return ConnectionALaBD.LoadInfoDuProfilDuMembre(infoDuMembre);
        }

    }
}
