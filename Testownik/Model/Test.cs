﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testownik.Model
{
    public class Test : Entity
    {
        public Test()
        {
            TestQuestions = new List<Question>();
        }
        
        public string Name { get; set; }
        public string Teacher { get; set; }

        public virtual IList<Question> TestQuestions { get; set; }

        /// <summary>
        /// Zwracana jest nazwa bazy
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            return Name;
        }
        

    }
}
