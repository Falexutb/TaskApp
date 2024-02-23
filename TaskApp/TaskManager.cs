using System.Globalization;

// TaskManager class manages a list of tasks and provides various functionalities
public class TaskManager
{
    private List<Task> tasks;

    // Constructor initializes an empty list of tasks
    public TaskManager()
    {
        tasks = new List<Task>();
    }

    // Adds a task to the list, assigns an ID, and increments the count
    public void AddTask(Task task)
    {
        task.Id = tasks.Count + 1;
        tasks.Add(task);
    }

    // Displays the list of tasks with color-coded status
    public void DisplayTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found. Please input tasks.");
            return;
        }

        Console.WriteLine("Task List:");

        foreach (var task in tasks)
        {
            ConsoleColor color = ConsoleColor.White;
            string status = GetTaskStatus(task);

            if (!task.IsDone && task.DueDate < DateTime.Now)
            {
                color = ConsoleColor.Red; // overdue tasks
            }
            else if (!task.IsDone)
            {
                color = ConsoleColor.Yellow; // tasks within the deadline
            }
            else if (task.DueDate >= DateTime.Now)
            {
                color = ConsoleColor.Green; // completed tasks within the deadline
            }
            else
            {
                color = ConsoleColor.Magenta; // completed tasks after the deadline
            }

            Console.ForegroundColor = color;
            Console.WriteLine($"{task} - {status}");
            Console.ResetColor();
        }
    }

    // Private method to get the status of a task
    private string GetTaskStatus(Task task)
    {
        if (task.IsDone && task.DueDate >= DateTime.Now)
        {
            return "[X] Completed task within the deadline";
        }
        else if (!task.IsDone && task.DueDate < DateTime.Now)
        {
            return "[O] Incomplete task (overdue)";
        }
        else if (!task.IsDone)
        {
            return "[U] Uncompleted task within the deadline";
        }
        else
        {
            return "[A] Completed task (after the deadline)";
        }
    }

    // Sorts tasks based on their due dates
    public void SortTasksByDueDate()
    {
        tasks.Sort((task1, task2) => task1.DueDate.CompareTo(task2.DueDate));
    }

    // Sorts tasks based on their project names
    public void SortTasksByProject()
    {
        tasks.Sort((task1, task2) => task1.Project.CompareTo(task2.Project));
    }

    // Marks a task as done based on the provided task ID
    public void MarkTaskAsDone(int taskId)
    {
        Task task = FindTaskById(taskId);

        if (task != null)
        {
            task.IsDone = true;
            Console.WriteLine("Task marked as done.");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }

    // Removes a task based on the provided task ID
    public void RemoveTask(int taskId)
    {
        Task task = FindTaskById(taskId);

        if (task != null)
        {
            tasks.Remove(task);
            Console.WriteLine("Task removed.");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }

    // Edits a task based on the provided task ID and updated task details
    public void EditTask(int taskId, Task updatedTask)
    {
        Task task = FindTaskById(taskId);

        if (task != null)
        {
            task.Title = updatedTask.Title;
            task.DueDate = updatedTask.DueDate;
            task.Project = updatedTask.Project;
            task.IsDone = updatedTask.IsDone;
            Console.WriteLine("Task edited successfully.");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }

    // Saves the list of tasks to a file specified by the filePath parameter
    public void SaveTasksToFile(string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var task in tasks)
                {
                    writer.WriteLine($"{task.Id},{task.Title},{task.DueDate},{task.Project},{task.IsDone}");
                }
                Console.WriteLine("Tasks saved to file successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving tasks to file: {ex.Message}");
        }
    }

    // Loads tasks from a file specified by the filePath parameter
    public void LoadTasksFromFile(string filePath)
    {
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                tasks.Clear();
                int id = 1;

                while (!reader.EndOfStream)
                {
                    string[] taskData = reader.ReadLine().Split(',');

                    // Try parsing the date with multiple format options
                    DateTime dueDate;
                    string[] dateFormats = { "dd/MM/yyyy HH:mm:ss", "MM/dd/yyyy HH:mm:ss", /* Add more formats if needed */ };

                    if (DateTime.TryParseExact(taskData[2], dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDate))
                    {
                        string title = taskData[1];
                        string project = taskData[3];
                        bool isDone = bool.Parse(taskData[4]);

                        Task loadedTask = new Task(id++, title, dueDate, project, isDone);
                        tasks.Add(loadedTask);
                    }
                    else
                    {
                        Console.WriteLine($"Error parsing date: {taskData[2]}. Skipping the corresponding task.");
                    }
                }

                Console.WriteLine("Tasks loaded from file successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading tasks from file: {ex.Message}");
        }
    }

    // Private method to find a task by its ID in the list
    private Task FindTaskById(int taskId)
    {
        return tasks.Find(t => t.Id == taskId);
    }

    // ... (Other methods, if any)
}