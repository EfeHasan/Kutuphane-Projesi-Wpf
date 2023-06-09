using MySql.Data.MySqlClient;
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
using MySql.Data.MySqlClient;
namespace Kütüphane_Projesi_wpf
{
    /// <summary>
    /// emanet_ekle_window.xaml etkileşim mantığı
    /// </summary>
    public partial class emanet_ekle_window : Window
    {
        public emanet_ekle_window()
        {
            InitializeComponent();
        }

        private void Emanet_Al_Click(object sender, RoutedEventArgs e)
        {
            emanet_islmeleri emanet_ = new emanet_islmeleri
            {
                kitap_ismi = Kitap_Ismi.Text,
                tc_kimlik = Tc_Kimlik.Text,
                soyisim = Soyisminizi_Giriniz.Text,
                isim = İsmnizi_Giriniz.Text
            };
            emanet_.ekle();

        }

        private void Emanet_Ver_Click(object sender, RoutedEventArgs e)
        {
            emanet_islmeleri emanet_ = new emanet_islmeleri
            {
                tc_kimlik = Tc_Kimlik.Text,
                isim = İsmnizi_Giriniz.Text,
                kitap_ismi=Kitap_Ismi.Text
                
            };
            emanet_.sil();
        }

        private void sil_Click(object sender, RoutedEventArgs e)
        {
            emanet_islmeleri emanet_ = new emanet_islmeleri
            {
                kitap_ismi = Kitap_Ismi.Text
            };
            emanet_.komple_sil();
        }

        private void Ana_Menu_Click(object sender, RoutedEventArgs e)
        {
            Ana_Menu f = new Ana_Menu();
            f.Show();
            this.Hide();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            alinmasi_gerekenler gerek = new alinmasi_gerekenler();
            gerek.ne_sectim();
        }
    }
}
