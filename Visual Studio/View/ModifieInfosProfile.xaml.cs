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
    /// Interaction logic for ModifieInfosProfile.xaml
    /// </summary>
    public partial class ModifieInfosProfile : Window
    {

        public static Contact contactTransferer;
        public ModifieInfosProfile()
        {
            ModifieInfosProfile.contactTransferer = new Contact();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            if (PopupEditeEnterID.IDcontactTransferer != null)
            {
                ModifieInfosProfile.contactTransferer = Controleur.SearchOneContactByID(PopupEditeEnterID.IDcontactTransferer);
                InitialiseTextBoxWindow();
                PopupEditeEnterID.IDcontactTransferer = null;
            }
            else
            {
                Contact newContact = new Contact();
                ModifieInfosProfile.contactTransferer = Controleur.LoadInfoDuProfilDuMembre(newContact);
                InitialiseTextBoxWindow();
            }
        }

        private void ButtonModifierClick(object sender, RoutedEventArgs e)
        {

            Controleur monControleur = new Controleur();
            Contact newContact = new Contact();
            newContact.Id = contactTransferer.Id;
            newContact.Prenom = this.prenom.Text;
            newContact.Nom = this.nom.Text;
            newContact.Adresse = this.adresse.Text;
            newContact.Ville = this.ville.Text;
            newContact.CodePostal = this.zipCode.Text;
            newContact.CellPhone = this.telephone.Text;
            newContact.Mail = this.mail.Text;

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
                MessageBox.Show("Veuillez saisir un numero de telephone valide !!");
            }
            else
            {
                Controleur.ModificationDeContact(newContact);
                MessageBox.Show("Votre informations ont ete modifie!");
                this.Visibility = Visibility.Hidden;
                Window pageAccuel = new PageAccueil();
                pageAccuel.Visibility = Visibility.Visible;
            }

        }

        private void ButtonFermer(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Window pageAccuel = new PageAccueil();
            pageAccuel.Visibility = Visibility.Visible;
        }


        public void InitialiseTextBoxWindow()
        {

            this.prenom.Text = ModifieInfosProfile.contactTransferer.Prenom;
            this.nom.Text = ModifieInfosProfile.contactTransferer.Nom;
            this.adresse.Text = ModifieInfosProfile.contactTransferer.Adresse;
            this.ville.Text = ModifieInfosProfile.contactTransferer.Ville;
            this.zipCode.Text = ModifieInfosProfile.contactTransferer.CodePostal;
            this.telephone.Text = ModifieInfosProfile.contactTransferer.CellPhone;
            this.mail.Text = ModifieInfosProfile.contactTransferer.Mail;
        }


    }
}
