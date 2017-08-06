using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Testownik.Model;
using Testownik.Repository;

namespace Testownik.ViewModels
{
    class BaseQuestionBrowserVM : BindableBase
    {
        public bool CanOpenAddDatabaseDialogWindow = true;
        public RWRepository<Model.Test> testRepo;
        public RWRepository<Question> questionRepo;

        // properties start
        public ICommand ToMainWindowCommand { get; set; }
        public ICommand ToAddQuestionCommand { get; set; }
        public ICommand ToEditQuestionCommand { get; set; }
        public ICommand AddDatabaseCommand { get; set; }

        public ObservableCollection<Model.Test> TestList { get; set; }
        public ObservableCollection<Question> QuestionList { get; set; }

        private Model.Test selectedTest;
        public Model.Test SelectedTest
        {
            get { return selectedTest; }
            set{ SetProperty(ref selectedTest, value); }
        }

        private Question selectedQuestion;
        public Question SelectedQuestion
        {
            get { return selectedQuestion; }
            set { SetProperty(ref selectedQuestion, value); }
        }
        //properties end        

        public BaseQuestionBrowserVM()
        {
            ToMainWindowCommand = new DelegateCommand<Window>(ToMainWindow);
            ToAddQuestionCommand = new DelegateCommand<Window>(ToAddQuestion);
            ToEditQuestionCommand = new DelegateCommand<Window>(ToEditQuestion);//dodac canExecute jak bedzi juz pole z id
            AddDatabaseCommand = new DelegateCommand(AddDatabase,CanAddDatabase);
            testRepo = new RWRepository<Model.Test>(new TestownikContext());
            questionRepo = new RWRepository<Question>(new TestownikContext());
            TestList = new ObservableCollection<Model.Test>(testRepo.GetAll());
        }

        public BaseQuestionBrowserVM(int selectedTestId)
        {
            ToMainWindowCommand = new DelegateCommand<Window>(ToMainWindow);
            ToAddQuestionCommand = new DelegateCommand<Window>(ToAddQuestion);
            ToEditQuestionCommand = new DelegateCommand<Window>(ToEditQuestion);//dodac canExecute jak bedzi juz pole z id
            AddDatabaseCommand = new DelegateCommand(AddDatabase, CanAddDatabase);
            testRepo = new RWRepository<Model.Test>(new TestownikContext());
            questionRepo = new RWRepository<Question>(new TestownikContext());
            TestList = new ObservableCollection<Model.Test>(testRepo.GetAll());
            SelectedTest = testRepo.GetById(selectedTestId);
        }

        //Command start
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

        private void AddDatabase()
        {
            CanOpenAddDatabaseDialogWindow = false;
            AddDatabaseDialogWindow dialog = new AddDatabaseDialogWindow();
            AddDatabaseDialogVM dataContext = new AddDatabaseDialogVM(this);
            dialog.DataContext = dataContext;
            dialog.Show();
        }

        private bool CanAddDatabase()
        {
            return CanOpenAddDatabaseDialogWindow;
        }
        //Commands end
    }
}
