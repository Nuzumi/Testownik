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

        public List<Question> GetQuestionsForTest(int id)
        {
            var test = context.Tests.Where(p => p.Ref == id).Include(p => p.TestQuestions).FirstOrDefault();

            return test.TestQuestions.ToList();
        }
    }
}
