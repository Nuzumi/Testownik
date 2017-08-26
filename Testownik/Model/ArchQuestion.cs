using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testownik.Model
{
    public class ArchQuestion : Entity
    {
        [ForeignKey("RefTest")]
        public virtual Test Test { get; set; }
        public int RefTest { get; set; }

        [ForeignKey("RefQuestion")]
        public virtual Question Question { get; set; }
        public int RefQuestion { get; set; }

        public int Repeat { get; set; }
    }
}
