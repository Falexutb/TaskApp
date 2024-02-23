Task Management App

**Description**
The Task Management App is a console application written in C# that facilitates efficient task management. Users can perform various operations, including adding, displaying, sorting, marking as done, removing, editing, and saving/loading tasks from a file.

**Visuals**
No visual assets are included at the moment. Consider adding screenshots or a demo video to showcase the app's functionality.

**Files**

Program.cs
This file contains the main logic for the Task Management App. The Program class serves as the entry point, displaying the main menu and handling user input.

Task.cs
The Task class represents a single task with properties such as ID, title, due date, project, and completion status.

TaskManager.cs
The TaskManager class manages a list of tasks and provides various functionalities like adding, displaying, sorting, marking as done, removing, editing, saving, and loading tasks.

**Usage**
Add Task: Allows users to add a new task with a title, due date, and project.
Display Tasks: Displays the list of tasks with color-coded status.
Sort Tasks by Due Date: Arranges tasks based on their due dates.
Sort Tasks by Project: Arranges tasks based on their projects.
Mark Task as Done: Sets a task as completed.
Remove Task: Deletes a task from the list.
Edit Task: Modifies the details of an existing task.
Save Tasks to File: Stores tasks in a file for future use.
Load Tasks from File: Retrieves tasks from a previously saved file.
Help: Displays a help section explaining the app's functionalities.
Quit: Exits the application.

Color Coding
Red: Tasks that have not been completed within the deadline.
Magenta: Completed tasks outside the deadline.
Yellow: Uncompleted tasks within the deadline.
Green: Completed tasks within the deadline.

Symbols:
[X]: Completed task within the deadline.
[O]: Incomplete task (overdue).
[U]: Uncompleted task within the deadline.
[A]: Completed task (after the deadline).

Date Format 
The date format expected for input is dd/MM/yyyy.

Default File Path
The default file path for saving and loading tasks is set to myTodoList.txt. Users may need to input the file path manually if required.

**How to Run**
Compile the C# files and run the resulting executable. Follow the on-screen instructions to navigate through the application.

Clone the repository:
git clone https://github.com/yourusername/task-management-app.git

Navigate to the project directory:
cd task-management-app

Compile and run the application:
dotnet run

**Contributing**
Contributions are welcome! If you'd like to contribute, follow the contribution guidelines. Make sure to fork the project, make improvements, and submit pull requests.

**Project Status**
Development is currently active. If you have suggestions or encounter issues, feel free to contribute. If you are interested in becoming a maintainer or owner, please reach out.
I look forward to seeing the Task Management App evolve and become even more useful for users!








