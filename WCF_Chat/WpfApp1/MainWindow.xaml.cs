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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ServiceReference1;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(ekran.Text != client.MesajGetir())
            {
                ekran.Text = client.MesajGetir();
            }
        }

        private void Gonder_Button(object sender, RoutedEventArgs e)
        {
            ekran.Text = client.MesajEkle(txt1.Text);
            txt1.Text = string.Empty;
        }

        private void Sil_Button(object sender, RoutedEventArgs e)
        {
            client.MesajlariSil();
            ekran.Text = string.Empty;
            txt1.Text = string.Empty;
        }

        private void txt1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if(!string.IsNullOrEmpty(txt1.Text) && txt1.Text.Trim().Length != 0)
                {
                    Gonder_Button(sender, e);
                }
                else
                {
                    MessageBox.Show("Boş Mesaj Gönderilemez");
                    txt1.Text = string.Empty;
                }
            }
        }
    }
}
