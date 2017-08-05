using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Testownik.ViewModels
{
    class AddDatabaseDialogVM : BindableBase
    {
        public string DatabaseName { get; set; }
        public string DatabaseTeacherName { get; set; }

        public ICommand OkCommand { get; set; }
        public ICommand CancleCommand { get; set; }

        private BaseQuestionBrowserVM previousWindow;

        public AddDatabaseDialogVM(BaseQuestionBrowserVM previousWindow)
        {
            OkCommand = new DelegateCommand<Window>(OkPress);
            CancleCommand = new DelegateCommand<Window>(CanclePress);
            this.previousWindow = previousWindow;
        }

        private void OkPress(Window window)
        {
            if (!string.IsNullOrEmpty(DatabaseName))
            {
                previousWindow.CanOpenAddDatabaseDialogWindow = true;
                //tu sie doda baze do bazy
                MessageBox.Show(DatabaseName + " " + DatabaseTeacherName);
                window.Close();
            }
            else
            {
                MessageBox.Show("podaj nazwe bazy");
            }
            
        }

        private void CanclePress(Window window)
        {
            previousWindow.CanOpenAddDatabaseDialogWindow = true;
            window.Close();
        }


    }
}
