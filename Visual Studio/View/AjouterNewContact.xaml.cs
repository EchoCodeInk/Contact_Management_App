using Business_Logic_Layer;
using Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Interaction logic for AjouterNewContact.xaml
    /// </summary>
    public partial class AjouterNewContact : Window
    {
        public AjouterNewContact()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void ButtonAjouterContact(object sender, RoutedEventArgs e)
        {
            Contact newContact = new Contact();

            newContact.Prenom = this.prenom.Text;
            newContact.Nom = this.nom.Text;
            newContact.Adresse = this.adresse.Text;
            newContact.Ville = this.ville.Text;
            newContact.CodePostal = this.zipCode.Text;
            newContact.CellPhone = this.telephone.Text;
            newContact.Mail = this.mail.Text;
            newContact.ContactDuMembre = Membre.Utilisateur;
            if (this.prenom.Text == "")
            {
                MessageBox.Show("Veuillez saisir un prenom !!");
            }
            else if (this.nom.Text == "")
            {
                MessageBox.Show("Veuillez saisir un nom !!");
            }

            else if (this.telephone.Text == "(555)666-7777" || this.telephone.Text.Length != 13)
            {
                this.MessageTelephoneErreur.Foreground = Brushes.Red;
                this.telephone.BorderBrush = Brushes.Red;
                this.MessageTelephoneErreur.Content = "Veuillez saisir votre telephone correctement !!";
                this.MessageTelephoneErreur.Visibility = Visibility.Visible;
            }
            else
            {
                this.MessageTelephoneErreur.Visibility = Visibility.Hidden;
                MessageBox.Show("Le contact a ete ajouter");
                Window pageAccuel = new PageAccueil();           // pour retourner a la fenetre d'accueil
                Controleur.CreationDeContact(newContact);    // Création des information qui vont dans Contact
                this.Visibility = Visibility.Hidden;
                Window pageAccuel1 = new PageAccueil();
                pageAccuel1.Visibility = Visibility.Visible;
            }
        }

        private void ButtonFermer(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Window pageAccuel = new PageAccueil();
            pageAccuel.Visibility = Visibility.Visible;
        }


    }
}
