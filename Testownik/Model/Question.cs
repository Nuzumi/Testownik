using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testownik.Model
{
    public class Question : Entity
    {
        public Question()
        {
            QuestionAnswers = new List<Answer>();
        }

        public int RefTest { get; set; }
        public virtual Test Test { get; set; }

        public int QuestionNo { get; set; }
        public string Content { get; set; }
        public byte[] Photo { get; set; }

        public virtual ICollection<Answer> QuestionAnswers { get; set; }

        /// <summary>
        /// Zwracana jest tresc pytania
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            return Content;
        }

    }
}
