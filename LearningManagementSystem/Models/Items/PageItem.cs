using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LearningManagementSystem.Models.Items
{
    public class PageItem : ContentItem
    {
        private string _htmlbody;

        public string HTMLBody
        {
            get { return _htmlbody; }
            set { _htmlbody = value; }
        }

        public static PageItem CreatePageItem()
        {
            PageItem newPageItem = new PageItem();
            
            Console.WriteLine("Please enter a name for the the PageItem.");
            string newPageItemName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please enter description for the PageItem.");
            string newPageItemDesc = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please enter the filepath for the PageItem's HTML Body");
            Console.WriteLine(@"Format: C:\\Users\\*USERNAME*\\Documents\\*FILENAME*");
            string newPageItemFP = Console.ReadLine() ?? string.Empty;
          
            newPageItemFP = newPageItemFP.Trim('\r', '\n');
            newPageItem.Name = newPageItemName;
            newPageItem.Description = newPageItemDesc;
            newPageItem.Path = newPageItemFP;
            newPageItem.HTMLBody = File.ReadAllText(newPageItemFP);
            newPageItem.Type = "PageItem";
            Console.WriteLine(newPageItem.HTMLBody);

            return newPageItem;
        }

        public static void UpdatePageItem(List<Course> courses, ContentItem item)
        {
            Console.WriteLine("Please select what you would like to update.");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Description");
            Console.WriteLine("3. HTMLBody");

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
                    Console.WriteLine("Please enter the new description for the item.");
                    string newItemDesc = Console.ReadLine() ?? string.Empty;
                    item.Description = newItemDesc;
                }
                if (choiceInt == 3)
                { 
                        Console.WriteLine("Please enter the new filepath for the HTMLBody.");
                        Console.WriteLine(@"Format: C:\\Users\\*USERNAME*\\Documents\\*FILENAME*");
                        string  newHTMLBodyFilePath = Console.ReadLine() ?? string.Empty;

                        newHTMLBodyFilePath = newHTMLBodyFilePath.Trim('\r', '\n');
                        ((PageItem)item).HTMLBody = File.ReadAllText(newHTMLBodyFilePath);
                        //((PageItem)item).HTMLBody = newHTMLBodyFilePath;
                        Console.WriteLine(((PageItem)item).HTMLBody); 
                }
            }
        }

        public static void PrintContent(PageItem pg)
        {
            Console.WriteLine(pg._htmlbody);
        }
       
    }
}
