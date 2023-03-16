# Command-Line-Learning-Management-System
This project is an implementation of a Learning Management System (LMS) like Blackboard or Canvas. This project was for a grade in the Full-stack Development in C# course 
offered by Florida State University. This course was taught by Dr. Chris Mills, and although sparingly, some parts of the code were modeled by his implementations.

This is the command line version of the LMS which will eventually (if not already) be converted to a UWP & XAML application.

# Features
* Crud of the following models:
  * Courses
    * Announcements
    * Modules
    * Assignmnets
    * ContentItem (to be added to modules)
      * PageItem
      * FileItem
      * AssignmentItem
  * Person (to be added to list of courses)
    * Student
    * Instructor
    * TA
* Input grades for a student
* Assign weighted groups that assignments can be added to
* Calculate a student's grade based off the weighted assignment groups
* Calculate a student's GPA based off grades of other courses
* Easily navigable command line menu system.
