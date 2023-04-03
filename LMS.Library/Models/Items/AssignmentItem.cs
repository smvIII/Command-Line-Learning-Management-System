using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Library.Models.Items
{
    public class AssignmentItem : ContentItem
    {
        private Assignment _assignment;

        public Assignment Assignment
        {
            get { return _assignment; }
            set { _assignment = value; }
        }

        public static void UpdateAssignmentItem(List<Course> courses, ContentItem item)
        {
            Console.WriteLine("Please select what you would like to update.");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Description");
            Console.WriteLine("3. Points");
            //Console.WriteLine("3. Assignment");
            string choice = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(choice, out int choiceInt))
            {
                if (choiceInt == 1)
                {
                    Console.WriteLine("Please enter the new name for the item.");
                    string newItemName = Console.ReadLine() ?? string.Empty;
                    item.Name = newItemName;
                }
                if (choiceInt == 2)
                {
                    Console.WriteLine("Please enter new Description for the item.");
                    string newItemDesc = Console.ReadLine() ?? string.Empty;
                    item.Description = newItemDesc;
                }
                if (choiceInt == 3)
                {
                    Console.WriteLine("Please enter the new Total Available Points for the item.");
                    string newItemTAP = Console.ReadLine() ?? string.Empty;
                    ((AssignmentItem)item).Assignment.TotalAvailablePoints = newItemTAP;
                }
                Console.Clear();
            }

        }
        public static AssignmentItem CreateAssignmentItem(List<Course>courses, int courseIndex)
        {
            AssignmentItem newAssignmentItem = new AssignmentItem();

            //Console.WriteLine("Please enter a name for the the AssignmentItem.");
            //string newAssignmentItemName = Console.ReadLine() ?? string.Empty;
            //Console.WriteLine("Please enter description for the AssignmentItem.");
           // string newAssignmentItemDesc = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please select an assignment to add to the module");
            int assignmentIndex = Services.ListSelect(courses[courseIndex].Assignments, 1);
           // Assignment newAssignmentItemAssignment = courses[courseIndex].Assignments[assignmentIndex];

            newAssignmentItem.Assignment = courses[courseIndex].Assignments[assignmentIndex];
            newAssignmentItem.Name = newAssignmentItem.Assignment.Name;
            newAssignmentItem.Description = newAssignmentItem.Assignment.Description;
            newAssignmentItem.Type = "AssignmentItem";

            return newAssignmentItem;

        } 
      
    }
}
