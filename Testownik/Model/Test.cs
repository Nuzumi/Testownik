using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testownik.Model
{
    public class Test
    {
        public Test()
        {
            TestQuestions = new List<Question>();
        }

        [Key]
        public int Ref { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }

        public virtual ICollection<Question> TestQuestions { get; set; }
    }
}
