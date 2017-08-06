using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Testownik.Model;
using Testownik.Repository;

namespace Testownik.ViewModels
{
    public class MainWindowVM : BindableBase
    {
        public RWRepository<Model.Test> testRepo;

        // properties start
        public ICommand ToBrowserCommand { get; set; }
        public ICommand ToTestCommand { get; set; }

        public ObservableCollection<Model.Test> TestList { get; set; }

        private Model.Test selectedTest;
        public Model.Test SelectedTest
        {
            get{ return selectedTest;}
            set
            {
                SetProperty(ref selectedTest, value);
                UpdateQuestionAmount();
            }
        }

        private int selectedTestQuestionAmount;
        public int SelectedTestQuestionAmount
        {
            get { return selectedTestQuestionAmount; }
            set { SetProperty(ref selectedTestQuestionAmount, value); }
        }
        // properties end

        public MainWindowVM()
        {
            ToBrowserCommand = new DelegateCommand<Window>(ToBrowser);
            ToTestCommand = new DelegateCommand<Window>(ToTest);
            testRepo = new RWRepository<Model.Test>(new TestownikContext());
            TestList = new ObservableCollection<Model.Test>(testRepo.GetAll());
        }

        private void UpdateQuestionAmount()
        {
            SelectedTestQuestionAmount = 10;
        }

        //Commends Start
        private void ToBrowser(Window window)
        {
            BaseQuestionBrowserVM dataContext;
            if (SelectedTest != null)
            {
                dataContext = new BaseQuestionBrowserVM(SelectedTest.Ref);
            }
            else
            {
                dataContext = new BaseQuestionBrowserVM();
            }
            BaseQuestionBrowser trybEdycji = new BaseQuestionBrowser();
            trybEdycji.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            trybEdycji.DataContext = dataContext;
            trybEdycji.Show();
            window.Close();
        }

        private void ToTest(Window window)
        {
            Test test = new Test();
            TestVM testVM = new TestVM();
            test.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            test.DataContext = testVM;
            test.Show();
            window.Close();
        }
        //Commends End
    }
}
