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
        private TestRepository repo;

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
                (ToTestCommand as DelegateCommand<Window>).RaiseCanExecuteChanged();
            }
        }

        private int selectedTestQuestionAmount;
        public int SelectedTestQuestionAmount
        {
            get { return selectedTestQuestionAmount; }
            set { SetProperty(ref selectedTestQuestionAmount, value); }
        }

        private int questionRepetitionOnStart;
        public int QuestionRepetitionOnStart
        {
            get { return questionRepetitionOnStart; }
            set { SetProperty(ref questionRepetitionOnStart, value); }
        }

        private int questionRepetitionAftherBadAnswer;
        public int QuestionRepetitionAftherBadAnswer
        {
            get { return questionRepetitionAftherBadAnswer; }
            set { SetProperty(ref questionRepetitionAftherBadAnswer, value); }
        }

        private int questionRepetitionAtOnce;
        public int QuestionRepetitionAtOnce
        {
            get { return questionRepetitionAtOnce; }
            set { SetProperty(ref questionRepetitionAtOnce, value); }
        }
        // properties end

        public MainWindowVM()
        {
            repo = new TestRepository(new TestownikContext());
            ToBrowserCommand = new DelegateCommand<Window>(ToBrowser);
            ToTestCommand = new DelegateCommand<Window>(ToTest,CanGoToTest);
            TestList = new ObservableCollection<Model.Test>(repo.GetAllTests());
        }

        private void UpdateQuestionAmount()
        {
            SelectedTestQuestionAmount = SelectedTest.getQuestionsAmount();
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
            TestVM testVM = new TestVM(SelectedTest,QuestionRepetitionOnStart,QuestionRepetitionAftherBadAnswer,QuestionRepetitionAtOnce);
            test.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            test.DataContext = testVM;
            test.Show();
            window.Close();
        }

        private bool CanGoToTest(Window dummyWindow)
        {
            if(SelectedTest != null)
            {
                if(SelectedTest is Model.Test)
                {
                    if (SelectedTest.getQuestionsAmount() > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //Commends End
    }
}
