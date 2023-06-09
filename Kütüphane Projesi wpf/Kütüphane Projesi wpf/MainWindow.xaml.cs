using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using MySql.Data.MySqlClient;


namespace Kütüphane_Projesi_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static string yetki;
        private void Giris_Yap_Click(object sender, RoutedEventArgs e)
        {
            string kullanici_adi = Kullanici_Adi.Text;
            string kullanici_sifre = Sifre_kutusu.Password  ;

            Giris_Yap giris=new Giris_Yap(kullanici_sifre, kullanici_adi);
            bool varmi=giris.giris_yap();
            yetki = giris.yetki_varmi();
            if (!string.IsNullOrEmpty(kullanici_adi) && !string.IsNullOrEmpty(kullanici_sifre))
            {
                if (varmi)
                {
                    if (radiobutton.IsChecked == true)
                    {
                        giris.beni_hatirla();
                    }
                    Ana_Menu f = new Ana_Menu();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("kullanıcı adı veya şifre yanlış", "hata", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("kullanıcı adı veya şifre kutusu boş", "hata", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void Kayit_OL_Click(object sender, RoutedEventArgs e)
        {
            Kayit_Ekranı kayit_ekran = new Kayit_Ekranı();
            kayit_ekran.Show();
            this.Hide();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Giris_Yap giris = new Giris_Yap(Sifre_kutusu.Password, Kullanici_Adi.Text);
            int deger = giris.hatirlaniyormuyum();
            if (deger > 0)
            {
                Ana_Menu f = new Ana_Menu();
                f.Show();
                this.Hide();
            }
        }
    }
}
