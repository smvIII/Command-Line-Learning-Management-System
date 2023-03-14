using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem.Models.Items
{
    public class ContentItem
    {
        private string _name;
        private string _description;
        private string _path;
        private string _type;

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

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public static void ShowContent(ContentItem item)
        {
            if (item.Type == "PageItem")
            {
                var pgItm = (PageItem)item;
                PageItem.PrintContent(pgItm);
            }
            else if (item.Type == "AssignmentItem")
            {
                var asItm = (AssignmentItem)item;
                Console.WriteLine(asItm.Assignment);

            }
            else
            {
                var flItm = (FileItem)item;
                Console.WriteLine(flItm.FilePath);
            }

        }

        public static void UpdateItem(List<Course> courses, ContentItem item)
        {
            
            if (item.Type == "PageItem")
            {
                PageItem.UpdatePageItem(courses, item);
            }
            else if (item.Type == "AssignmentItem")
            {
                AssignmentItem.UpdateAssignmentItem(courses, item);
            }
            else
            {
                FileItem.UpdateFileItem(courses, item);
            }

        }

        public override string ToString()
        {
            return _name + " - " + _description;
        }

    }
}
