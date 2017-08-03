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
    class TestVM : BindableBase
    {
        public ICommand ToMainWindowCommand { get; set; }
        public ICommand ToEditQuestionCommand { get; set; }

        public TestVM()
        {
            ToMainWindowCommand = new DelegateCommand<Window>(ToMainWindow);
            ToEditQuestionCommand = new DelegateCommand<Window>(ToEditQuestion);
        }

        private void ToMainWindow(Window window)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mainWindow.Show();
            window.Close();
        }

        private void ToEditQuestion(Window window)
        {
            AddEditQuestion addEdit = new AddEditQuestion();
            AddEditQuestionVM dataContext = new AddEditQuestionVM(WindowsTypes.Test);
            addEdit.DataContext = dataContext;
            addEdit.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addEdit.Show();
            window.Close();
        }
    }
}
