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

namespace View {
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window {


        public CreateAccount()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void MsgErreurValidationsInfo(string msg, TextBox textBox)
        {
            this.DefaultColor();
            this.MessageTelephoneErreur.Foreground = Brushes.Red;
            textBox.BorderBrush = Brushes.Red;

            this.MessageTelephoneErreur.Content = msg;
            this.MessageTelephoneErreur.Visibility = Visibility.Visible;

        }
        private void DefaultColor()
        {
            this.userName.BorderBrush = Brushes.Gray;
            this.password.BorderBrush = Brushes.Gray;
            this.prenom.BorderBrush = Brushes.Gray;
            this.nom.BorderBrush = Brushes.Gray;
            this.telephone.BorderBrush = Brushes.Gray;
        }

        private void ButtonCreerCompte(object sender, RoutedEventArgs e)
        {

            Contact newContact = new Contact();
            Membre.Utilisateur = this.userName.Text;
            Membre.Password = this.password.Text;
            newContact.Prenom = this.prenom.Text;
            newContact.Nom = this.nom.Text;
            newContact.Adresse = this.adresse.Text;
            newContact.Ville = this.ville.Text;
            newContact.CodePostal = this.zipCode.Text;
            newContact.CellPhone = this.telephone.Text;
            newContact.Mail = this.mail.Text;
            newContact.ContactDuMembre = Membre.Utilisateur;

            bool utilisateurStatus = Controleur.VerificationUtilisateurOnly();
            if (utilisateurStatus == true)
            {
                this.MsgErreurValidationsInfo("Ce nom d'utilissateur est déjà utiliser !!", this.userName);
            }    

            else if (this.userName.Text == "")
            {
                this.MsgErreurValidationsInfo("Veuillez saisir votre username !!", this.userName);
            }
            else if (this.password.Text == "")
            {
                this.MsgErreurValidationsInfo("Veuillez saisir votre password !!", this.password);
            }
            else if (this.prenom.Text == "")
            {
                this.MsgErreurValidationsInfo("Veuillez saisir votre prenom !!", this.prenom);
            }
            else if (this.nom.Text == "")
            {
                this.MsgErreurValidationsInfo("Veuillez saisir votre nom !!", this.nom);
            }
            else if (this.telephone.Text == "(555)666-7777" || this.telephone.Text.Length != 13)
            {
                this.MsgErreurValidationsInfo("Veuillez saisir un numero de telephone valide !!", this.telephone);
            }
            else 
            {
                this.MessageTelephoneErreur.Visibility = Visibility.Hidden;
                MessageBox.Show("Votre Compte a ete creer!");   // ce popup est juste pour le test
                this.Visibility = Visibility.Hidden;
                Window mainWindow = new MainWindow();           // pour retourner a la fenetre principale (login)
                mainWindow.Visibility = Visibility.Visible;
                Controleur.CreationDeCompte();               // Création de l'utilisateur et du password
                Controleur.CreationDeContact(newContact);    // Création des information qui vont dans Contact
            }
        }

        private void ButtonFermer(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Window mainWindow = new MainWindow();
            mainWindow.Visibility = Visibility.Visible;
        }


    }
}
