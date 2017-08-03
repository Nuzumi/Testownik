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
    /// Logika interakcji dla klasy UczenieSie.xaml
    /// </summary>
    public partial class UczenieSie : Window
    {
        List<Odpowiedz> odpowiedzList = new List<Odpowiedz>();

        public UczenieSie()
        {
            InitializeComponent();

            odpowiedzList.Add(new Odpowiedz() { Tekst = "tekst odpowiedzi 1" });
            odpowiedzList.Add(new Odpowiedz() { Tekst = "tekst odpowiedzi 2" });
            odpowiedzList.Add(new Odpowiedz() { Tekst = "tekst odpowiedzi 3" });
            odpowiedzList.Add(new Odpowiedz() { Tekst = "tekst odpowiedzi 4" });
            odpowiedzList.Add(new Odpowiedz() { Tekst = "tekst odpowiedzi 5" });
            odpowiedzList.Add(new Odpowiedz() { Tekst = "tekst odpowiedzi 6" });
            odpowiedzList.Add(new Odpowiedz() { Tekst = "tekst odpowiedzi 7" });
            odpowiedzList.Add(new Odpowiedz() { Tekst = "tekst odpowiedzi 8" });

            odpowiedziListView.ItemsSource = odpowiedzList;
        }
    }

}
