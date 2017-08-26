using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testownik.Model;
using Testownik.Repository;

namespace Testownik.Converters
{
    public static class ArchiveConverter
    {
        public static TestRepository repo = new TestRepository(new TestownikContext());
        /// <summary>
        /// Zwraca gotowa do testu liste pytan wraz z iloscia powtorzen
        /// </summary>
        public static List<Tuple<Question, int>> GetArchiveQuestions(List<ArchQuestion> archQuestions)
        {
            List<Tuple<Question, int>> archiveList = new List<Tuple<Question, int>>();
            foreach (ArchQuestion a in archQuestions)
            {
                archiveList.Add(new Tuple<Question, int>(repo.GetQuestionById(a.RefQuestion), a.Repeat));
            }
            return archiveList;
        }
        
        /// <summary>
        /// Po przekazaniu listy tupli tworzy nowa historie
        /// </summary>
        /// <param name="archQuestions"></param>
        /// <returns></returns>
        public static List<ArchQuestion> AddArchiveQuestions(List<Tuple<Question, int>> archQuestions)
        {
            List<ArchQuestion> archiveList = new List<ArchQuestion>();
            foreach (Tuple<Question, int> a in archQuestions)
            {
                archiveList.Add(new ArchQuestion { RefQuestion = a.Item1.Ref, RefTest = a.Item1.RefTest, Repeat = a.Item2 });
            }
            return archiveList;
        }
        
    }
}
