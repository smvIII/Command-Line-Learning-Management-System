using System;
using System.Reflection.PortableExecutable;
using LearningManagementSystem.Models.People;
using LearningManagementSystem.Models;
using System.Runtime.Serialization;
using LearningManagementSystem;
using LearningManagementSystem.Models.Items;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace cop4870
{
    internal class Assignment1
    {
        static void Main(string[] args)
        {

            bool navMainMenu = true;
            var courses = new List<Course>();
            var students = new List<Person>();

            while (navMainMenu)
            {
                navMainMenu = mainMenu(courses, students);
            }    
        }
        static bool mainMenu(List<Course> courses, List<Person> students)
        {
            Console.WriteLine("Welcome to the Learning Management System!");
            Console.WriteLine("Please select which menu you would like to navigate.");
            Console.WriteLine("1. Course Options");
            Console.WriteLine("2. Person Options");
            Console.WriteLine("3. Module Options");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine() ?? string.Empty;

            if (int.TryParse(choice, out int choiceInt))
            {
                if (choiceInt == 1)
                {

                    Console.Clear();
                    courseMenu(courses, students);
                }
                else if (choiceInt == 2)
                {
                    Console.Clear();
                    studentMenu(students, courses);
                }
                else if (choiceInt == 3)
                {
                    Console.Clear();
                    moduleMenu(courses);
                }

                if (choiceInt == 4)
                {
                    return false;
                }
            }
            return true;
        }
        static void courseMenu(List<Course> courses, List<Person> students)
        {
            bool navCourseMenu = true;

            while (navCourseMenu)
            {

                Course.printCourseMenu();
                string choice = Console.ReadLine() ?? string.Empty;
                Console.Clear();

                if (int.TryParse(choice, out int choiceInt))
                {
                    if (choiceInt == 1)
                    {
                        courses.Add(Course.AddCourse(courses));
                    }
                    else if (choiceInt == 2) // queries or something
                    {
                        Course.CourseSearch(courses);
                    }
                    else if (choiceInt == 3) // update a course's information
                    {
                        Course.UpdateCourse(courses);   
                    }
                    else if (choiceInt == 4) // List
                    {
                       
                        Course.ListSelect(courses, 0);
                    }

                    else if (choiceInt == 5) // create assignment groups
                    {
                        Course.CreateAssignmnetGroups(courses);
                    }

                    else if (choiceInt == 6) //create assignment and add to assignment group
                    {

                        int courseIndex = Course.ListSelect(courses, 2);
                        Assignment newAssignment = Course.CreateAssignment(courses, courseIndex);
                        Course.AddAssignment(newAssignment, courses);
                        courses[courseIndex].printAssignments();

                    }

                    else if (choiceInt == 7) // input grade
                    {
                        Student.InputGrade(students, courses);
                    }
                    else if (choiceInt == 8) // create or delete announce 
                    {
                        Console.WriteLine("Please select whether you would like to create or delete an announcement.");
                        Console.WriteLine("1. Create.");
                        Console.WriteLine("2. Delete.");

                        string input = Console.ReadLine() ?? string.Empty;
                        if (int.TryParse(input, out int intInput))
                        {
                            if (intInput == 1)
                            {
                                Announcement.CreateAnnouncement(courses);
                            }
                            else if (intInput == 2)
                            {
                                Announcement.RemoveAnnouncement(courses);
                            }
                        }

                    }
                    else if (choiceInt == 9) // read or update announcement
                    {

                        Console.WriteLine("Please select whether you would like to read or update an announcement.");
                        Console.WriteLine("1. Read.");
                        Console.WriteLine("2. Update.");

                        string input = Console.ReadLine() ?? string.Empty;
                        if (int.TryParse(input, out int intInput))
                        {
                            if (intInput == 1)
                            {
                                Announcement.ReadAnnouncement(courses);
                            }
                            else if (intInput == 2)
                            {
                                Announcement.UpdateAnnouncement(courses);
                            }
                        }
                    }
                    else
                    {
                        navCourseMenu = false;
                    }
                }
            }
        }

        static void studentMenu(List<Person> students, List<Course> courses)
        {
            bool navStudentMenu = true;

            while (navStudentMenu)
            {
                Person.printPersonMenu();
                string choice = Console.ReadLine() ?? string.Empty;
                Console.Clear();

                if (int.TryParse(choice, out int choiceInt))
                {
                    if (choiceInt == 1) // Create a student
                    {
                        students.Add(Person.AddPerson());
                    }
                    else if (choiceInt == 2) //search for a student
                    {
                        Person.PersonSearch(students);
                    }
                    else if (choiceInt == 3) // update a students info
                    {
                        Person.UpdatePerson(students);
                    }
                    else if (choiceInt == 4) // list all students
                    {
                        Console.WriteLine("Here is a list of all enrolled students");
                        Services.ListSelect(students, 0);
                    }   
                    else if (choiceInt == 5) // list all courses a student is taking
                    {
                        Student.ListStudentCourses(students, courses);
                    }
                    else if (choiceInt == 6) //add student from list of students and add to course
                    {
                        Course.AddStudentToCourse(students, courses);
                    }
                    else if (choiceInt == 7) // remove a student from a course's roster
                    {
                        Course.RmStudentFromCourse(students, courses);
                    }
                    else if (choiceInt == 8) // calculate grade for specific course
                    {
                        Course.CalculateCourseGrade(students, courses, "key", 0, 0);
                    }
                    else if (choiceInt == 9) // calculate a students gpa across all courses
                    {
                        Student.CalculateGPA(students, courses);
                    }
                    else
                    {
                        navStudentMenu = false;
                    }
                }

            }
        }
       
        static void moduleMenu(List<Course> courses)
        {
            bool navModuleMenu = true;

            while (navModuleMenu)
            {
                Module.printModuleMenu();
                string choice = Console.ReadLine() ?? string.Empty;
                Console.Clear();
                if (int.TryParse(choice, out int choiceInt))
                {
                    if (choiceInt == 1) // CREATE MODULE
                    {
                        Console.WriteLine("Please select a course to add a module to.");
                        int courseIndex = Services.ListSelect(courses, 1);
                        Module newModule = Course.CreateModule();
                        courses[courseIndex].Modules.Add(newModule);    
                    }
                    else if (choiceInt == 2) //CREATE ITEM FOR MODULE
                    {
                        Console.WriteLine("Please select a course to add item to a module.");
                        int courseIndex = Services.ListSelect(courses, 1);
                       // int courseIndex = Course.ListSelect(courses, 9);
                        Console.WriteLine("Please select a module to add an item to.");
                        int moduleIndex = Services.ListSelect(courses[courseIndex].Modules, 1);
                        Module.CreateItemForModule(courses[courseIndex].Modules, courses, moduleIndex, courseIndex);
                    }
                    else if (choiceInt == 3) // UPDATE ITEM
                    {

                        Console.WriteLine("Please select which course to update item from module.");
                        int courseIndex = Services.ListSelect(courses, 1);
                        Console.WriteLine("Please select which module to update its item.");
                        int moduleIndex = Services.ListSelect(courses[courseIndex].Modules, 1);
                        Console.WriteLine("Please select which item to update.");
                        int itemIndex = Services.ListSelect(courses[courseIndex].Modules[moduleIndex].Content, 1);
                        ContentItem.UpdateItem(courses, courses[courseIndex].Modules[moduleIndex].Content[itemIndex]);
                    }
                    else if (choiceInt == 4) // List all modules and items
                    {
                        Console.WriteLine("Please select the course to list its modules and items");
                        int courseIndex = Services.ListSelect(courses, 1);
                        int moduleIndex = Services.ListSelect(courses[courseIndex].Modules, 0);
                        int i = 1;
                        if (courses[courseIndex].Modules.Count > 0)
                        {
                            foreach (var item in courses[courseIndex].Modules[moduleIndex].Content)
                            {
                                Console.WriteLine("\tItem " + i + ": " + item);
                                i++;
                            }
                        }
                    }
                    else if (choiceInt == 5) // Read an item
                    {
                        Console.WriteLine("Please select the course to read a item from one of its modules.");
                        int courseIndex = Services.ListSelect(courses, 1);
                        Console.WriteLine("Please select the module to read one of its items.");
                        int moduleIndex = Services.ListSelect(courses[courseIndex].Modules, 1);
                        Console.WriteLine("Please select the item to read.");
                        int itemIndex = Services.ListSelect(courses[courseIndex].Modules[moduleIndex].Content, 1);
                        Console.WriteLine("Here is item " + 
                            courses[courseIndex].Modules[moduleIndex].Content[itemIndex].Name + "'s contents");
                        ContentItem.ShowContent(courses[courseIndex].Modules[moduleIndex].Content[itemIndex]);
                        
                    }
                    else if (choiceInt == 6) // remove an item
                    {
                        Module.RmItemFromModule(courses);
                    }
                    else
                    {
                        navModuleMenu = false;
                    }
                }
            }

        }
    }
}