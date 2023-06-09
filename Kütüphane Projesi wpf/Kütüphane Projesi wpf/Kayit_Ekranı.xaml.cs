using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
    /// Kayit_Ekranı.xaml etkileşim mantığı
    /// </summary>
    public partial class Kayit_Ekranı : Window
    {
        public Kayit_Ekranı()
        {
            InitializeComponent();
        }

        public static string[] sayilar = new string[]
        {
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
        };
        public static string[] buyukHarfler = new string[]
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
            "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
            "U", "V", "W", "X", "Y", "Z"
        };
        bool gecerli(string tc)
        {
            bool gecerli_ = true;

            for(int i=0; i<buyukHarfler.Length; i++)
            {
                for(int a=0;a<tc.Length; a++)
                {
                    if (tc[a].ToString() == buyukHarfler[i] || tc[a].ToString() == buyukHarfler[i].ToLower()) 
                    {
                        gecerli_ = false;
                    }
                }
            }
            return gecerli_;
        }
        private void Kayit_button_Click(object sender, RoutedEventArgs e)
        {

            string isim, soyisim, tc, numara, sifre;
            isim = Isim_Kutusu.Text;
            soyisim = Soy_Isim_Kutusu.Text;
            tc = Tc_kimlik.Text;
            numara = Telefon_numarası.Text;
            sifre = Sifre_kutusu.Password;
            Kayit_OL kayit = new Kayit_OL(tc, isim, soyisim, sifre, numara);
            bool sifre_varmi = kayit.sifre_varmi();
            if (!string.IsNullOrEmpty(isim) && !string.IsNullOrEmpty(soyisim) && !string.IsNullOrEmpty(tc) && !string.IsNullOrEmpty(sifre) && !string.IsNullOrEmpty(numara)) 
            {
                if (sifre.Length >= 8 && sifre.Length <= 16)
                {
                    bool gecerlimi = gecerli(tc);
                    if (sifre_varmi == false)
                    {
                        if (gecerlimi)
                        {
                            kayit.kayit_ol();
                        }
                        else
                        {
                            MessageBox.Show("Tc numarasında harf olmaz");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu şifre kullanılmakta","hata",MessageBoxButton.OK,MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Şifre oluşturma koşulları sağalanmıyor");
                }
            }
            else
            {
                MessageBox.Show("Kutucuklardan birisi veya bir kaçı boş bırakılmıştır");
            }
            
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Tc_kimlik.MaxLength = 11;
            Sifre_kutusu.MaxLength = 16;
        }

        private void Sifre_kutusu_PasswordChanged(object sender, RoutedEventArgs e)
        {

            int deger = Kayit_OL.sifre_inceleme(Sifre_kutusu.Password);
            if (deger < 33)
            {
                sifre_zorluk.Foreground = Brushes.Red;
                Sifre_Zorluk.Content = "Kötü";
            }
            else if (deger < 66)
            {
                sifre_zorluk.Foreground = Brushes.Yellow;
                Sifre_Zorluk.Content = "Orta";
            }
            else if (deger < 99)
            {
                sifre_zorluk.Foreground = Brushes.Green;
                Sifre_Zorluk.Content = "İyi";
            }
            sifre_zorluk.Value = deger;
        }

        private void Giris_Yap_Click(object sender, RoutedEventArgs e)
        {
            MainWindow f = new MainWindow();
            f.Show();
            this.Hide();
        }
    }
}
