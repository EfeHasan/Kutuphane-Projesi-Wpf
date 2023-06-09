using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Diagnostics;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kütüphane_Projesi_wpf
{
    /// <summary>
    /// Kullanicilari_görüntüle.xaml etkileşim mantığı
    /// </summary>
    public partial class Kullanicilari_görüntüle : Window
    {
        public Kullanicilari_görüntüle()
        {
            InitializeComponent();
        }
        int i, a, c;
        private void İsim_Bul_Click(object sender, RoutedEventArgs e)
        {
            i++;
            if (i % 2 == 0) 
            {
                kullanici_goruntule goruntuleri = new kullanici_goruntule
                {
                    Isim=Isim_Box.Text
                };
                goruntuleri.kullanicilar.Clear();
                listview.Items.Refresh();
                goruntuleri.isime_gore();
                listview.ItemsSource = goruntuleri.kullanicilar;
                Isim_Box.IsEnabled = false;
            }
            else
            {
                Isim_Box.IsEnabled = true;
            }
        }

        private void Yetkiye_Gore_Click(object sender, RoutedEventArgs e)
        {
            c++;
            if(c% 2 == 0)
            {
                kullanici_goruntule goruntuleri = new kullanici_goruntule
                {
                    yetki = yetkiler.SelectedItem.ToString()
                };
                goruntuleri.kullanicilar.Clear();
                listview.Items.Refresh();
                goruntuleri.soyisime_gore();
                listview.ItemsSource = goruntuleri.kullanicilar;
                yetkiler.IsEnabled = false;
            }
            else
            {
                yetkiler.IsEnabled = true;
            }
        }

        private void Ana_Menu_Click(object sender, RoutedEventArgs e)
        {
            Ana_Menu menu = new Ana_Menu();
            menu.Show();
            this.Hide();
        }

        private void soyisime_gore_Click(object sender, RoutedEventArgs e)
        {
            a++;
            if (a % 2 == 0)
            {
                kullanici_goruntule goruntuleri = new kullanici_goruntule
                {
                    Soy_Isim = Soyisim_Box.Text
                };
                goruntuleri.kullanicilar.Clear();
                listview.Items.Refresh();
                goruntuleri.soyisime_gore();
                listview.ItemsSource = goruntuleri.kullanicilar;
                Soyisim_Box.IsEnabled = false;
            }
            else
            {
                Soyisim_Box.IsEnabled = true;
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Isim_Box.IsEnabled = false;
            Soyisim_Box.IsEnabled = false;
            yetkiler.Items.Add("kullanıcı");
            yetkiler.Items.Add("yetkili");
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            alinmasi_gerekenler gerek = new alinmasi_gerekenler();
            gerek.ne_sectim();
        }
    }
}
