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

namespace Testownik
{
    /// <summary>
    /// Logika interakcji dla klasy DodajEdytuj.xaml
    /// </summary>
    public partial class DodajEdytuj : Window
    {
        List<Odpowiedz> odpowiedzi = new List<Odpowiedz>();

        public DodajEdytuj()
        {
            InitializeComponent();

            odpowiedzi.Add(new Odpowiedz() { Tekst = "tekst 1" });
            odpowiedzi.Add(new Odpowiedz() { Tekst = "tekst 2", Poprawna = true});
            odpowiedzi.Add(new Odpowiedz() { Tekst = "tekst 3" });

            odpowiedziListView.ItemsSource = odpowiedzi;

        }
    }
}
