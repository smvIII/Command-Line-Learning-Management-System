using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using LearningManagementSystem.Models.People;

namespace LearningManagementSystem.Models
{
    public class Course
    {
        //fields
        private int _creditHours;
        private string _code;
        private string _name;
        private string _description;
        private List<Person> _roster;
        private List<Assignment> _assignments;
        private List<Module> _modules;
        private List<Announcement> _announcements;
        private List<Tuple<string, double>> _weights;



        public Course()
        {
            _roster = new List<Person>();
            _assignments = new List<Assignment>();
            _modules = new List<Module>();
            _announcements = new List<Announcement>();
            _weights = new List<Tuple<string, double>>();
        }

        //properties
        public int CreditHours
        {
            get { return _creditHours; }
            set { _creditHours = value; }
        }
        public string Code // property that exposes _code field.
        {
            get { return _code; }
            set { _code = value; }
        }

        public string Name // property that exposes _name field.
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description // property that exposes _description field.
        {
            get { return _description; }
            set { _description = value; }
        }

        public List<Person> Roster // property that exposes _roster field.
        {
            get { return _roster; }
            set { _roster = value; }
        }

        public List<Assignment> Assignments
        {
            get { return _assignments; }
            set { _assignments = value; }
        }
        public List<Module> Modules
        {
            get { return _modules; }
            set { _modules = value; }
        }

        public List<Announcement> Announcements
        {
            get { return _announcements; }
            set { _announcements = value; }
        }
        public List<Tuple<string, double>> Weights
        {
            get { return _weights; }
            set { _weights = value; }
        }


        static public Course AddCourse(List<Course> courses)
        {
            Course newCourse = new Course();
            bool uniqueCode = true;
            string newCourseCode;

            do
            {
                Console.WriteLine("Enter code for the course.");
                newCourseCode = Console.ReadLine() ?? string.Empty;
                if (Course.Exists(courses, newCourseCode) == true)
                {
                    Console.WriteLine("This course code already exists! Please reenter a unique code.");
                    uniqueCode = false;
                }
                else
                    uniqueCode = true;
            } while (!uniqueCode);

            Console.WriteLine("Enter name for the course.");
            string newCourseName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter description for the course.");
            string newCourseDesc = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter the number of credit hours for the course.");
            int newCourseCH = int.Parse(Console.ReadLine() ?? string.Empty);

            newCourse.CreditHours = newCourseCH;
            newCourse.Code = newCourseCode;
            newCourse.Name = newCourseName;
            newCourse.Description = newCourseDesc;
            Console.Clear();
            return newCourse;
        }
        static public Course UpdateCourse(List<Course> courses)
        {

            int courseIndex = ListSelect(courses, 1);
            //Console.WriteLine(courses[courseIndex].Code);
            Console.WriteLine("What would you like to update about the course?");
            Console.WriteLine("1. Course Code");
            Console.WriteLine("2. Course Name");
            Console.WriteLine("3. Course Description");

            string choice = Console.ReadLine() ?? string.Empty;

            if (int.TryParse(choice, out int choiceInt))
            {
                if (choiceInt == 1)
                {
                    bool uniqueCode = true;
                    do
                    {
                        Console.Write("Please enter the updated course code: ");
                        string updatedCourseCode = Console.ReadLine() ?? string.Empty;
                        if (Course.Exists(courses, updatedCourseCode) == true)
                        {
                            Console.WriteLine("This course code already exists! Please reenter a unique code.");
                            uniqueCode = false;
                        }
                        else
                            uniqueCode = true;

                        courses[courseIndex].Code = updatedCourseCode;
                    }
                    while(!uniqueCode);
                }
                else if (choiceInt == 2)
                {
                    Console.Write("Please enter the updated course name: ");
                    string updatedCourseName = Console.ReadLine() ?? string.Empty;
                    courses[courseIndex].Name = updatedCourseName;
                }
                else if (choiceInt == 3)
                {
                    Console.Write("Please enter the updates course description: ");
                    string updatedCourseDesc = Console.ReadLine() ?? string.Empty;
                    courses[courseIndex].Description = updatedCourseDesc;
                }
            }
            return new Course();
        }

        static public Assignment CreateAssignment(List<Course> courses, int courseIndex)
        {
            Assignment newAssignment = new Assignment();

            Console.WriteLine("Please enter name for the assignment");
            string newAssignmentName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please enter description for the assignment");
            string newDescriptName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please enter the total available points for the assignment");
            string newTotalAvailPoints = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please select which weight group this assignmnet belongs to.");
            int weightGroupIndex = Services.ListSelect(courses[courseIndex].Weights, 1);
            double newWeight = courses[courseIndex].Weights[weightGroupIndex].Item2;

            newAssignment.Name = newAssignmentName;
            newAssignment.Description = newDescriptName;
            newAssignment.TotalAvailablePoints = newTotalAvailPoints;
            newAssignment.Weight = newWeight;
            newAssignment.CourseIndex = courseIndex.ToString();


            Console.Clear();
            return newAssignment;
            //Course._assignments.Add(newAssignment);
            //return newAssignment;
        }

        static public Module CreateModule()
        {
            Module newModule = new Module();
            Console.WriteLine("Please enter name for the module");
            string newModuleName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please enter description for module");
            string newModuleDesc = Console.ReadLine() ?? string.Empty;
            newModule.Name = newModuleName;
            newModule.Description = newModuleDesc;
            Console.Clear();
            return newModule;
        }

        static public void AddAssignment(Assignment newAssignment, List<Course> courses)
        {
            courses[int.Parse(newAssignment.CourseIndex)].Assignments.Add(newAssignment);
        }

        public void printAssignments()
        {
            for (int i = 0; i < Assignments.Count; i++)
            {
                Console.WriteLine("Assignment " + i + ": " + Assignments[i].Name);
            }
        }

        public static bool Exists(List<Course> courses, string code)
        {
            foreach (var course in courses)
            {
                if (code == course.Code)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        
        public static int ListSelect(List<Course> courses, int option)
        {
            if (option == 0)
            { Console.WriteLine("Select a course to look at."); }
            else if (option == 1)
            { Console.WriteLine("Select a course to update."); }
            else if (option == 2)
            {
                Console.WriteLine("Select a course to add assignment to");
            }
            else if (option == 3)
            {
                Console.WriteLine("Select a course to add a module to");
            }

            int i = 1;
            foreach (var course in courses)
            {
                Console.WriteLine(i + ": " + course.Name + " - " + course.Code);
                i++;
            }
            string choice = Console.ReadLine() ?? string.Empty;
            Console.Clear();
            if (option == 0 && int.Parse(choice) < i) // just look at course
            {
                Console.WriteLine(courses[int.Parse(choice) - 1]);
            }
            else
            {
                return int.Parse(choice) - 1; // return choice to update
            }
            return 0;
        }

        public static void AddStudentToCourse(List<Person> students, List<Course> courses)
        {
            Console.WriteLine("Please select a course to add a student to.");
            int courseIndex = ListSelect(courses, -1);
            Console.WriteLine("Please select a student to add to that course.");
            int studentIndex = Person.ListSelect(students, 1);
            courses[courseIndex].Roster.Add(students[studentIndex]);
            courses[courseIndex].PrintCourseStudents();
            Console.Clear();

        }

        public static void CreateAssignmnetGroups(List<Course> courses)
        {
            double currentWeight = 0.0;
            bool keepGoing = true;

            Console.WriteLine("Please select a course to create assignmnet groups for");
            int courseIndex = Services.ListSelect(courses, 1);


            while (keepGoing)
            {
                string newWeightGroupName;
                double newWeight;
                Console.WriteLine("Please enter name for new weight group");
                newWeightGroupName = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("Please enter weight for new weight group");
                newWeight = double.Parse(Console.ReadLine() ?? string.Empty);
                courses[courseIndex].Weights.Add(Tuple.Create(newWeightGroupName, newWeight));
                currentWeight += newWeight;
                

                if (currentWeight >= 1.0)
                    keepGoing= false;

            }
        }

        public static void RmStudentFromCourse(List<Person> students, List<Course> courses)
        {
            Console.WriteLine("Please select a course to remove a student from.");
            int courseIndex = ListSelect(courses, -1);
            Console.WriteLine("Please select a student to remove from course.");
            int studentIndex = Person.ListSelect(students, 1);
            courses[courseIndex].Roster.Remove(students[studentIndex]);
            courses[courseIndex].PrintCourseStudents();

        }

        public void PrintCourseStudents()
        {
            Console.WriteLine("Updated " + Name + " roster.");
            for (int i = 0; i < Roster.Count; i++)
            {
                Console.WriteLine(Name + ": " + Roster[i].Name);
            }
        }

        public static void CourseSearch(List<Course> courses)
        {
            Console.WriteLine("Please enter name or description of course to search:");

            string query = Console.ReadLine() ?? string.Empty;

            // modeled from youtube video "Ep 11. Adding search functionality for courses" by Chris Mills
            courses.Where(s => s.Name.ToUpper().Contains(query.ToUpper())
                || s.Description.ToLower().Contains(query.ToLower())).ToList()
                .ForEach(Console.WriteLine);
        }
        
        public static double CalculateCourseGrade(List<Person> students, List<Course> courses, string key, int studentIndex, int option)
        {
            if (option == 0)
            {
                Console.WriteLine("Please select a course to calucalate a students grade.");
                int courseIndex = Services.ListSelect(courses, 1);
                Console.WriteLine("Please select a student to calculate their grade.");
                studentIndex = Services.ListSelect(students, 1);
                key = courses[courseIndex].Name;
            }

            Dictionary<double, int> inputGrades = new Dictionary<double, int>();
            //double is the weight, int is the total student's awards points
            Dictionary<double, int> weightTAPs = new Dictionary<double, int>();
            // double is the weight, int is the total available points for that weight category
            Dictionary<double, double> weightGrades = new Dictionary<double, double>();
            // double is the weight, second double is the average of that weight category

            double courseGrade = 0.0;

            // initialize all values so they are ready to be added
            for (int i = 0; i < students[studentIndex].CourseGradesMap[key].Count; i++)
            {
                double weight = students[studentIndex].CourseGradesMap[key][i].Assignment.Weight;
                inputGrades[weight] = 0;
                weightTAPs[weight] = 0;
            }
            // add up all input grades and total available points
            for (int i = 0; i < students[studentIndex].CourseGradesMap[key].Count; i++)
            {
                double weight = students[studentIndex].CourseGradesMap[key][i].Assignment.Weight;
                inputGrades[weight] += students[studentIndex].CourseGradesMap[key][i].InputGrade;
                weightTAPs[weight] += int.Parse(students[studentIndex].CourseGradesMap[key][i].Assignment.TotalAvailablePoints);
            }
            // divide each weight categories total input by total available points
            for (int i = 0; i < students[studentIndex].CourseGradesMap[key].Count; i++)
            {
                double weight = students[studentIndex].CourseGradesMap[key][i].Assignment.Weight;
                weightGrades[weight] = ((double)inputGrades[weight]) / ((double)weightTAPs[weight]);
            }
            
            foreach (var item in weightGrades)
            {
                courseGrade += (item.Value * item.Key);
            }

            if (option == 1)
            {
                return courseGrade;
            }
            else
            {
                Console.WriteLine("Course Grade: " + (100*courseGrade));
            }
            return 0.0;

        }
        public static void printCourseMenu()
        {
            Console.WriteLine("Course Options");
            Console.WriteLine("1. Create course."); // DONE
            Console.WriteLine("2. Search for course by name or description."); // DONE
            Console.WriteLine("3. Update a course's information."); // DONE
            Console.WriteLine("4. List all courses."); // DONE
            Console.WriteLine("5. Create assignment groups for a specific course"); // DONE
            Console.WriteLine("6. Create assignment for a specific course"); // DONE
            Console.WriteLine("7. Input an assignmnet grade for a student."); // DONE
            Console.WriteLine("8. Create or delete an announcement."); 
            Console.WriteLine("9. Read or update an announcement");
            Console.WriteLine("0. Go back to main menu"); // DONE
        }
        public override string ToString()
        {
            return "Course Code : " + _code + " | Course Name: " + _name + " | Course Description: " + _description;
        }
    }
}
