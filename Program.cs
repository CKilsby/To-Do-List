using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static string taskFilePath = "tasks.txt"; // File to store tasks

    static void Main()
    {
        List<string> toDoList = LoadTasks();

        while (true)
        {
            Console.WriteLine("To-Do List Menu:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Mark Task as Complete");
            Console.WriteLine("4. Save and Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter a task: ");
                        string task = Console.ReadLine();
                        toDoList.Add(task);
                        Console.WriteLine("Task added to the list.");
                        break;
                    case 2:
                        Console.WriteLine("To-Do List:");
                        for (int i = 0; i < toDoList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {toDoList[i]}");
                        }
                        break;
                    case 3:
                        Console.Write("Enter the task number to mark as complete: ");
                        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber >= 1 && taskNumber <= toDoList.Count)
                        {
                            Console.WriteLine($"Marking '{toDoList[taskNumber - 1]}' as complete.");
                            toDoList.RemoveAt(taskNumber - 1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid task number.");
                        }
                        break;
                    case 4:
                        SaveTasks(toDoList);
                        Console.WriteLine("Tasks saved. Exiting the To-Do List application.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            Console.WriteLine();
        }
    }

    static List<string> LoadTasks()
    {
        List<string> tasks = new List<string>();
        if (File.Exists(taskFilePath))
        {
            string[] lines = File.ReadAllLines(taskFilePath);
            tasks.AddRange(lines);
        }
        return tasks;
    }

    static void SaveTasks(List<string> tasks)
    {
        File.WriteAllLines(taskFilePath, tasks);
    }
}
