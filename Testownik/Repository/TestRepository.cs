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
            return context.Set<Model.Test>().Include(t => t.TestQuestions).ToList();
        }

        public Model.Test GetTestById(int id)
        {
            return context.Set<Model.Test>().Where(x => x.Ref == id).Include(t => t.TestQuestions).FirstOrDefault();
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
            return context.Set<Question>().Include(t => t.QuestionAnswers).ToList();
        }

        public Question GetQuestionById(int id)
        {
            return context.Set<Question>().Where(x => x.Ref == id).Include(t => t.QuestionAnswers).FirstOrDefault();
        }

        public void CreateQuestion(Question question)
        {
            context.Set<Question>().Add(question);
            context.SaveChanges();
        }

        public void DeleteQuestion(Question question)
        {
            context.Set<Question>().Remove(question);
            context.SaveChanges();
        }

        public void EditTest(Question question)
        {
            context.Entry<Question>(question).CurrentValues.SetValues(question);
            context.SaveChanges();
        }


        public List<Answer> GetAllAnswers()
        {
            return context.Set<Answer>().ToList();
        }

        public Answer GetAnswerById(int id)
        {
            return context.Set<Answer>().Where(x => x.Ref == id).FirstOrDefault();
        }

        public void CreateAnswer(Answer answer)
        {
            context.Set<Answer>().Add(answer);
            context.SaveChanges();
        }

        public void DeleteAnswer(Answer answer)
        {
            context.Set<Answer>().Remove(answer);
            context.SaveChanges();
        }

        public void EditAnswer(Answer answer)
        {
            context.Entry<Answer>(answer).CurrentValues.SetValues(answer);
            context.SaveChanges();
        }

        public List<Question> GetQuestionsForTest(int id)
        {
            var test = context.Tests.Where(p => p.Ref == id).Include(p => p.TestQuestions).FirstOrDefault();

            return test.TestQuestions.ToList();
        }
    }
}
