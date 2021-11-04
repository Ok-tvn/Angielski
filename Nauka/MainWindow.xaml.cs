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
using System.IO;

namespace Nauka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        Random losowa = new Random(0);
        int max;
        int zmienna=1;
        string[,] table = new string[100, 2];
        string[] lines;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void zatwierdz_btn_Click(object sender, RoutedEventArgs e)
        {
            string odpowiedz=wyswietl_inp.Text;
            if(odpowiedz==lines[zmienna-1])
            {
                poprawna_odp.Content = "Dobra odpowiedź!!";
            }
            else
            {
                poprawna_odp.Content = "Źle. Poprawna odpowiedź to: "+lines[zmienna-1];
            }
        }

        private void otworz_btn_Click(object sender, RoutedEventArgs e)
        {
            lines = System.IO.File.ReadAllLines(@"C:\Users\oktaw\Desktop\slowa.txt");
            pl_wyswietl.Content= lines[zmienna].ToString();
        }

        private void nastepny_btn_Click(object sender, RoutedEventArgs e)
        {
            if (zmienna < 292)
            {
                zmienna += 2;
                pl_wyswietl.Content = lines[zmienna].ToString();
                poprawna_odp.Content = " ";
                wyswietl_inp.Clear();
            }
            else
            {
                pl_wyswietl.Content = "Dobiłeś do maksa";
            }
            
        }

        private void poprzedni_btn_Click(object sender, RoutedEventArgs e)
        {
            if (zmienna > 1)
            {
                zmienna -= 2;
                pl_wyswietl.Content = lines[zmienna].ToString();
                poprawna_odp.Content = " ";
                wyswietl_inp.Clear();
            }
            else
            {
                pl_wyswietl.Content = "dobiłeś do minimum";
            }
            
        }

        private void losuj_btn_Click(object sender, RoutedEventArgs e)
        {
            int min = 1;
            int max = 292;
            zmienna = (2 * losowa.Next(min / 2, max / 2))+1;
            pl_wyswietl.Content = lines[zmienna].ToString();
            poprawna_odp.Content = " ";
            wyswietl_inp.Clear();
        }
    }
}
