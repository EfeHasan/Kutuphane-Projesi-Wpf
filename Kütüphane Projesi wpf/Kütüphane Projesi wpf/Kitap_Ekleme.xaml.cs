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
    /// Kitap_Ekleme.xaml etkileşim mantığı
    /// </summary>
    public partial class Kitap_Ekleme : Window
    {
        public Kitap_Ekleme()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

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
                kitap_turu.Items.Add(kitapTurleri[i]);
            }
        }

        private void kitap_turu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public static string degisecek = "";

        private void Kitap_Ekle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string kitap_ismi, kitap_yazari1, kitap_turu1;
                string durumu = "boş";
                DateTime basim_tarihi = Convert.ToDateTime(tarih.Text);
                kitap_ismi = Kitap_Ismi.Text;
                kitap_yazari1 = kitap_yazari.Text;
                kitap_turu1 = kitap_turu.Text;

                Kitap_Islemleri kitap_Ekleme = new Kitap_Islemleri(kitap_ismi, kitap_yazari1, durumu, kitap_turu1, basim_tarihi);
                kitap_Ekleme.kitap_ekle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata var");
            }

        }

        private void ana_menu_Click(object sender, RoutedEventArgs e)
        {
            Ana_Menu f = new Ana_Menu();
            f.Show();
            this.Hide();
        }

        private void Kitabı_Sil_Click(object sender, RoutedEventArgs e)
        {
            string kitap_ismi, kitap_yazari1, kitap_turu1;
            string durumu = "boş";
            DateTime basim_tarihi = Convert.ToDateTime(tarih.Text);
            kitap_ismi = Kitap_Ismi.Text;
            kitap_yazari1 = kitap_yazari.Text;
            kitap_turu1 = kitap_turu.Text;
            Kitap_Islemleri kitap_silme = new Kitap_Islemleri(kitap_ismi, kitap_yazari1, durumu, kitap_turu1, basim_tarihi);
            kitap_silme.kitap_sil();
        }

        private void kitabı_değiştir_Click(object sender, RoutedEventArgs e)
        {

        }
        string kitap = "kitap_isimi";
        private void Yazari_degistir_Click(object sender, RoutedEventArgs e)
        {
            degisecek = "yazar";
            string kitap_ismi, kitap_yazari1, kitap_turu1;
            string durumu = "boş";
            DateTime basim_tarihi = Convert.ToDateTime(tarih.Text);
            kitap_ismi = Kitap_Ismi.Text;
            kitap_yazari1 = kitap_yazari.Text;
            kitap_turu1 = kitap_turu.Text;
            string update = "update kitaplar set kitap_yazari=@kitap_yazari where kitap_isimi=@kitap_isimi";

            Kitap_Islemleri kitap_Ekleme = new Kitap_Islemleri(kitap_ismi, kitap_yazari1, durumu, kitap_turu1, basim_tarihi);
            int deger = kitap_Ekleme.degistir(update, "@kitap_yazari", kitap, kitap_yazari1, kitap_ismi);
            if (deger > 0)
            {
                MessageBox.Show("İşlem Başarılı");
            }
            else
            {
                MessageBox.Show("İşlem Başarısız");
            }
        }

        private void tarihini_Click(object sender, RoutedEventArgs e)
        {
            
            degisecek = "tarih";
            string kitap_ismi, kitap_yazari1, kitap_turu1;
            string durumu = "boş";
            DateTime basim_tarihi = Convert.ToDateTime(tarih.Text);
            kitap_ismi = Kitap_Ismi.Text;
            kitap_yazari1 = kitap_yazari.Text;
            kitap_turu1 = kitap_turu.Text; 
            string update = "update kitaplar set basim_tarihi=@basim_tarihi where kitap_isimi=@kitap_isimi";

            Kitap_Islemleri kitap_Ekleme = new Kitap_Islemleri(kitap_ismi, kitap_yazari1, durumu, kitap_turu1, basim_tarihi);
            int deger = kitap_Ekleme.degistir(update, "@basim_tarihi", kitap, basim_tarihi.ToString(), kitap_ismi);

            if (deger > 0) 
            {
                MessageBox.Show("işlem başarılı");
            }
            else
            {
                MessageBox.Show("başarısız");
            }
        }

        private void Turu_degistir_Click(object sender, RoutedEventArgs e)
        {
            degisecek = "tür";
            string kitap_ismi, kitap_yazari1, kitap_turu1;
            string durumu = "boş";
            DateTime basim_tarihi = Convert.ToDateTime(tarih.Text);
            kitap_ismi = Kitap_Ismi.Text;
            kitap_yazari1 = kitap_yazari.Text;
            kitap_turu1 = kitap_turu.Text;
            
            string update = "update kitaplar set kitap_turu=@kitap_turu where kitap_isimi=@kitap_isimi";

            Kitap_Islemleri kitap_Ekleme = new Kitap_Islemleri(kitap_ismi, kitap_yazari1, durumu, kitap_turu1, basim_tarihi);
            int deger = kitap_Ekleme.degistir(update, "@kitap_turu", kitap, kitap_turu1, kitap_ismi);
            if (deger > 0)
            {
                MessageBox.Show("işlem başarılı");
            }
            else
            {
                MessageBox.Show("başarısız");
            }

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            alinmasi_gerekenler gerek = new alinmasi_gerekenler();
            gerek.ne_sectim();
        }
    }
}
