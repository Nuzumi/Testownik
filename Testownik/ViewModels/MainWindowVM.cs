using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Testownik.ViewModels
{
    public class MainWindowVM : BindableBase
    {
        public ICommand TrybEdycjiCommand { get; set; }

        public MainWindowVM()
        {
            TrybEdycjiCommand = new DelegateCommand<Window>(ToTrybEdycji);
        }

        private void ToTrybEdycji(Window window)
        {
            BaseQuestionBrowser trybEdycji = new BaseQuestionBrowser();
            trybEdycji.Show();
            window.Close();
        }
    }
}
