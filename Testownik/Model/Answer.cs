using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testownik.Model
{
    public class Answer
    {
        public long Ref { get; set; }
        public long RefQuestion { get; set; }
        public virtual Question Question { get; set; }
        public string Content { get; set; }
        public bool Correct { get; set; }
    }
}
