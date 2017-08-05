using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testownik.Model
{
    public class Question
    {
        public Question()
        {
            QuestionAnswers = new List<Answer>();
        }

        public long Ref { get; set; }

        public long RefDatabase { get; set; }
        public virtual Database Database { get; set; }

        public long QuestionNo { get; set; }
        public string Content { get; set; }
        public byte[] Photo { get; set; }

        public virtual ICollection<Answer> QuestionAnswers { get; set; }
    }
}
