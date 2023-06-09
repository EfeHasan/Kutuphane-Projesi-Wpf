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

namespace Kütüphane_Projesi_wpf
{
    /// <summary>
    /// Kullanici_Ekle.xaml etkileşim mantığı
    /// </summary>
    public partial class Kullanici_Ekle : Window
    {
        public Kullanici_Ekle()
        {
            InitializeComponent();
        }

        private void Sifre_Degistir_Click(object sender, RoutedEventArgs e)
        {
            kullanici_düzenle kullanici_ = new kullanici_düzenle
            {
                Sifre = Sifre.Text,
                SoyIsim = Soyisim.Text,
                Isim = Isim.Text,
                Tc_Kimlik = Tc.Text
            };
            int deger = kullanici_.Sifre_Degistir();
            if (deger > 0)
            {
                MessageBox.Show("işlem başarılı");
            }
            else
            {
                MessageBox.Show("işlem başarısız");
            }
        }

        private void Ana_menu_Click(object sender, RoutedEventArgs e)
        {
            Ana_Menu ana_Menu = new Ana_Menu();
            ana_Menu.Show();
            this.Hide();
        }

        private void Numara_Degistir_Click(object sender, RoutedEventArgs e)
        {
            kullanici_düzenle kullanici = new kullanici_düzenle
            {
                Isim = Isim.Text,
                SoyIsim = Soyisim.Text,
                numara_get = Numara.Text,
                Tc_Kimlik = Tc.Text
            };
            int deger=kullanici.Numara_Degistir();
            if (deger > 0)
            {
                MessageBox.Show("işlem başarılı");
            }
            else
            {
                MessageBox.Show("işlem başarısız");
            }
        }

        private void Yetki_Ver_Click(object sender, RoutedEventArgs e)
        {
            kullanici_düzenle kullanici = new kullanici_düzenle
            {
                Isim = Isim.Text,
                SoyIsim = Soyisim.Text,
                Tc_Kimlik = Tc.Text
            };
            int deger = kullanici.Yetki_Ver();
            if (deger > 0)
            {
                MessageBox.Show("işlem başarılı");
            }
            else
            {
                MessageBox.Show("işlem başarısız");
            }
        }

        private void Tc_Degistir_Click(object sender, RoutedEventArgs e)
        {
            kullanici_düzenle kullanici = new kullanici_düzenle
            {
                Isim = Isim.Text,
                SoyIsim = Soyisim.Text,
                numara_get = Numara.Text,
                Tc_Kimlik = Tc.Text
            };
            int deger = kullanici.Yetki_Ver();
            if (deger > 0)
            {
                MessageBox.Show("işlem başarılı");
            }
            else
            {
                MessageBox.Show("işlem başarısız");
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            alinmasi_gerekenler gerek = new alinmasi_gerekenler();
            gerek.ne_sectim();
        }
    }
}
