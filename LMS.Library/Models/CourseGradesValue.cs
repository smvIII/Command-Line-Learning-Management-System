using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Library.Models
{
    public class CourseGradesValue
    {

        private int _creditHours;
        private int _inputGrade;
        private Assignment _assignment;

        public int CreditHours
        {
            get { return _creditHours; }
            set { _creditHours = value; }
        }
        public int InputGrade
        { 
            get { return _inputGrade; } 
            set { _inputGrade = value; } 
        }

        public Assignment Assignment
        {
            get { return _assignment; }
            set { _assignment = value; }
        }


    }
}
