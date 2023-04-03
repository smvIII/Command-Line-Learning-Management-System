using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Library.Models.Items;
using LMS.Library.Models.People;

namespace LMS.Library.Models
{
    public class Module
    {
        private string ?_name;
        private string ?_description;
        private List<ContentItem> _content;

        public Module()
        {
            _content = new List<ContentItem>();
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

        public List<ContentItem> Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public static void CreateItemForModule(List<Module> modules, List<Course> courses, int moduleIndex, int courseIndex )
        {
            Console.WriteLine("Please select what kind of item you want to create");
            Console.WriteLine("1. PageItem");
            Console.WriteLine("2. AssignmentItem");
            Console.WriteLine("3. FileItem");

            string choice = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(choice, out int choiceInt))
            {
                if (choiceInt == 1 ) // CREATE pageItem DONE
                {
                    PageItem newPageItem = new PageItem();
                    newPageItem = (PageItem)PageItem.CreatePageItem();
                    modules[moduleIndex].Content.Add(newPageItem);
                }
                else if (choiceInt == 2 ) // CREATE assignmentItem
                {
                    AssignmentItem newAssignmentItem = new AssignmentItem();
                    newAssignmentItem = (AssignmentItem)AssignmentItem.CreateAssignmentItem(courses, courseIndex);
                    modules[moduleIndex].Content.Add(newAssignmentItem);
                }
                else // CREATE fileItem
                {
                    FileItem newFileItem = new FileItem();
                    newFileItem = (FileItem)FileItem.CreateFileItem();
                    modules[moduleIndex].Content.Add(newFileItem);
                }
            }
            Console.WriteLine("Item added!");
            Console.Clear();
        }



        public static void RmItemFromModule(List<Course> courses)
        {
         
            Console.WriteLine("Please select which course to remove item from module.");
            int courseIndex = Services.ListSelect(courses, 1);
            Console.WriteLine("Please select which module to remove an item.");
            int moduleIndex = Services.ListSelect(courses[courseIndex].Modules, 1);
            if (courses[courseIndex].Modules[moduleIndex].Content.Count > 0)
            {
                Console.WriteLine("Please select which item to remove from module");
                int itemIndex = Services.ListSelect(courses[courseIndex].Modules[moduleIndex].Content, 1);
                courses[courseIndex].Modules[moduleIndex].Content.Remove(courses[courseIndex].Modules[moduleIndex].Content[itemIndex]);
            }
            else
            {
                Console.WriteLine("The module is empty.");
            }
        }
        public static void printModuleMenu()
        {
            Console.WriteLine("Module Options");
            Console.WriteLine("1. Create a module for a course."); // DONE 
            Console.WriteLine("2. Create an item for a module.");  // DONE
            Console.WriteLine("3. Update an item for a module.");  // DONE
            Console.WriteLine("4. List modules for a course."); // DONE
            Console.WriteLine("5. Read an item's contents from a module."); // 2/3 done
            Console.WriteLine("6. Remove an item from a module."); //DONE
            Console.WriteLine("7. Go back to main menu."); //DONE
        }
        public override string ToString()
        {
            return "Module Name : " + _name + " | Module Description: " + _description;
        }
    }
}
