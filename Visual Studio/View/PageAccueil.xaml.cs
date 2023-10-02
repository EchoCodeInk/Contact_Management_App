using Business_Logic_Layer;
using Modele;
using System;
using System.Collections;
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
    /// Interaction logic for PageAccueil.xaml
    /// </summary>
    public partial class PageAccueil : Window
    {
        public PageAccueil()
        {

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();

            Controleur monControleur = new Controleur();

            bonjourLabel.Content = $"Bonjour {Membre.Utilisateur},";

            List<Contact> listeDesContact = Controleur.LoadContactDeLaBD();           //Ici on insert la liste de la BD dans le Datagrid
            this.contactDataGrid.ItemsSource = listeDesContact;

        }

        private void ButtonAddContact(object sender, RoutedEventArgs e)
        {
            this.contactDataGrid.Items.Refresh();

            this.Visibility = Visibility.Hidden;
            Window ajouterNewContact = new AjouterNewContact();
            ajouterNewContact.Visibility = Visibility.Visible;
        }

        private void ButtonModifieInfosProfile(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Window modifieInfosProfile = new ModifieInfosProfile();
            modifieInfosProfile.Visibility = Visibility.Visible;

        }

        private void ButtonModifyContact(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Window popupEditeEnterID = new PopupEditeEnterID();
            popupEditeEnterID.Visibility = Visibility.Visible;

        }

        private void ButtonDeleteContact(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Window popupDeleteEnterID = new PopupDeleteEnterID();
            popupDeleteEnterID.Visibility = Visibility.Visible;
        }

        private void ButtonSignOut(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Window mainWindow = new MainWindow();
            mainWindow.Visibility = Visibility.Visible;
        }

        private void SearchBarreText(object sender, KeyEventArgs e)
        {
            List<Contact> listeDesContact = Controleur.SearchBarLoadContactDeLaBD(this.SearchBarre.Text);
            this.contactDataGrid.ItemsSource = listeDesContact;

        }
    }
}
