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
    class AddEditQuestionVM : BindableBase
    {
        public ICommand GoBackCommand { get; set; }

        private WindowsTypes previousWindowType;

        public AddEditQuestionVM(WindowsTypes windowType)
        {
            previousWindowType = windowType;
            GoBackCommand = new DelegateCommand<Window>(GoBack);
        }

        public AddEditQuestionVM(WindowsTypes windowType, int questionId)
        {
            previousWindowType = windowType;
            GoBackCommand = new DelegateCommand<Window>(GoBack);
        }

        private void GoBack(Window window)
        {
            Window backWindow = null;
            switch (previousWindowType)
            {
                case WindowsTypes.Browser:
                    backWindow = new BaseQuestionBrowser();
                    BaseQuestionBrowserVM dataContextB = new BaseQuestionBrowserVM();
                    backWindow.DataContext = dataContextB;
                    break;

                case WindowsTypes.Test:/*
                    backWindow = new Test();
                    TestVM dataContextT = new TestVM();
                    backWindow.DataContext = dataContextT;*/
                    break;
            }

            backWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            backWindow.Show();
            window.Close();
        }
    }
}
