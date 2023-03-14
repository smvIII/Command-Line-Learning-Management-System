using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LearningManagementSystem.Models
{
    public class Announcement
    {
        private string _body;
        private string _title;


        public string Body 
        { 
            get { return _body; }
            set { _body = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }


        public static void CreateAnnouncement(List<Course> courses)
        {
            Console.WriteLine("Please select a course to create an announcement for.");
            int courseIndex = Services.ListSelect(courses, 1);

            Console.WriteLine("Please enter a title for the announcement");
            string newAnnouncementTitle = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Please enter a string of text for the announcement.");
            string newAnnouncementBody = Console.ReadLine() ?? string.Empty;

            Announcement newAnnouncement= new Announcement();

            newAnnouncement.Title = newAnnouncementTitle;
            newAnnouncement.Body = newAnnouncementBody;

            courses[courseIndex].Announcements.Add(newAnnouncement);
        }

        public static void RemoveAnnouncement(List<Course> courses)
        {
            Console.WriteLine("Please select a course to remove announcement.");
            int courseIndex = Services.ListSelect(courses, 1);

            Console.WriteLine("Please select an announcement to remove.");
            int announcementIndex = Services.ListSelect(courses[courseIndex].Announcements, 1);

            courses[courseIndex].Announcements.Remove(courses[courseIndex].Announcements[announcementIndex]);
        }

        public static void UpdateAnnouncement(List<Course> courses)
        {
            Console.WriteLine("Please select a course to update announcement.");
            int courseIndex = Services.ListSelect(courses, 1);
            Console.WriteLine("Please select an announcement to update.");
            int announcementIndex = Services.ListSelect(courses[courseIndex].Announcements, 1);

            Console.WriteLine("What from the announcement would you like to update?");
            Console.WriteLine("1. Title.");
            Console.WriteLine("2. Body.");
            string choice = Console.ReadLine() ?? string.Empty;

            if (int.TryParse(choice, out int choiceInt)) 
            {
                if (choiceInt == 1 )
                {
                    Console.WriteLine("Please enter a new title for the announcement.");
                    string newTitle = Console.ReadLine() ?? string.Empty;
                    courses[courseIndex].Announcements[announcementIndex].Title = newTitle;
                }
                else if (choiceInt == 2)
                {
                    Console.WriteLine("Please enter a new string of text for the body.");
                    string newBody = Console.ReadLine() ?? string.Empty;
                    courses[courseIndex].Announcements[announcementIndex].Body = newBody;
                }
            }
        }

        public static void ReadAnnouncement(List<Course> courses)
        {
            Console.WriteLine("Please select a course to read announcement.");
            int courseIndex = Services.ListSelect(courses, 1);

            Console.WriteLine("Please select an announcement to read.");
            int announcementIndex = Services.ListSelect(courses[courseIndex].Announcements, 1);

            Console.WriteLine(courses[courseIndex].Announcements[announcementIndex].Body);

        }

        public override string ToString()
        {
            return _title;
        }

    }
}
