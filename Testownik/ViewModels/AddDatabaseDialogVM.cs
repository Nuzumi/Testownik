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
using Testownik.Model;
using Testownik.Repository;

namespace Testownik.ViewModels
{
    class AddDatabaseDialogVM : BindableBase
    {
        public string DatabaseName { get; set; }
        public string DatabaseTeacherName { get; set; }

        public ICommand OkCommand { get; set; }
        public ICommand CancleCommand { get; set; }

        private BaseQuestionBrowserVM previousWindow;
        public RWRepository<Model.Test> testRepo;

        public AddDatabaseDialogVM(BaseQuestionBrowserVM previousWindow)
        {
            OkCommand = new DelegateCommand<Window>(OkPress);
            CancleCommand = new DelegateCommand<Window>(CanclePress);
            this.previousWindow = previousWindow;
            testRepo = new RWRepository<Model.Test>(new TestownikContext());
        }

        private void OkPress(Window window)
        {
            if (!string.IsNullOrEmpty(DatabaseName))
            {
                if (!string.IsNullOrEmpty(DatabaseTeacherName))
                {
                    testRepo.Create(new Model.Test { Name = DatabaseName, Teacher = DatabaseTeacherName });
                }
                else
                {
                    testRepo.Create(new Model.Test { Name = DatabaseName});
                }
                previousWindow.CanOpenAddDatabaseDialogWindow = true;
                previousWindow.TestList = new System.Collections.ObjectModel.ObservableCollection<Model.Test>(testRepo.GetAll());
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
