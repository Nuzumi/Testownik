using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testownik.Model;
using System.Data.Entity;

namespace Testownik.Repository
{
    public class TestRepository
    {
        private readonly TestownikContext context;

        public TestRepository(TestownikContext context)
        {
            this.context = context;
        }

        public List<Model.Test> GetAllTests()
        {
            return (from a in context.Tests select a).ToList();
        }

        public Model.Test GetTestById(int id)
        {
            return GetAllTests().FirstOrDefault(a => a.Ref.Equals(id));
        }

        public void CreateTest(Model.Test test)
        {
            context.Set<Model.Test>().Add(test);
            context.SaveChanges();
        }

        public void DeleteTest(Model.Test test)
        {
            context.Set<Model.Test>().Remove(test);
            context.SaveChanges();
        }

        public void EditTest(Model.Test test)
        {
            context.Entry<Model.Test>(test).CurrentValues.SetValues(test);
            context.SaveChanges();
        }



        public List<Question> GetAllQuestions()
        {
            return (from a in context.Questions select a).ToList();
        }

        public Question GetQuestionById(int id)
        {
            return GetAllQuestions().FirstOrDefault(a => a.Ref.Equals(id));
        }

        public void CreateQuestion(Question question)
        { 
            List<Model.Question> questions = GetQuestionsForTest(question.RefTest);
            question.QuestionNo = questions.Count==0 ? 1 : questions.Max(q => q.QuestionNo) + 1;// jak questions jest nullem, a wlasciwie int?, to 1.
            context.Set<Question>().Add(question);
            GetTestById(question.RefTest).QuestionsCount++;
        }

        public void DeleteQuestion(Question question)
        {
            GetTestById(question.RefTest).QuestionsCount--;
            context.Set<Question>().Remove(question);
        }

        public void EditQuestion(Question question)
        {
            context.Entry<Question>(question).CurrentValues.SetValues(question);
        }


        public List<Answer> GetAllAnswers()
        {
            return (from a in context.Answers select a).ToList();
        }

        public Answer GetAnswerById(int id)
        {
            return GetAllAnswers().FirstOrDefault(a => a.Ref.Equals(id));
        }

        public void CreateAnswer(Answer answer)
        {
            context.Set<Answer>().Add(answer);
        }

        public void DeleteAnswer(Answer answer)
        {
            context.Set<Answer>().Remove(answer);
        }

        public void EditAnswer(Answer answer)
        {
            context.Entry<Answer>(answer).CurrentValues.SetValues(answer);
        }
        
        public List<Question> GetQuestionsForTest(int testId)
        {
            return GetAllQuestions().Where(q => q.RefTest.Equals(testId)).ToList();
        }

        public List<Answer> GetAnswersForQuestions(int questionId)
        {
            return GetAllAnswers().Where(q => q.RefQuestion.Equals(questionId)).ToList();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
