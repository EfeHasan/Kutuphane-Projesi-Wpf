using MySql.Data.MySqlClient;
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
using System.Windows.Shapes;

namespace Kütüphane_Projesi_wpf
{
    /// <summary>
    /// Kitapları_Görüntüler.xaml etkileşim mantığı
    /// </summary>
    public partial class Kitapları_Görüntüler : Window
    {
        public Kitapları_Görüntüler()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        int click_1 = 0;
        int click_2 = 0;
        int click_3 = 0;
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            string[] kitapTurleri = new string[]
{
                "Roman",
                "Polisiye",
                "Bilim Kurgu",
                "Fantastik",
                "Korku/Gerilim",
                "Macera",
                "Tarih",
                "Biyografi",
                "Otobiyografi",
                "Felsefe",
                "Mizah",
                "Drama",
                "Aşk/Romantik",
                "Çocuk ve Gençlik",
                "Edebiyat Klasikleri",
                "İş ve Yönetim",
                "Sağlık ve Fitness",
                "Sanat ve Tasarım",
                "Eğitim",
                "Din ve Mitoloji",
                "Gezi ve Keşif",
                "Bilim ve Teknoloji",
                "Psikoloji",
                "İçerik Pazarlama",
                "Yemek Kitapları"
};
            for (int i = 0; i < kitapTurleri.Length; i++)
            {
                Tur_Kutusu.Items.Add(kitapTurleri[i]);
            }
            Kitap_ismi.IsEnabled = false;
            kitap_isimi_text.IsEnabled = false;
            
            Kitap_turu_text.IsEnabled = false;
            Tur_Kutusu.IsEnabled = false;
        }

        private void Kitap_Bul_Click(object sender, RoutedEventArgs e)
        {
    
            click_1++;
            if (click_1 % 2 == 0) 
            {
                listview.Items.Refresh();

                kitaplari_goruntuleri k = new kitaplari_goruntuleri();
                k.kitap_isimi = Kitap_ismi.Text;
                k.isime_gore();
                listview.ItemsSource = kitaplari_goruntuleri.sonuc;
                Kitap_ismi.IsEnabled = false;
                kitap_isimi_text.IsEnabled = false;
                Kitap_ismi.Text = "";
            }

            else
            {
                Kitap_ismi.IsEnabled = true;
                kitap_isimi_text.IsEnabled = true;
            }
        }

        private void Ture_Gore_Sirala_Click(object sender, RoutedEventArgs e)
        {
            click_2++;
            if(click_2 % 2 == 0)
            {
                listview.Items.Refresh();
                kitaplari_goruntuleri k = new kitaplari_goruntuleri();
                k.secilen_tur = Tur_Kutusu.SelectedItem.ToString();
                k.turlere_gore();
                listview.ItemsSource = kitaplari_goruntuleri.sonuc1;
                Kitap_turu_text.IsEnabled = false;
                Tur_Kutusu.IsEnabled = false;
                Tur_Kutusu.Text = "";
            }

            else
            {
                Kitap_turu_text.IsEnabled = true;
                Tur_Kutusu.IsEnabled = true;
            }
        }

        private void Ana_Menu_Click(object sender, RoutedEventArgs e)
        {
            Ana_Menu f =new Ana_Menu();
            f.Show();
            this.Hide();
        }

        private void Tarihe_Sirala_Click(object sender, RoutedEventArgs e)
        {
            click_3++;
            if(click_3 % 2 == 0)
            {
                listview.Items.Refresh();
                kitaplari_goruntuleri kitaplari = new kitaplari_goruntuleri();
                kitaplari.tarihe_Gore_Kucul();
                listview.ItemsSource = kitaplari_goruntuleri.sonuc2;
            }

            else
            {
                listview.Items.Refresh();
                kitaplari_goruntuleri kitaplari = new kitaplari_goruntuleri();
                kitaplari.tarihe_Gore_Yuksel();
                listview.ItemsSource = kitaplari_goruntuleri.sonuc2;
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            alinmasi_gerekenler gerek = new alinmasi_gerekenler();
            gerek.ne_sectim();
        }
    }
}
