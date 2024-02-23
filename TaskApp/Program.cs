using System;

namespace TaskApp
{
    // Program class contains the entry point and main logic for the Task Management App
    internal class Program
    {
        // Entry point of the application
        private static void Main()
        {
            // Create an instance of TaskManager to manage tasks
            TaskManager taskManager = new TaskManager();

            // Main application loop
            while (true)
            {
                // Display the main menu to the user
                DisplayMainMenu();

                try
                {
                    // Get user choice from the menu
                    int choice = GetUserChoice();

                    // Perform actions based on user choice
                    switch (choice)
                    {
                        case 1:
                            AddTask(taskManager);
                            break;

                        case 2:
                            taskManager.DisplayTasks();
                            break;

                        case 3:
                            taskManager.SortTasksByDueDate();
                            Console.WriteLine("Tasks sorted by due date.");
                            break;

                        case 4:
                            taskManager.SortTasksByProject();
                            Console.WriteLine("Tasks sorted by project.");
                            break;

                        case 5:
                            MarkTaskAsDone(taskManager);
                            break;

                        case 6:
                            RemoveTask(taskManager);
                            break;

                        case 7:
                            EditTask(taskManager);
                            break;

                        case 8:
                            SaveTasksToFile(taskManager);
                            break;

                        case 9:
                            LoadTasksFromFile(taskManager);
                            break;

                        case 10:
                            DisplayHelp();
                            break;

                        case 11:
                            Console.WriteLine("Quitting the application. Goodbye!");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 11.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        // Displays the main menu options to the user
        private static void DisplayMainMenu()
        {
            Console.WriteLine("----- Task Management App -----");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Display Tasks");
            Console.WriteLine("3. Sort Tasks by Due Date");
            Console.WriteLine("4. Sort Tasks by Project");
            Console.WriteLine("5. Mark Task as Done");
            Console.WriteLine("6. Remove Task");
            Console.WriteLine("7. Edit Task");
            Console.WriteLine("8. Save Tasks to File");
            Console.WriteLine("9. Load Tasks from File");
            Console.WriteLine("10. Help");
            Console.WriteLine("11. Quit");
            Console.Write("Enter your choice (1-11): ");
        }

        // Gets the user's choice from the menu
        private static int GetUserChoice()
        {
            return int.Parse(Console.ReadLine());
        }

        // Adds a new task to the TaskManager
        private static void AddTask(TaskManager taskManager)
        {
            Console.Write("Enter task title: ");
            string title = Console.ReadLine();

            DateTime dueDate;
            while (true)
            {
                Console.Write("Enter due date (dd/MM/yyyy): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dueDate))
                    break;
                else
                    Console.WriteLine("Invalid date format. Please enter a valid date.");
            }

            Console.Write("Enter project: ");
            string project = Console.ReadLine();

            // Create a new task and add it to the TaskManager
            Task newTask = new Task(0, title, dueDate, project, false);
            taskManager.AddTask(newTask);
            Console.WriteLine("Task added successfully.");
        }

        // Marks a task as done based on the user's input
        private static void MarkTaskAsDone(TaskManager taskManager)
        {
            Console.Write("Enter task ID to mark as done: ");
            int markDoneId = int.Parse(Console.ReadLine());
            taskManager.MarkTaskAsDone(markDoneId);
        }

        // Removes a task based on the user's input
        private static void RemoveTask(TaskManager taskManager)
        {
            Console.Write("Enter task ID to remove: ");
            int removeId = int.Parse(Console.ReadLine());
            taskManager.RemoveTask(removeId);
        }

        // Edits a task based on the user's input
        private static void EditTask(TaskManager taskManager)
        {
            Console.Write("Enter task ID to edit: ");
            int editId = int.Parse(Console.ReadLine());

            Console.Write("Enter new task title: ");
            string newTitle = Console.ReadLine();

            DateTime newDueDate;
            while (true)
            {
                Console.Write("Enter new due date (dd/MM/yyyy): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out newDueDate))
                    break;
                else
                    Console.WriteLine("Invalid date format. Please enter a valid date.");
            }

            Console.Write("Enter new project: ");
            string newProject = Console.ReadLine();

            Console.Write("Is task done? (true/false): ");
            bool newIsDone = bool.Parse(Console.ReadLine());

            // Create a new task with updated details and edit the existing task
            Task updatedTask = new Task(editId, newTitle, newDueDate, newProject, newIsDone);
            taskManager.EditTask(editId, updatedTask);
        }

        // Saves tasks to a file based on the user's input
        private static void SaveTasksToFile(TaskManager taskManager)
        {
            Console.Write("Enter file path to save tasks: ");
            string saveFilePath = Console.ReadLine();
            taskManager.SaveTasksToFile(saveFilePath);
        }

        // Loads tasks from a file based on the user's input
        private static void LoadTasksFromFile(TaskManager taskManager)
        {
            Console.Write("Enter file path to load tasks: ");
            string loadFilePath = Console.ReadLine();
            taskManager.LoadTasksFromFile(loadFilePath);
        }

        // Displays a help section to the user
        private static void DisplayHelp()
        {
            Console.WriteLine("----- Help Section -----");
            Console.WriteLine("This Task Management App allows you to manage your tasks efficiently.");

            // Add some space between sections
            Console.WriteLine();

            Console.WriteLine("Basic Functions:");
            Console.WriteLine("1. Add Task - Add a new task with title, due date, and project.");
            Console.WriteLine("2. Display Tasks - View the list of tasks with color coding (Red: overdue, Yellow: within deadline, Green: completed).");
            Console.WriteLine("3. Sort Tasks by Due Date - Arrange tasks based on their due dates.");
            Console.WriteLine("4. Sort Tasks by Project - Arrange tasks based on their projects.");
            Console.WriteLine("5. Mark Task as Done - Set a task as completed.");
            Console.WriteLine("6. Remove Task - Delete a task from the list.");
            Console.WriteLine("7. Edit Task - Modify the details of an existing task.");
            Console.WriteLine("8. Save Tasks to File - Store tasks in a file for future use.");
            Console.WriteLine("9. Load Tasks from File - Retrieve tasks from a previously saved file.");
            Console.WriteLine("10. Help - Display this help section.");
            Console.WriteLine("11. Quit - Exit the application.");

            // Add some space between sections
            Console.WriteLine();

            Console.WriteLine("File Management");
            Console.WriteLine("Default file path is myTodoList.txt");
            
            // Add some space between sections
            Console.WriteLine();

            Console.WriteLine("Color Coding:");
            Console.WriteLine("Red - Tasks that have not been completed within the deadline.");
            Console.WriteLine("Magenta- Completed task outside the deadline.");
            Console.WriteLine("Yellow - Uncompleted tasks within the deadline.");
            Console.WriteLine("Green - Completed tasks within the deadline.");

            // Add some space between sections
            Console.WriteLine();


            Console.WriteLine("Symbols");
            Console.WriteLine("[X] - Completed task within the deadline");
            Console.WriteLine("[O] - Incomplete task (overdue)");
            Console.WriteLine("[U] - Uncompleted task within the deadline");
            Console.WriteLine("[A] - Completed task (after the deadline)");
           
        }

    }
}