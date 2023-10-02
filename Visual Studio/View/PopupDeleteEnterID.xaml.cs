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
    /// Interaction logic for PopupDeleteEnterID.xaml
    /// </summary>
    public partial class PopupDeleteEnterID : Window
    {
        public PopupDeleteEnterID()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;    
            InitializeComponent();
        }

        private void ButtonSupprimerParID(object sender, RoutedEventArgs e)
        {
            Contact newContact = new Contact();

            if (supprime_ID.Text == "")
            {
                this.MessageDeleteIdErreur.Foreground = Brushes.Red;
                this.MessageDeleteIdErreur.Content = "Veuillez entrer une valeur";
            }
            else if (supprime_ID.Text != "")
            {
                newContact.Id = int.Parse(supprime_ID.Text);
                Controleur.DeleteUnContact(newContact);
                MessageBox.Show("Suppression du contact");
                this.Visibility = Visibility.Hidden;
                Window pageAccuel = new PageAccueil();
                pageAccuel.Visibility = Visibility.Visible;
                this.MessageDeleteIdErreur.Visibility = Visibility.Hidden;
            }
        }

        private void ButtunFermerPopup(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Window pageAccuel = new PageAccueil();
            pageAccuel.Visibility = Visibility.Visible;
        }
    }


}
