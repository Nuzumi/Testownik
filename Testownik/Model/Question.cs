using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Key]
        public int Ref { get; set; }

        public int RefTest { get; set; }
        public virtual Test Test { get; set; }

        public int QuestionNo { get; set; }
        public string Content { get; set; }
        public byte[] Photo { get; set; }

        public virtual ICollection<Answer> QuestionAnswers { get; set; }
    }
}
