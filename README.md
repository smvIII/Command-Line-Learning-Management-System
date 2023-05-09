# Summary
This project is an implementation of a Learning Management System (LMS) like Blackboard or Canvas. This project was for a grade in the Full-stack Development in C# course 
offered by Florida State University. This course was taught by Dr. Chris Mills, and although sparingly, some parts of the code were modeled by his implementations. It uses the Xamarin based framework, .NET MAUI for its UI. 

## Directories
- `LMS.Library` contains the code that `LMS.Maui` uses for its backend implementations.
- `LMS.Maui` contains all the source code for the frontend. 
- `LearningManagementSystem` this is the old version of the program that was console based before it was migrated to .NET MAUI.

## Models and their attributes
  * Courses
    * Announcements
    * Modules
    * Assignmnets
    * ContentItem (to be added to modules)
      * PageItem
      * FileItem
      * AssignmentItem
  * Student (to be added to list of courses)
   
## Instructor Priveleges
* Essentially admin
* Create course and person models
* Enroll students into courses
* Input grades for a student
* Assign weighted groups that assignments can be added to

## Student View
* Displays the courses that the student is enrolled in
* Upon selection of a course, displays grades, modules, and announcements for the course
* Calculate a student's grade based off the weighted assignment groups
* Calculate a student's GPA based off grades of other courses
