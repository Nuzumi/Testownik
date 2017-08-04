using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Testownik.ViewModels
{
    class BaseQuestionBrowserVM : BindableBase
    {
        public ICommand ToMainWindowCommand { get; set; }
        public ICommand ToAddQuestionCommand { get; set; }
        public ICommand ToEditQuestionCommand { get; set; }

        public BaseQuestionBrowserVM()
        {
            ToMainWindowCommand = new DelegateCommand<Window>(ToMainWindow);
            ToAddQuestionCommand = new DelegateCommand<Window>(ToAddQuestion);
            ToEditQuestionCommand = new DelegateCommand<Window>(ToEditQuestion);//dodac canExecute jak bedzi juz pole z id
        }

        private void ToMainWindow(Window window)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mainWindow.Show();
            window.Close();
        }

        private void ToAddQuestion(Window window)
        {
            AddEditQuestion addEdit = new AddEditQuestion();
            AddEditQuestionVM addEditVM = new AddEditQuestionVM(WindowsTypes.Browser);
            addEdit.DataContext = addEditVM;
            addEdit.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addEdit.Show();
            window.Close();
        }

        private void ToEditQuestion(Window window)
        {
            AddEditQuestion addEdit = new AddEditQuestion();
            AddEditQuestionVM addEditVM = new AddEditQuestionVM(WindowsTypes.Browser);// tu jeszcze dodac id wybranego pytania
            addEdit.DataContext = addEditVM;
            addEdit.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addEdit.Show();
            window.Close();
        }

    }
}
