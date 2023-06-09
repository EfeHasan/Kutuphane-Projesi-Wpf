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
    /// emanet_görüntüle.xaml etkileşim mantığı
    /// </summary>
    public partial class emanet_görüntüle : Window
    {
        public emanet_görüntüle()
        {
            InitializeComponent();
        }

        private void Ana_Menu_Click(object sender, RoutedEventArgs e)
        {
            Ana_Menu f = new Ana_Menu();
            f.Show();
            this.Hide();
        }

        private void Kullanici_Bul_Click(object sender, RoutedEventArgs e)
        {
            emanet_goruntule emanet = new emanet_goruntule { Isim = Isim_Box.Text, SoyIsim = Soyisim_Box.Text };
            emanet.ciktilar.Clear();
            listview.Items.Refresh();
            emanet.isime_gore_bul();
            listview.ItemsSource = emanet.ciktilar;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        { 
        }

        private void Goruntule_Click(object sender, RoutedEventArgs e)
        {
            emanet_goruntule emanet = new emanet_goruntule();
            emanet.ciktilar.Clear();
            listview.Items.Refresh();
            emanet.goruntule();
            listview.ItemsSource = emanet.ciktilar;
        }
        int i;
        private void Tarihe_Sirala_Click(object sender, RoutedEventArgs e)
        {
            i++;
            emanet_goruntule emanet = new emanet_goruntule();
            emanet.ciktilar.Clear();
            listview.Items.Refresh();
            emanet.tarihe_gore(i);
            listview.ItemsSource= emanet.ciktilar;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            alinmasi_gerekenler gerek = new alinmasi_gerekenler();
            gerek.ne_sectim();
        }
    }
}
