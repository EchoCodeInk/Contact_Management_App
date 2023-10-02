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
    /// Interaction logic for PopupEditeEnterID.xaml
    /// </summary>
    public partial class PopupEditeEnterID : Window
    {

        public static Contact IDcontactTransferer;

        public PopupEditeEnterID()
        {
            PopupEditeEnterID.IDcontactTransferer = new Contact();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void ButtunModifierPopup(object sender, RoutedEventArgs e)
        {
            Contact newContact = new Contact();
            if (TextBoxIDSaisie.Text == "")
            {
                this.MessageModifieErreur.Foreground = Brushes.Red;
                this.MessageModifieErreur.Content = "Veuillez entrer une valeur";
            }
            else if (TextBoxIDSaisie.Text != "")
            {

                PopupEditeEnterID.IDcontactTransferer.Id = int.Parse(this.TextBoxIDSaisie.Text);
                this.Visibility = Visibility.Hidden;
                Window modifieInfosProfile = new ModifieInfosProfile();
                modifieInfosProfile.Visibility = Visibility.Visible;

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
