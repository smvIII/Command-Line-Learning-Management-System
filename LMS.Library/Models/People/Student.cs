using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Library.Models.People
{
    public class Student : Person
    {
        //private string _classification;
        private Dictionary<string, List<CourseGradesValue>> _courseGradesMap;

        /*
        public Dictionary<string, List<CourseGradesValue>> CourseGradesMap
        {
            get { return _courseGradesMap; }

        }*/

        public Student()
        {
            _courseGradesMap = new Dictionary<string, List<CourseGradesValue>>();
            Id = _nextId++;
        }

        private List<int> _grades;

        /*
        static public Student AddStudent()
        {
            Student newStudent = new Student();

            Console.WriteLine("Enter name for student.");
            string newStudentName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter Classification of student.");
            string newClassification = Console.ReadLine() ?? string.Empty;
            //Console.WriteLine("Enter student's grades");
            //string newGrades = Console.ReadLine() ?? string.Empty;

            newStudent.Name = newStudentName;
            newStudent.Classification = newClassification;
            //newStudent.Grades = newGrades;
            Console.Clear();
            return newStudent;

        }


        static public void UpdateStudent(List<Person> students)
        {
            Console.WriteLine("Select a student to update");
            int studentIndex = ListSelect(students, 1);
            Console.WriteLine("What would you like to update about the student?");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Classification");
            //Console.Clear();
            //Console.WriteLine("3. Grades") not in assignment 1 requirements

            string choice = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(choice, out int choiceInt))
            {
                if (choiceInt == 1)
                {
                    Console.WriteLine("Please enter the updated name: ");
                    string updatedName = Console.ReadLine() ?? string.Empty;
                    students[studentIndex].Name = updatedName;
                }
                if (choiceInt == 2)
                {
                    Console.WriteLine("Please enter updated classification: ");
                    string updatedClass = Console.ReadLine() ?? string.Empty;
                    students[studentIndex].Classification = updatedClass;
                }
                Console.Clear();
            }


        }
        */

        public static bool IsStudent(Person person)
        {
            if (person.Classification.ToUpper() != "STUDENT")
            {
                return false;
            }
            return true;
        }

        public static void ListStudentCourses(List<Person> students, List<Course> courses)
        {
            Console.WriteLine("Please select a student to view their courses.");
            int studentIndex = ListSelect(students, 1);
            // Console.WriteLine("Course count is " + courses.Count);
            int courseCounter = 1;
            for (int i = 0; i < courses.Count; i++)
            {
                for (int j = 0; j < courses[i].Roster.Count; j++)
                {
                    if (students[studentIndex].Name == courses[i].Roster[j].Name)
                    {
                        Console.WriteLine("Course " + courseCounter + ": " + courses[i].Name);
                        courseCounter++;
                    }
                }
            }

        }

        public static void InputGrade(List<Person> students, List<Course> courses)
        {
            bool isStudent = true;
            int studentIndex;
            do
            {
                Console.WriteLine("Please select a student you would like to input a grade for.");
                studentIndex = Services.ListSelect(students, 1);
                if (!IsStudent(students[studentIndex]))
                {
                    isStudent = false;
                    Console.WriteLine("Only students can receive grades. Please select another person.");
                }
                else
                    isStudent = true;
            }
            while (!isStudent);

            Console.WriteLine("Please select a course that they're taking to input a grade for.");
            int courseIndex = Services.ListSelect(courses, 1);
            Console.WriteLine("Please select an assignment to input a grade for.");
            int assignmentIndex = Services.ListSelect(courses[courseIndex].Assignments, 1);
            Console.WriteLine("Please enter grade.");
            string grade = Console.ReadLine() ?? string.Empty;

            CourseGradesValue foo = new CourseGradesValue();
            foo.CreditHours = courses[courseIndex].CreditHours;
            foo.InputGrade = int.Parse(grade);
            foo.Assignment = courses[courseIndex].Assignments[assignmentIndex];

            List<CourseGradesValue> bar;
            if (!students[studentIndex].CourseGradesMap.TryGetValue(
                courses[courseIndex].Name, out bar))
            {
                bar = new List<CourseGradesValue>();
                students[studentIndex].CourseGradesMap[courses[courseIndex].Name] = bar;
            }

            bar.Add(foo);


            foreach (var item in students[studentIndex].CourseGradesMap)
            {
                Console.WriteLine("Current Course: " + item.Key);
                for (int i = 0; i < item.Value.Count; i++)
                {
                    Console.Write("Credit Hours: " + item.Value[i].CreditHours);
                    Console.Write(" " + item.Value[i].Assignment.Name);
                    Console.Write(" " + item.Value[i].InputGrade);
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

        }

        public static void CalculateGPA(List<Person> students, List<Course> courses)
        {
            Console.WriteLine("Please select a student whose GPA you would like to calculate.");
            int studentIndex = Services.ListSelect(students, 1);

            List<int> QualityPoints = new List<int>();
            int totalCreditHours = 0;
            int totalQualityPoints = 0;
            double currentCourseGrade;
            double gpa;
            int currentCoursePoints;
            int i = 0;

            foreach (var item in students[studentIndex].CourseGradesMap)
            {
                Console.WriteLine("Current Course: " + item.Key);
                currentCourseGrade = Course.CalculateCourseGrade(students, courses, item.Key, studentIndex, 1);
                if (currentCourseGrade <= 1.0 && currentCourseGrade >= .9)
                {
                    currentCoursePoints = 4;
                }
                else if (currentCourseGrade <= .89 && currentCourseGrade >= .8)
                {
                    currentCoursePoints = 3;
                }
                else if (currentCourseGrade <= .79 && currentCourseGrade >= .7)
                {
                    currentCoursePoints = 2;
                }
                else if (currentCourseGrade <= .69 && currentCourseGrade >= .6)
                {
                    currentCoursePoints = 1;
                }
                else
                {
                    currentCoursePoints = 0;
                }


                totalQualityPoints += currentCoursePoints * item.Value[0].CreditHours;
                totalCreditHours += item.Value[0].CreditHours;
                Console.WriteLine(totalQualityPoints + totalCreditHours);


            }
            Console.WriteLine("Total Credit Hours: " + totalCreditHours);
            Console.WriteLine("Total Quality Points: " + totalQualityPoints);
            gpa = (double)totalQualityPoints / (double)totalCreditHours;
            Console.WriteLine("Student's GPA: " + gpa);
        }

        public override string ToString()
        {
            return this.Name + " - " + this.Classification;
        }

    }
}
