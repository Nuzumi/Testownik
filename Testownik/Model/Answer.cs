using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testownik.Model
{
    public class Answer
    {
        [Key]
        public int Ref { get; set; }
        public int RefQuestion { get; set; }
        public virtual Question Question { get; set; }
        public string Content { get; set; }
        public bool Correct { get; set; }
    }
}
