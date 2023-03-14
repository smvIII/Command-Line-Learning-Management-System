using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem.Models
{
    public class Assignment
    {
        private string _name;
        private string _description;
        private string _totalAvailablePoints;
        private double _weight;
        private string _dueDate;
        private string _courseIndex; //index of course that owns this assignment

        public Assignment()
        {

        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string TotalAvailablePoints
        {
            get { return _totalAvailablePoints; }
            set { _totalAvailablePoints = value; }
        }

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public string DueDate
        {
            get { return _dueDate; }
            set { _dueDate = value; }
        }

        public string CourseIndex
        {
            get { return _courseIndex; }
            set { _courseIndex = value; }
        }

        public override string ToString()
        {
            return "Assignment Name : " + _name + " | Assignmnet Description: " + _description + 
                " | Total Points: " + _totalAvailablePoints;
        }



    }
}
