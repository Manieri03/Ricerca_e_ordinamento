using System;
using System.Collections.Generic;
using System.IO;
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

namespace Ricerca_e_ordinamento
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<string> lista = new List<string>();
        private void btninserisci_Click(object sender, RoutedEventArgs e)
        {
            string ragazzo = txtnome.Text;
            lista.Add(ragazzo);
            lista.Sort();
            txtlista.Text = null;


            foreach (string r in lista)
            {
                txtlista.Text += $"{r} \n";
            }
            txtnome.Text = null;
        }

        private void btnsalva_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("file.txt", false, Encoding.UTF8))
            {
                foreach (string r in lista)
                {
                    sw.WriteLine(r);
                }
                
            }
            MessageBox.Show("L'elenco degli studenti è stato salvato su un file di testo", "Informazione", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btncerca_Click(object sender, RoutedEventArgs e)
        {
            string ricerca = txtricerca.Text;
            bool stato= false;
            for (int i=0; i < lista.Count; i++)
            {
                if(lista[i] == ricerca)
                {
                    stato = true;
                    break;
                }
                
            }
            if (stato == true)
            {
                lblcerca.Content = "Il nome è contenuto nella lista";
            }
            else
            {
                lblcerca.Content = "Il nome non è contenuto nella lista";
            }
        }
    }
}
