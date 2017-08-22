using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testownik.Model
{
    public class Answer : Entity
    {
        public int RefQuestion { get; set; }
        [ForeignKey("RefQuestion")]
        public virtual Question Question { get; set; }
        public string Content { get; set; }
        public bool Correct { get; set; }

        /// <summary>
        /// Zwraca tresc odpowiedzi
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            return Content;
        }

    }
}
