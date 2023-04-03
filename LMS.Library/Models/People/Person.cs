using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
    
namespace LMS.Library.Models.People
{
    public class Person
    {
        public static int _nextId = 1;
        private string _name;
        private int _id;
        private string _classification;
        private Dictionary<string, List<CourseGradesValue>> _courseGradesMap;
        
        // dictionary that has holds course name, and then a special object that holds
        // all needed info to calculate a course's grade
            
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public string Classification
        {
            get { return _classification; }
            set { _classification = value; }
        }
        
        
        public Dictionary<string, List<CourseGradesValue>> CourseGradesMap
        {
            get { return _courseGradesMap; }

        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Person()
        {
            _courseGradesMap = new Dictionary<string, List<CourseGradesValue>>();
            Id = _nextId++;
        }


        static public Person AddPerson()
        {
            Person newPerson = new Person();

            Console.WriteLine("Enter name for person.");
            string newPersonName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter Classification of person.");
            string newClassification = Console.ReadLine() ?? string.Empty;
            //Console.WriteLine("Enter student's grades");
            //string newGrades = Console.ReadLine() ?? string.Empty;

            if (newClassification.ToUpper() == "STUDENT")
            {
                Student newStudent = new Student();
                newStudent.Name = newPersonName;
                newStudent.Classification = newClassification;
                return newStudent;
            }
            if (newClassification.ToUpper() == "TA")
            {
                TA newTA = new TA();
                newTA.Name = newPersonName;
                newTA.Classification = newClassification;
                return newTA;
            }
            if (newClassification.ToUpper() == "INSTRUCTOR")
            {
                Instructor newInstructor = new Instructor();
                newInstructor.Name = newPersonName;
                newInstructor.Classification = newClassification;
                return newInstructor;
            }
            //newStudent.Grades = newGrades;
            Console.Clear();
            return newPerson;

        }


        static public void UpdatePerson(List<Person> students)
        {
            Console.WriteLine("Select a student to update");
            int studentIndex = ListSelect(students, 1);
            Console.WriteLine("What would you like to update about the student?");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Classification");

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

        public static int ListSelect(List<Person> students, int option) // 0 = no choice // 1 = choice
        {
            //Console.WriteLine("Here is a list of all students");
            int i = 1;
            foreach (var student in students)
            {
                Console.WriteLine(i + ": " + student.Name + " - " + student.Classification);
                i++;
            }
            if (option == 1)
            {
                string choice = Console.ReadLine() ?? string.Empty;
                return int.Parse(choice) - 1; // return choice
            }

            //Console.Clear()
            return 0;
        }



        public static void PersonSearch(List<Person> students)
        {
            Console.WriteLine("Please enter a name you would like to search for:");
            string query = Console.ReadLine() ?? string.Empty;

            // modeled from youtube video "Ep 6. Adding search functionality for students" by Chris Mills
            students.Where(s => s.Name.ToUpper().Contains(query.ToUpper())).ToList().ForEach(Console.WriteLine);
        }

        public static void printPersonMenu()
        {
            Console.WriteLine("Person Options."); //
            Console.WriteLine("1. Create a person."); // DONE
            Console.WriteLine("2. Search for a person."); // DONE
            Console.WriteLine("3. Update a person's info.");  // DONE
            Console.WriteLine("4. List all people."); // DONE
            Console.WriteLine("5. List all courses a student is taking."); //DONE
            Console.WriteLine("6. Add person from list to specific course."); // DONE
            Console.WriteLine("7. Remove person from list to specific course."); // DONE
            Console.WriteLine("8. Calculate a student's grade for a specific course."); // DONE
            Console.WriteLine("9. Calculate a student's GPA."); // DONE
            Console.WriteLine("0. Go back to main menu"); // DONE
        }

        public override string ToString()
        {
            return _name + " - " + _classification;
        }

    }
}