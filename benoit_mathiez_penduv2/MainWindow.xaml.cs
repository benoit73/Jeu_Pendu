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

namespace benoit_mathiez_penduv2
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LaClass myLaClass;
        public bool isMusiquePlaying = true;
        public MainWindow()
        {
            
            InitializeComponent();
            myLaClass = new LaClass();
            myLaClass.ListDeMot();
            Initialiser();
            musique.Play();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button.Background != Brushes.Red && button.Background != Brushes.Green && myLaClass.NbMort < 7 && myLaClass.Gagne != true)
            {
                string lettre = button.Content.ToString();
                char c = lettre[0];
                myLaClass.TesterLettre(c);

                if (myLaClass.BonneLettre == true)
                {
                    button.Background = Brushes.Green;

                }
                else
                {
                    button.Background = Brushes.Red;
                    int numImage = myLaClass.NbMort;
                    string imagePath = $"Pendu\\{numImage}.png";
                    Uri resource = new Uri(imagePath, UriKind.Relative);
                    BitmapImage bitmapImage = new BitmapImage(resource);
                    monImage.Source = bitmapImage;
                }
                TbMot.Text = myLaClass.MotCache;

                if (myLaClass.Gagne == true)
                {
                    GagneJeu();
                }

                if (myLaClass.NbMort == 7)
                {
                    TbMessage.Text = "Tu as perdu !!";
                    MeEffect.Stop();
                    MeEffect.Play();
                }
            }

        }






        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            Initialiser();
        }

        private void Initialiser()
        {
            myLaClass.SelectMot();
            TbMot.Text = myLaClass.MotCache;
            monImage.Source = null;
            TbMessage.Text = "";
            string[] aplphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

            foreach (string s in aplphabet )
            {
                string nomBtn = "Btn" + s;
                Button lebouton = FindName(nomBtn) as Button;
                lebouton.ClearValue(Button.BackgroundProperty);
            }
        }


        private void GagneJeu()
        {
            TbMessage.Text = "Tu as gagné !";
        }

        private void Sound_Click(object sender, RoutedEventArgs e)
        {
            if (isMusiquePlaying == true)
            {
                musique.Stop();
                isMusiquePlaying = false;
                Uri uri = new Uri("pack://application:,,,/Pendu/enceinte.jpg", UriKind.RelativeOrAbsolute);
                ImgSon.Source = new BitmapImage(uri);
            }
            else
            {
                musique.Play();
                isMusiquePlaying = true;
                Uri uri = new Uri("pack://application:,,,/Pendu/enceinte2.png", UriKind.RelativeOrAbsolute);
                ImgSon.Source = new BitmapImage(uri);
            }
        }

        private void BtnJoker_Click(object sender, RoutedEventArgs e)
        {
            if (myLaClass.NbJokers != 0 && myLaClass.NbMort < 7 && myLaClass.Gagne != true)
            {
                myLaClass.ChooseLettreJoker();
                string nomBtn = "Btn" + myLaClass.LettreJoker.ToString();
                Button btn = FindName(nomBtn) as Button;
                btn.Click += Button_Click;
            }
            
            
        }


    }
}
