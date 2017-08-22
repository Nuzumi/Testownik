using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Testownik.ViewModels
{
    public class FinishedTestVM
    {
        private Model.Test test;
        private int questionRepetitionAtStart;
        private int questionRepetitionAftherBAdAnswer;
        private int questionRepetitionAtOnce;

        //properties start
        public ICommand ToMainWindowCommand { get; set; }
        public ICommand OnceAgainCommand { get; set; }

        public int GoodAnswersCount { get; set; }
        public int BadAnswersCount { get; set; }
        //properties end

        public FinishedTestVM(Model.Test test, int questionRepetitionAtStart, int questionRepetitionAftherBAdAnswer, int questionRepetitionAtOnce , int goodAnswersCount, int badAnswersCount)
        {
            this.test = test;
            this.questionRepetitionAtStart = questionRepetitionAtStart;
            this.questionRepetitionAftherBAdAnswer = questionRepetitionAftherBAdAnswer;
            this.questionRepetitionAtOnce = questionRepetitionAtOnce;
            GoodAnswersCount = goodAnswersCount;
            BadAnswersCount = badAnswersCount;
			
			//modyfikacja wow
        }

        //command start
        private void ToMainWindow(Window window)
        {
            MainWindow mainWindow = new MainWindow();
            window.Show();
            window.Close();
        }

        private void OnceAgain(Window window)
        {
            Test testWindow = new Test();
            TestVM dataContext = new TestVM(test,questionRepetitionAtStart,questionRepetitionAftherBAdAnswer,questionRepetitionAtOnce);
            testWindow.DataContext = dataContext;
            testWindow.Show();
            window.Close();
        }
        //command end
    }
}
