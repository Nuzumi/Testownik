using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Testownik.Model;
using Testownik.Repository;

namespace Testownik.ViewModels
{
    class TestVM : BindableBase
    {
        private int repetitionAftherBadAnswer;
        private int questionAmountAtOnce;
        private List<Tuple<Question, int>> questionList;
        private List<Tuple<Question, int>> questionListToUse;
        private TestRepository testRepository;
        private bool wasNextQuestion = true;

        //properties start
        public ICommand ToMainWindowCommand { get; set; }
        public ICommand ToEditQuestionCommand { get; set; }
        public ICommand NextQuestionCommand { get; set; }
        public ICommand CheckAnswersCommand { get; set; }

        public int CountOfActualQuestionRightAnswers { get; set; }

        private Question actualQuestion;
        public Question ActualQuestion
        {
            get { return actualQuestion; }
            set { SetProperty(ref actualQuestion, value); }
        }

        private int actualQuestinRepetition;
        public int ActualQuestionRepetition
        {
            get { return actualQuestinRepetition; }
            set { SetProperty(ref actualQuestinRepetition, value); }
        }

        private List<Answer> actualQuestionAnswersList;
        public List<Answer> ActualQuestionAnswersList
        {
            get { return actualQuestionAnswersList; }
            set { SetProperty(ref actualQuestionAnswersList, value); }
        }

        private bool wasActualQuestionChcecked = false;
        public bool WasActualQuestionChcecked
        {
            get { return wasActualQuestionChcecked; }
            set { SetProperty(ref wasActualQuestionChcecked, value); }
        }

        private Answer answer;
        public Answer Answer
        {
            get { return answer; }
            set { SetProperty(ref answer, value); }
        }
        //properties end

        public TestVM(Model.Test test, int repetitionAtStart, int repetitionAftherBadAnswer, int questionAmountAtOnce)
        {
            ToMainWindowCommand = new DelegateCommand<Window>(ToMainWindow);
            ToEditQuestionCommand = new DelegateCommand<Window>(ToEditQuestion);
            NextQuestionCommand = new DelegateCommand(NextQuestion,CanNextQuestion);
            CheckAnswersCommand = new DelegateCommand<object>(CheckAnswers,CanCheckAnswers);

            testRepository = new TestRepository(new TestownikContext());
            this.repetitionAftherBadAnswer = repetitionAftherBadAnswer;
            this.questionAmountAtOnce = questionAmountAtOnce;
            questionList = prepareQuestions(test, repetitionAtStart);
            questionListToUse = takeXRandomQuestions(questionAmountAtOnce);
            takeRandomActualQuestion();
        }

        private List<Tuple<Question, int>> prepareQuestions(Model.Test test, int repetition)
        {
            
            List<Tuple<Question, int>> value = new List<Tuple<Question, int>>();
            foreach (Question q in testRepository.GetQuestionsForTest(test.Ref))
            {
                value.Add(new Tuple<Question, int>(q, repetition));
            }
            return value;
        }

        private List<Tuple<Question, int>> takeXRandomQuestions(int X)
        {
            Random rand = new Random();
            List<Tuple<Question, int>> value = new List<Tuple<Question, int>>();
            for (int i =0; i < X || questionList.Count != 0; i++)
            {
                var question = questionList[rand.Next(questionList.Count - 1)];
                questionList.Remove(question);
                value.Add(question);
            }
            return value;
        }

        private Tuple<Question, int> takeRandomQuestion()
        {
            Random rand = new Random();
            var question = questionList[rand.Next(questionList.Count - 1)];
            questionList.Remove(question);
            return question;
        }

        private void takeRandomActualQuestion()
        {
            Random rand = new Random();
            var question = questionListToUse[rand.Next(questionListToUse.Count - 1)];
            questionList.Remove(question);
            ActualQuestion = question.Item1;
            ActualQuestionRepetition = question.Item2;
            ActualQuestionAnswersList = testRepository.GetAnswersForQuestions(ActualQuestion.Ref);
            //CountOfActualQuestionRightAnswers = uzupelnic
        }
        //command start
        private void ToMainWindow(Window window)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mainWindow.Show();
            window.Close();
        }

        private void ToEditQuestion(Window window)
        {
            AddEditQuestion addEdit = new AddEditQuestion();
            AddEditQuestionVM dataContext = new AddEditQuestionVM(WindowsTypes.Test);
            addEdit.DataContext = dataContext;
            addEdit.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addEdit.Show();
            window.Close();
        }

        private void NextQuestion()
        {
            WasActualQuestionChcecked = false;
            wasNextQuestion = true;
            (NextQuestionCommand as DelegateCommand).RaiseCanExecuteChanged();
            (CheckAnswersCommand as DelegateCommand<object>).RaiseCanExecuteChanged();
        }

        private bool CanNextQuestion()
        {
            return WasActualQuestionChcecked;
        }

        private void CheckAnswers(object answersList)
        {
            Answer = null;
            WasActualQuestionChcecked = true;
            wasNextQuestion = false;
            (NextQuestionCommand as DelegateCommand).RaiseCanExecuteChanged();
            (CheckAnswersCommand as DelegateCommand<object>).RaiseCanExecuteChanged();

            System.Collections.IList items = (System.Collections.IList)answersList;
            var list = items.Cast<Answer>();

        }

        private bool CanCheckAnswers(object dummyObject)
        {
            return wasNextQuestion;
        }
        //command end
    }
}
