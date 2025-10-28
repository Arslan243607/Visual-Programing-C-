using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSIGNEMENT_2
{
    internal class TaskManager
    {
       //attributes
        private List<Task_Item> tasks;
        private int nextTaskId;

        
        public TaskManager()
        {
            tasks = new List<Task_Item>();
            nextTaskId = 1;  // Start IDs from 1
        }

        public void AddTask(Task_Item task)
        {
            // Assign unique ID to the task
            task.TaskId = nextTaskId;
            nextTaskId++;  // Increment for next task

            // Add task to the list
            tasks.Add(task);
        }


        public bool UpdateTask(int id, Task_Item updatedTask)
        {

            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].TaskId == id)
                {
                    // Update task properties
                    tasks[i].Title = updatedTask.Title;
                    tasks[i].Description = updatedTask.Description;
                    tasks[i].DueDate = updatedTask.DueDate;

                    return true; // Task found and updated
                }
            }

            // If we reach here, task was not found
            return false;
        }

        public bool DeleteTask(int id)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].TaskId == id)
                {
                    // Remove the task from the list
                    tasks.RemoveAt(i);
                    return true; // Task found and removed
                }
            }

            // If we reach here, task was not found
            return false;
        }
        public List<Task_Item> GetAllTasks()
        {
            // Return a copy of the list
            return new List<Task_Item>(tasks);
        }


        public bool MarkAsCompleted(int id)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].TaskId == id)
                {
                    // Mark as completed
                    tasks[i].IsCompleted = true;
                    return true; // Task found and updated
                }
            }

            // Task not found
            return false;
        }


        public List<Task_Item> GetCompletedTasks()
        {
            return tasks.Where(t => t.IsCompleted).ToList();
        }


        public List<Task_Item> GetPendingTasks()
        {
            return tasks.Where(t => !t.IsCompleted).ToList();
        }

     
        public int GetTaskCount()
        {
            return tasks.Count;
        }

    
        public Task_Item GetTaskById(int id)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].TaskId == id)
                {
                    return tasks[i]; // Task found, return it
                }
            }

            // Task not found
            return null;

        }
    }
}