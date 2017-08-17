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
            ToAddQuestionCommand = new DelegateCommand<Window>(ToAddQuestion);
            ToEditQuestionCommand = new DelegateCommand<Window>(ToEditQuestion);//dodac canExecute jak bedzi juz pole z id
            AddDatabaseCommand = new DelegateCommand(AddDatabase, CanAddDatabase);
            DeleteDatabaseCommand = new DelegateCommand(DeleteDatabase);
            repo = new TestRepository(new TestownikContext());
            TestList = new ObservableCollection<Model.Test>(repo.GetAllTests());
        }

        private void questionListUpdate()
        {
            // QuestionList = QuestionRepo pytania do danego testu
            /*var tmp = new ObservableCollection<Question>()
            {
                new Question {QuestionNo = 1, Content= "pytanie 1"},
                new Question {QuestionNo = 2, Content= "pytanie 2"},
                new Question {QuestionNo = 3, Content= "pytanie 3",Photo = new byte[] {1,2}},
                new Question {QuestionNo = 4, Content= "pytanie 4"}
            };
            QuestionList = tmp;//tymczasowo*/

            QuestionList = new ObservableCollection<Question>(repo.GetQuestionsForTest(selectedTest.Ref));
        }

        private void answerListUpdate()
        {
            // AnswereList = odpowiedzi do danego pytania
            /*var tmp = new ObservableCollection<Answer>()
            {
                new Answer {Content="odpowiedz 1 bardzo dluga bardzo dluga bardzo dluga bardzo dluga bardzo dluga", Correct = true },
                new Answer {Content="odpowiedz 2", Correct = false },
                new Answer {Content="odpowiedz 3", Correct = true },
                new Answer {Content="odpowiedz 4", Correct = true },
                new Answer {Content="odpowiedz 5", Correct = false },
                new Answer {Content="odpowiedz 6", Correct = false }
            };
            AnswereList = tmp;//tymczasowo*/
            AnswerList = new ObservableCollection<Answer>(repo.GetAnswersForQuestions(selectedQuestion.Ref));
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

        private void DeleteDatabase()
        {
            //jeszcze trzeba usunac kaskadowo wszystko ale wywala wyjatek ze nie ma takiej kolumny
            repo.DeleteTest(SelectedTest);
            TestList = new ObservableCollection<Model.Test>(repo.GetAllTests());
        }
        //Commands end
    }
}
