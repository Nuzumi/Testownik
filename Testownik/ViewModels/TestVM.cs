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

        private string answerText;
        public string AnswerText
        {
            get { return answerText; }
            set { SetProperty(ref answerText, value); }
        }

        private int goodAnswersCount;
        public int GoodAnswersCount
        {
            get { return goodAnswersCount; }
            set { SetProperty(ref goodAnswersCount, value); }
        }

        private int badAnswersCount;
        public int BadAnswersCount
        {
            get { return badAnswersCount; }
            set { SetProperty(ref badAnswersCount, value); }
        }

        private int questionCount;
        public int QuestionCount
        {
            get { return questionCount; }
            set { SetProperty(ref questionCount, value); }
        }

        private int lernedQuestionCount;
        public int LernedQuestionCount
        {
            get { return lernedQuestionCount; }
            set { SetProperty(ref lernedQuestionCount, value); }
        }
        //properties end

        public TestVM(Model.Test test, int repetitionAtStart, int repetitionAftherBadAnswer, int questionAmountAtOnce)
        {
            ToMainWindowCommand = new DelegateCommand<Window>(ToMainWindow);
            ToEditQuestionCommand = new DelegateCommand<Window>(ToEditQuestion);
            NextQuestionCommand = new DelegateCommand(NextQuestion,CanNextQuestion);
            CheckAnswersCommand = new DelegateCommand<object>(CheckAnswers,CanCheckAnswers);

            AnswerText = "";

            testRepository = new TestRepository(new TestownikContext());
            this.repetitionAftherBadAnswer = repetitionAftherBadAnswer;
            this.questionAmountAtOnce = questionAmountAtOnce;
            questionList = prepareQuestions(test, repetitionAtStart);
            QuestionCount = questionList.Count;
            LernedQuestionCount = 0;
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
            for (int i =0; i < X; i++)
            {
                var question = questionList[rand.Next(questionList.Count)];
                questionList.Remove(question);
                value.Add(question);
            }
            return value;
        }

        private void takeRandomQuestion()
        {
            if(questionList.Count !=0)
            {
                Random rand = new Random();
                var question = questionList[rand.Next(questionList.Count - 1)];
                questionList.Remove(question);
                questionListToUse.Add(question);
            }
        }

        private void takeRandomActualQuestion()
        {
            Random rand = new Random();
            var question = questionListToUse[rand.Next(questionListToUse.Count)];
            questionListToUse.Remove(question);
            ActualQuestion = question.Item1;
            ActualQuestionRepetition = question.Item2;
            takeActuaQuestionAnswerList(testRepository.GetAnswersForQuestions(ActualQuestion.Ref));
        }

        private void takeActuaQuestionAnswerList(List<Answer> answerList)
        {
            Random rand = new Random();
            var result = new List<Answer>();
            while (answerList.Count != 0)
            {
                var answ = answerList[rand.Next(answerList.Count)];
                answerList.Remove(answ);
                result.Add(answ);
            }
            ActualQuestionAnswersList = result;
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
            AddEditQuestionVM dataContext = new AddEditQuestionVM(WindowsTypes.Test, ActualQuestion.RefTest, ActualQuestion.Ref);
            addEdit.DataContext = dataContext;
            addEdit.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addEdit.Show();
            window.Close();
        }

        private void NextQuestion()
        {
            AnswerText = "";
            WasActualQuestionChcecked = false;
            wasNextQuestion = true;
            (NextQuestionCommand as DelegateCommand).RaiseCanExecuteChanged();
            (CheckAnswersCommand as DelegateCommand<object>).RaiseCanExecuteChanged();

            var tmpQuestion = new Tuple<Question, int>(ActualQuestion, ActualQuestionRepetition);

            if(questionListToUse.Count != 0)
            {
                takeRandomActualQuestion();
                if (tmpQuestion.Item2 != 0)
                {
                    questionListToUse.Add(tmpQuestion);
                }
                else
                {
                    takeRandomQuestion();
                }
            }
            else
            {
                if (tmpQuestion.Item2 != 0)
                {
                    questionListToUse.Add(tmpQuestion);
                }
                else
                {
                    //koniec testu nauczony
                }
                takeRandomActualQuestion();
            }

            
        }

        private bool CanNextQuestion()
        {
            return WasActualQuestionChcecked;
        }

        private void CheckAnswers(object answersList)
        {
            WasActualQuestionChcecked = true;
            wasNextQuestion = false;
            (NextQuestionCommand as DelegateCommand).RaiseCanExecuteChanged();
            (CheckAnswersCommand as DelegateCommand<object>).RaiseCanExecuteChanged();

            System.Collections.IList items = (System.Collections.IList)answersList;
            var list = items.Cast<Answer>();
  
            List<Answer> positiveSelected = new List<Answer>();
            foreach(Answer a in list)
            {
                if (a.Correct)
                {
                    positiveSelected.Add(a);
                }
            }

            List<Answer> positiveAnswers = new List<Answer>();
            foreach(Answer a in ActualQuestionAnswersList)
            {
                if (a.Correct)
                {
                    positiveAnswers.Add(a);
                }
            }

            if(positiveSelected.Count() == list.Count())
            {
                if(positiveSelected.Count() == positiveAnswers.Count())
                {
                    AnswerText = "OK";
                    ActualQuestionRepetition--;
                    if(ActualQuestionRepetition == 0)
                    {
                        LernedQuestionCount++;
                    }
                    GoodAnswersCount++;
                }
                else
                {
                    AnswerText = "BAD";
                    ActualQuestionRepetition += repetitionAftherBadAnswer;
                    BadAnswersCount++;
                }
                
            }
            else
            {
                AnswerText = "BAD";
                ActualQuestionRepetition += repetitionAftherBadAnswer;
                BadAnswersCount++;
            }

            Answer = null;
        }

        private bool CanCheckAnswers(object dummyObject)
        {
            return wasNextQuestion;
        }
        //command end
    }
}