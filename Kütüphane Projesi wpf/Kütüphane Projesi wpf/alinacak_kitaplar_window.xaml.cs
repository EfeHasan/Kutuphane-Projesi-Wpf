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
    /// alinacak_kitaplar_window.xaml etkileşim mantığı
    /// </summary>
    public partial class alinacak_kitaplar_window : Window
    {
        public alinacak_kitaplar_window()
        {
            InitializeComponent();
        }

        private void Ana_Menu_Click(object sender, RoutedEventArgs e)
        {
            Ana_Menu f = new Ana_Menu();
            f.Show();
            this.Hide();
        }

        private void Goruntule_Click(object sender, RoutedEventArgs e)
        {
            alinmasi_gerekenler alinacaklar = new alinmasi_gerekenler();
            alinacaklar.emanetler1.Clear();
            listview.Items.Refresh();
            alinacaklar.goruntule();
            listview.ItemsSource = alinacaklar.emanetler1;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            alinmasi_gerekenler gerek = new alinmasi_gerekenler();
            gerek.ne_sectim();
        }
    }
}
