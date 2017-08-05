using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testownik.Model
{
    public class Database
    {
        public Database()
        {
            DatabaseQuestions = new List<Question>();
        }

        public long Ref { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }

        public virtual ICollection<Question> DatabaseQuestions { get; set; }
    }
}
