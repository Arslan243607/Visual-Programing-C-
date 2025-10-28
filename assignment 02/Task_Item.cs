using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSIGNEMENT_2
{
    internal class Task_Item
    {
        // Private fields 
        private int taskId;
        private string title;
        private string description;
        private DateTime dueDate;
        private bool isCompleted;

        /// Gets or sets the unique Task ID
        public int TaskId
        {
            get { return taskId; }
            set { taskId = value; }
        }

        /// Gets or sets the Title of the task
        public string Title
        {
            get { return title; }
            set { title = value; }
        }


        /// Gets or sets the Description of the task
    
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// Gets or sets the Due Date of the tassks
        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }


        public bool IsCompleted
        {
            get { return isCompleted; }  // Returns the FIELD 
            set { isCompleted = value; }  // Sets the FIELD 
        }

        // Constructors

        public Task_Item()
        {
            taskId = 0;
            title = string.Empty;
            description = string.Empty;
            dueDate = DateTime.Now;
            isCompleted = false;
        }

        public Task_Item(int id, string taskTitle, string taskDescription, DateTime taskDueDate)
        {
            taskId = id;
            title = taskTitle;
            description = taskDescription;
            dueDate = taskDueDate;
            isCompleted = false;
        }



    }
}
