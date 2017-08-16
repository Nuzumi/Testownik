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

        //properties start
        public ICommand ToMainWindowCommand { get; set; }
        public ICommand ToEditQuestionCommand { get; set; }
        public ICommand NextQuestionCommand { get; set; }
        public ICommand ChceckAnswersCommand { get; set; }
        //properties end

        public TestVM(Model.Test test, int repetitionAtStart, int repetitionAftherBadAnswer, int questionAmountAtOnce)
        {
            ToMainWindowCommand = new DelegateCommand<Window>(ToMainWindow);
            ToEditQuestionCommand = new DelegateCommand<Window>(ToEditQuestion);

            testRepository = new TestRepository(new TestownikContext());
            this.repetitionAftherBadAnswer = repetitionAftherBadAnswer;
            this.questionAmountAtOnce = questionAmountAtOnce;
            questionList = prepareQuestions(test, repetitionAtStart);
        }

        private List<Tuple<Question, int>> prepareQuestions(Model.Test test, int repetition)
        {
            /*
            using(var ctx = new TestownikContext())
            {
                //var tmp = ctx.Tests.Where(t => t.Ref == test.Ref).Include(t => t.TestQuestions).FirstOrDefault().TestQuestions;
                var tmp = ctx.Questions.ToList();
                List<Tuple<Question, int>> value = new List<Tuple<Question, int>>();
                foreach (Question q in tmp)
                {
                    value.Add(new Tuple<Question, int>(q, repetition));
                }
                return value;
            }*/
            /*
            List<Tuple<Question, int>> value = new List<Tuple<Question, int>>();
            foreach (Question q in testRepository.GetQuestionsForTest(test.Ref))
            {
                value.Add(new Tuple<Question, int>(q, repetition));
            }
            return value;
            */
            return null;
        }

        private List<Tuple<Question, int>> takeXRandomQuestions(int X)
        {
            Random rand = new Random();
            List<Tuple<Question, int>> value = new List<Tuple<Question, int>>();
            for (int i =0; i < X; i++)
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
        //command end
    }
}
