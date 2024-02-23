using System;
using System.Globalization;

// Task class represents a single task with various properties
public class Task
{
    // Properties of a task
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime DueDate { get; set; }
    public string Project { get; set; }
    public bool IsDone { get; set; }

    // Constructor to initialize a task with provided values
    public Task(int id, string title, DateTime dueDate, string project, bool isDone)
    {
        Id = id;
        Title = title;
        DueDate = dueDate;
        Project = project;
        IsDone = isDone;
    }

    // Override of ToString method to display task details
    public override string ToString()
    {
        return $"{Id}. {Title} - Due Date: {DueDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)} - Project: {Project}";
    }
}
