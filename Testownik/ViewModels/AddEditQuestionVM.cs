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
    class AddEditQuestionVM : BindableBase
    {

        public TestRepository repo;
        public int TestId;
        public int? QuestionId;

        public ICommand GoBackCommand { get; set; }
        public ICommand AddNewQuestionCommand { get; set; }
        public ICommand SaveChangesCommand { get; set; }

        private Question selectedQuestion;
        public Question SelectedQuestion
        {
            get { return selectedQuestion; }
            set
            {
                SetProperty(ref selectedQuestion, value);
                answerListUpdate();
            }
        }

        private ObservableCollection<Answer> answerList;
        public ObservableCollection<Answer> AnswerList
        {
            get { return answerList; }
            set { SetProperty(ref answerList, value); }
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

        private WindowsTypes previousWindowType;

        /// <summary>
        /// Jeżeli dodajesz całkiem nowe pytanie
        /// </summary>
        /// <param name="windowType"></param>
        /// <param name="testId"></param>
        public AddEditQuestionVM(WindowsTypes windowType, int testId)
        {
            previousWindowType = windowType;
            TestId = testId;
            prepare();
        }

        /// <summary>
        /// Jeżeli chcesz edytowac bieżące pytanie
        /// </summary>
        /// <param name="windowType"></param>
        /// <param name="testId"></param>
        /// <param name="questionId"></param>
        public AddEditQuestionVM(WindowsTypes windowType, int testId, int questionId)
        {
            previousWindowType = windowType;
            TestId = testId;
            QuestionId = questionId;
            prepare();
            SelectedQuestion = repo.GetQuestionById(QuestionId.Value);
        }

        public void prepare()
        {
            GoBackCommand = new DelegateCommand<Window>(GoBack);
            AddNewQuestionCommand = new DelegateCommand(AddNewQuestion);
            SaveChangesCommand = new DelegateCommand(SaveChanges);
            repo = new TestRepository(new TestownikContext());
        }


        /// <summary>
        /// Metoda tworzy pytanie, ale nie zapisuje do bazy, wymaga uzycia metody SaveChanges()
        /// Kiedyś pójdzie do konwertora, teraz na chama tworzy pytanie
        /// </summary>
        private void AddNewQuestion()
        {
            /*
             * Opcja na dodawanie - zrobienie pustego elementu w liście
             * Pojawi sie pusty element, od razu zaznaczony i bedzie mozna go uzupelnic
             * Kontekst menu na usuniecie
             * Nie ywkorzystywac metod na dodawanie z repo, zrobic liste templatkowa,
             * gdzie beda dodawane odpowiedzi, a na koniec po kliknieciu "Zapiszcz" beda sie dodawac 
             * Opcja 2, nie pieprzyc sie tylko od razu dodawac i leciec na edycjach --  not nulle bazowo na tresc pytania
             * winc nie mozna od razu dac do bazy, albo trzeba rozwiazać programistycznie
             * Jak odznaczy sie nowa, pusta odpowiedz to krzyczy, ze nie moze byc puste.
             * 
             * Chyba i tak to ograniczy sie do sprawdzania czy selectedQuestion istnieje w bazie 
             * 
             * 
             * Osobiscie wole wersje tmp lista i potem jak jest w bazie -> Edit, jak nie to Add.
             */
             if(!QuestionId.HasValue)
                repo.CreateQuestion(new Question { RefTest = TestId, Content = selectedQuestion.Content });
             else {
                Question question = repo.GetQuestionById(QuestionId.Value);
                question.Content = SelectedQuestion.Content;
                repo.EditQuestion(question);
             }
                
        }

        private void DeleteAnswer()
        {
            repo.DeleteAnswer(SelectedAnswer);
            AnswerList = new ObservableCollection<Model.Answer>(repo.GetAnswersForQuestions(selectedQuestion.Ref));
        }

        private void SaveChanges()
        {
            AddNewQuestion();
            repo.SaveChanges();
        }

        private void GoBack(Window window)
        {
            Window backWindow = null;
            switch (previousWindowType)
            {
                case WindowsTypes.Browser:
                    backWindow = new BaseQuestionBrowser();
                    BaseQuestionBrowserVM dataContextB = new BaseQuestionBrowserVM();
                    backWindow.DataContext = dataContextB;
                    break;

                case WindowsTypes.Test:/*
                    backWindow = new Test();
                    TestVM dataContextT = new TestVM();
                    backWindow.DataContext = dataContextT;*/
                    break;
            }

            backWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            backWindow.Show();
            window.Close();
        }
        
        private void answerListUpdate()
        {
            AnswerList = new ObservableCollection<Answer>(repo.GetAnswersForQuestions(selectedQuestion.Ref));
        }

    }
}
