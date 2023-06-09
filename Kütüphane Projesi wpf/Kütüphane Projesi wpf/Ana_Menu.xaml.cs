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
    /// Ana_Menu.xaml etkileşim mantığı
    /// </summary>
    public partial class Ana_Menu : Window
    {
        public Ana_Menu()
        {
            InitializeComponent();
        }

        private void Giris_Yap_Click(object sender, RoutedEventArgs e)
        {
            Giris_Yap giris = new Giris_Yap("","");
            giris.kayitlari_sil();
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Kitap_Ekle_Click(object sender, RoutedEventArgs e)
        {
            Kitap_Ekleme f = new Kitap_Ekleme();
            f.Show();
            this.Hide();
        }

        private void Kitapl_Listele_Click(object sender, RoutedEventArgs e)
        {
            Kitapları_Görüntüler f = new Kitapları_Görüntüler();
            f.Show();
            this.Hide();
        }

        private void Emanet_Ekle_Click(object sender, RoutedEventArgs e)
        {
            emanet_ekle_window f = new emanet_ekle_window();
            f.Show();
            this.Hide();
        }

        private void Emanetleri_Görüntüle_Click(object sender, RoutedEventArgs e)
        {
            emanet_görüntüle f = new emanet_görüntüle();
            f.Show();
            this.Hide();
        }

        private void Kullanici_Ekle_Click(object sender, RoutedEventArgs e)
        {
            Kullanici_Ekle a = new Kullanici_Ekle();
            a.Show();
            this.Hide();
        }

        private void Kullanicilari_Gor_Click(object sender, RoutedEventArgs e)
        {
            Kullanicilari_görüntüle a = new Kullanicilari_görüntüle();
            a.Show();
            this.Hide();
        }

        private void alinmasi_gerekenler_Click(object sender, RoutedEventArgs e)
        {
            alinacak_kitaplar_window a = new alinacak_kitaplar_window();
            a.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            alinmasi_gerekenler gerek = new alinmasi_gerekenler();
            gerek.ne_sectim();
        }
    }
}
