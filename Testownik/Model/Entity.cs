using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testownik.Model
{
    public abstract class Entity
    {
        [Key]
        public int Ref { get; set; }
    }
}
