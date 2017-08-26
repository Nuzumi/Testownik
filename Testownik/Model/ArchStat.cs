using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testownik.Model
{
    public class ArchStat : Entity
    {
        [ForeignKey("RefTest")]
        public virtual Test Test { get; set; }
        public int RefTest { get; set; }

        public int CorrectAns { get; set; }
        public int BadAns { get; set; }
        public int KnownQuestions { get; set; }
    }
}
