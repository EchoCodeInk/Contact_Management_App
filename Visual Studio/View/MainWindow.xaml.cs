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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace View {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void ButtonCreerNouveauCompte(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Window creerCompte = new CreateAccount();
            creerCompte.Visibility = Visibility.Visible;
        }

        private void ButtonConnecte(object sender, RoutedEventArgs e)
        {

            // Membre newMembre = new Membre();
            Controleur monControleur = new Controleur();

            Membre.Utilisateur = this.userName.Text;
            Membre.Password = this.password.Password;
            bool retourInfo = Controleur.VerificationUtilisateurEtPassword();
            if (retourInfo)
            {
                this.Visibility = Visibility.Hidden;
                Window pageAccuel = new PageAccueil();
                pageAccuel.Visibility = Visibility.Visible;

            }
            else
            {
                this.MessageLoginErreur.Foreground = Brushes.Red;
                this.MessageLoginErreur.Content = "Username ou Password INCORECT !!";
                this.MessageLoginErreur.Visibility = Visibility.Visible;
            }


        }
    }
}
