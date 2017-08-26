using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testownik.Model;
using System.Data.Entity;
using Testownik.Converters;

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

        public List<ArchQuestion> GetAllArchQuestions()
        {
            return (from a in context.ArchQuestions select a).ToList();
        }

        public ArchQuestion GetArchQuestionById(int id)
        {
            return GetAllArchQuestions().FirstOrDefault(a => a.Ref.Equals(id));
        }

        public void CreateArchQuestion(ArchQuestion question)
        {
            context.Set<ArchQuestion>().Add(question);
        }

        public void DeleteArchQuestions(ArchQuestion question)
        {
            context.Set<ArchQuestion>().Remove(question);
        }

        public void EditArchQuestion(ArchQuestion question)
        {
            context.Entry<ArchQuestion>(question).CurrentValues.SetValues(question);
        }

        public List<ArchStat> GetAllArchStats()
        {
            return (from a in context.ArchStats select a).ToList();
        }

        public ArchStat GetArchStatById(int id)
        {
            return GetAllArchStats().FirstOrDefault(a => a.Ref.Equals(id));
        }

        public void CreateArchStat(ArchStat question)
        {
            context.Set<ArchStat>().Add(question);
        }

        public void DeleteArchQuestions(ArchStat question)
        {
            context.Set<ArchStat>().Remove(question);
        }

        public void EditArchStat(ArchStat question)
        {
            context.Entry<ArchStat>(question).CurrentValues.SetValues(question);
        }

        public List<Question> GetQuestionsForTest(int testId)
        {
            return GetAllQuestions().Where(q => q.RefTest.Equals(testId)).ToList();
        }

        public List<Answer> GetAnswersForQuestions(int questionId)
        {
            return GetAllAnswers().Where(q => q.RefQuestion.Equals(questionId)).ToList();
        }

        public List<Tuple<Question, int>> GetArchQuestionsForTest(int testId)
        {
            return ArchiveConverter.GetArchiveQuestions(GetAllArchQuestions().Where(q => q.RefTest.Equals(testId)).ToList());
        }

        public void SaveArchQuestionsForTest(List<Tuple<Question, int>> archiveList)
        {
            List<ArchQuestion> archQuestion = ArchiveConverter.AddArchiveQuestions(archiveList);
            foreach (ArchQuestion a in archQuestion)
            {
                if (!GetAllArchQuestions().Exists(q => q.RefQuestion == a.RefQuestion))
                    CreateArchQuestion(a);
                else
                {
                    ArchQuestion arch = GetAllArchQuestions().FirstOrDefault(q => q.RefQuestion == a.RefQuestion);
                    arch.Repeat = a.Repeat;
                    EditArchQuestion(arch);
                }
                SaveChanges();
            }
        }
        
        public ArchStat GetArchStatForTest(int testId)
        {
            return GetAllArchStats().FirstOrDefault(q => q.RefTest.Equals(testId));
        }

        public void SaveArchStatForTest(ArchStat arch)
        {
            if (!GetAllArchStats().Exists(a => a.RefTest == arch.RefTest))
                CreateArchStat(arch);
            else
            {
                ArchStat a = GetAllArchStats().FirstOrDefault(q => q.RefTest == arch.RefTest);
                a.CorrectAns = arch.CorrectAns;
                a.BadAns = arch.BadAns;
                a.KnownQuestions = arch.KnownQuestions;
                EditArchStat(a);
            }
            SaveChanges();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
