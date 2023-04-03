using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Library.Models.Items
{
    public class FileItem : ContentItem
    {
        private string _filepath;

        public string FilePath
        {
            get { return _filepath; }
            set { _filepath = value; }
        }

        public static void UpdateFileItem(List<Course> courses, ContentItem item)
        {
            Console.WriteLine("Please select what you would like to update.");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Description");
            Console.WriteLine("3. FilePath");

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
                    Console.WriteLine("Please enter new FilePath for the item.");
                    string newItemFilePath = Console.ReadLine() ?? string.Empty;
                    ((FileItem)item).FilePath = newItemFilePath;
                }
                Console.Clear();
            }
        }

        public static FileItem CreateFileItem()
        {
            FileItem newFileItem  = new FileItem();
            
            Console.WriteLine("Please enter a name for the the FileItem.");
            string newFileItemName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please enter description for the FileItem.");
            string newFileItemDesc = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please enter filepath for the FileItem.");
            Console.WriteLine(@"Format: C:\\Users\\*USERNAME*\\Documents\\*FILENAME*");
            string newFileItemFilePath = Console.ReadLine() ?? string.Empty;
            
            newFileItem.FilePath = newFileItemFilePath;
            newFileItem.Name = newFileItemName;
            newFileItem.Description = newFileItemDesc;
            newFileItem.Type = "FileItem";

            return newFileItem;
        }



    }
}
