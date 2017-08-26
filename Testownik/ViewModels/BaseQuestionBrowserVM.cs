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
        public TestRepository repo;

        // properties start
        public ICommand ToMainWindowCommand { get; set; }
        public ICommand ToAddQuestionCommand { get; set; }
        public ICommand ToEditQuestionCommand { get; set; }
        public ICommand AddDatabaseCommand { get; set; }
        public ICommand DeleteDatabaseCommand { get; set; }
        public ICommand DeleteQuestionCommand { get; set; }
        public ICommand DeleteAnswerCommand { get; set; }

        public byte[] QuestionImage { get; set; }

        private ObservableCollection<Model.Test> testList;
        public ObservableCollection<Model.Test> TestList
        {
            get { return testList; }
            set { SetProperty(ref testList, value); }
        }

        private ObservableCollection<Question> questionList;
        public ObservableCollection<Question> QuestionList
        {
            get { return questionList; }
            set { SetProperty(ref questionList, value); }
        }

        private ObservableCollection<Answer> answerList;
        public ObservableCollection<Answer> AnswerList
        {
            get { return answerList; }
            set { SetProperty(ref answerList, value); }
        }

        private Model.Test selectedTest;
        public Model.Test SelectedTest
        {
            get { return selectedTest; }
            set
            {
                SetProperty(ref selectedTest, value);
                questionListUpdate();
                (ToAddQuestionCommand as DelegateCommand<Window>).RaiseCanExecuteChanged();
            }
        }

        private Question selectedQuestion;
        public Question SelectedQuestion
        {
            get { return selectedQuestion; }
            set
            {
                SetProperty(ref selectedQuestion, value);
                answerListUpdate();
                PictureUpdate();
                (ToEditQuestionCommand as DelegateCommand<Window>).RaiseCanExecuteChanged();
            }
        }

        private Answer selectedAnswer;
        public Answer SelectedAnswer
        {
            get { return selectedAnswer; }
            set
            {
                SetProperty(ref selectedAnswer, value);
            }
        }

        private bool hasQuestionPicture;
        public bool HasQuestionPicture
        {
            get { return hasQuestionPicture; }
            set { SetProperty(ref hasQuestionPicture, value); }
        }
        //properties end        

        public BaseQuestionBrowserVM()
        {
            prepare();
        }

        public BaseQuestionBrowserVM(int selectedTestId)
        {
            prepare();
            SelectedTest = repo.GetTestById(selectedTestId);
        }

        public void prepare()
        {
            ToMainWindowCommand = new DelegateCommand<Window>(ToMainWindow);
            ToAddQuestionCommand = new DelegateCommand<Window>(ToAddQuestion, CanGoToAddWindow);
            ToEditQuestionCommand = new DelegateCommand<Window>(ToEditQuestion, CanGoToEditWindow);
            AddDatabaseCommand = new DelegateCommand(AddDatabase, CanAddDatabase);
            DeleteDatabaseCommand = new DelegateCommand(DeleteDatabase);
            DeleteQuestionCommand = new DelegateCommand(DeleteQuestion);
            DeleteAnswerCommand = new DelegateCommand(DeleteAnswer);
            repo = new TestRepository(new TestownikContext());
            TestList = new ObservableCollection<Model.Test>(repo.GetAllTests());
        }

        private void questionListUpdate()
        {
            QuestionList = new ObservableCollection<Question>(repo.GetQuestionsForTest(selectedTest.Ref));
        }

        private void answerListUpdate()
        {
            if(SelectedQuestion != null)
            {
                AnswerList = new ObservableCollection<Model.Answer> (repo.GetAnswersForQuestions(SelectedQuestion.Ref));
            }
            // jak sie usuwa ostatnie pytanie to 
        }

        private void PictureUpdate()
        {
            if (selectedQuestion != null)
            {
                if (SelectedQuestion.Photo != null)
                {
                    HasQuestionPicture = true;
                    QuestionImage = SelectedQuestion.Photo;
                }
                else
                {
                    HasQuestionPicture = false;
                }
            }
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
            AddEditQuestionVM addEditVM = new AddEditQuestionVM(WindowsTypes.Browser, selectedTest.Ref );
            addEdit.DataContext = addEditVM;
            addEdit.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addEdit.Show();
            window.Close();
        }

        private void ToEditQuestion(Window window)
        {
            AddEditQuestion addEdit = new AddEditQuestion();
            AddEditQuestionVM addEditVM = new AddEditQuestionVM(WindowsTypes.Browser, SelectedQuestion.RefTest, SelectedQuestion.Ref);// tu jeszcze dodac id wybranego pytania
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

        private void DeleteDatabase()
        {
            repo.DeleteTest(SelectedTest);
            TestList = new ObservableCollection<Model.Test>(repo.GetAllTests());
        }

        private void DeleteQuestion()
        {
            repo.DeleteQuestion(SelectedQuestion);
            repo.SaveChanges();
            QuestionList = new ObservableCollection<Model.Question>(repo.GetQuestionsForTest(selectedTest.Ref));
        }

        private void DeleteAnswer()
        {
            repo.DeleteAnswer(SelectedAnswer);
            repo.SaveChanges();
            AnswerList = new ObservableCollection<Model.Answer>(repo.GetAnswersForQuestions(selectedQuestion.Ref));
        }

        private bool CanGoToEditWindow(Window dummyWindow)
        {
            if (SelectedQuestion != null)
            {
                if (SelectedQuestion is Model.Question)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CanGoToAddWindow(Window dummyWindow)
        {
            if (SelectedTest != null)
            {
                if (SelectedTest is Model.Test)
                {
                    return true;
                }
            }
            return false;
        }
        //Commands end
    }
}
