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
        public byte[] QuestionImage { get; set; }

        private ObservableCollection<Question> questionList;
        public ObservableCollection<Question> QuestionList
        {
            get { return questionList; }
            set { SetProperty(ref questionList, value); }
        }

        private ObservableCollection<Answer> answerList;
        public ObservableCollection<Answer> AnswereList
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
            SelectedTest = testRepo.GetById(selectedTestId);
        }

        public void prepare()
        {
            ToMainWindowCommand = new DelegateCommand<Window>(ToMainWindow);
            ToAddQuestionCommand = new DelegateCommand<Window>(ToAddQuestion);
            ToEditQuestionCommand = new DelegateCommand<Window>(ToEditQuestion);//dodac canExecute jak bedzi juz pole z id
            AddDatabaseCommand = new DelegateCommand(AddDatabase, CanAddDatabase);
            testRepo = new RWRepository<Model.Test>(new TestownikContext());
            questionRepo = new RWRepository<Question>(new TestownikContext());
            TestList = new ObservableCollection<Model.Test>(testRepo.GetAll());
            TestList.Add(new Model.Test { Name = "test2" ,Ref = 2});
        }

        private void questionListUpdate()
        {
            // QuestionList = QuestionRepo pytania do danego testu
            var tmp = new ObservableCollection<Question>()
            {
                new Question {QuestionNo = 1, Content= "pytanie 1"},
                new Question {QuestionNo = 2, Content= "pytanie 2"},
                new Question {QuestionNo = 3, Content= "pytanie 3",Photo = new byte[] {1,2}},
                new Question {QuestionNo = 4, Content= "pytanie 4"}
            };
            QuestionList = tmp;//tymczasowo
        }

        private void answerListUpdate()
        {
            // AnswereList = odpowiedzi do danego pytania
            var tmp = new ObservableCollection<Answer>()
            {
                new Answer {Content="odpowiedz 1 bardzo dluga bardzo dluga bardzo dluga bardzo dluga bardzo dluga", Correct = true },
                new Answer {Content="odpowiedz 2", Correct = false },
                new Answer {Content="odpowiedz 3", Correct = true },
                new Answer {Content="odpowiedz 4", Correct = true },
                new Answer {Content="odpowiedz 5", Correct = false },
                new Answer {Content="odpowiedz 6", Correct = false }
            };
            AnswereList = tmp;//tymczasowo
        }

        private void PictureUpdate()
        {
            if(SelectedQuestion.Photo != null)
            {
                HasQuestionPicture = true;
                QuestionImage = SelectedQuestion.Photo;
            }
            else
            {
                HasQuestionPicture = false;
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
        //Commands end
    }
}
