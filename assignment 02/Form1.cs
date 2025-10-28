using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ASSIGNEMENT_2
{
    public partial class Form1 : Form
    {
        private TaskManager taskManager;
        private int selectedTaskId = -1;

        public Form1()
        {
            InitializeComponent();

            // Initialize Task Manager
            taskManager = new TaskManager();

            // Setup ComboBox (filter)
            comboBox1.Items.Clear();
            comboBox1.Items.Add("All tasks");
            comboBox1.Items.Add("Pending");
            comboBox1.Items.Add("Completed");
            comboBox1.SelectedIndex = 0;

            dateTimePicker1.Value = DateTime.Now;

            RefreshTaskList();
        }

        //  LISTBOX1 — Select Task
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //  COMBOBOX1 — Filter Tasks
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //  Refresh ListBox1 according to ComboBox filter
        private void RefreshTaskList()
        {
            listBox1.Items.Clear();

            string filter = comboBox1.SelectedItem?.ToString() ?? "All tasks";
            List<Task_Item> filteredTasks;

            if (filter == "Pending")
            {
                filteredTasks = taskManager.GetPendingTasks();
            }
            else if (filter == "Completed")
            {
                filteredTasks = taskManager.GetCompletedTasks();
            }
            else
            {
                filteredTasks = taskManager.GetAllTasks();
            }

            // Display task IDs only
            foreach (var task in filteredTasks)
            {
                listBox1.Items.Add(task.TaskId);
            }
        }

        //  Clear input fields
        private void ClearFields()
        {
            textBox1.Clear();
            richTextBox1.Clear();
            dateTimePicker1.Value = DateTime.Now;
            listBox1.ClearSelected();
            selectedTaskId = -1;
        }

        // S BUTTON 1 — ADD TASK
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        //  BUTTON 2 — UPDATE TASK
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        //  BUTTON 3 — DELETE TASK
        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        //  BUTTON 4 — MARK AS COMPLETED
        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string title = textBox1.Text.Trim();
            string description = richTextBox1.Text.Trim();
            DateTime dueDate = dateTimePicker1.Value;

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter a title!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Task_Item newTask = new Task_Item
            {
                Title = title,
                Description = description,
                DueDate = dueDate,
                IsCompleted = false
            };

            taskManager.AddTask(newTask);
            MessageBox.Show("Task added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearFields();
            RefreshTaskList();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (selectedTaskId == -1)
            {
                MessageBox.Show("Please select a task from the list to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string title = textBox1.Text.Trim();
            string description = richTextBox1.Text.Trim();
            DateTime dueDate = dateTimePicker1.Value;

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter a title.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Task_Item updatedTask = new Task_Item
            {
                Title = title,
                Description = description,
                DueDate = dueDate
            };

            bool success = taskManager.UpdateTask(selectedTaskId, updatedTask);

            if (success)
            {
                MessageBox.Show("Task updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                selectedTaskId = -1;
                RefreshTaskList();
            }
            else
            {
                MessageBox.Show("Task not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            if (selectedTaskId == -1)
            {
                MessageBox.Show("Please select a task to mark as completed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = taskManager.MarkAsCompleted(selectedTaskId);

            if (success)
            {
                MessageBox.Show("Task marked as completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                selectedTaskId = -1;
                RefreshTaskList();
            }
            else
            {
                MessageBox.Show("Task not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (selectedTaskId == -1)
            {
                MessageBox.Show("Please select a task to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete Task ID {selectedTaskId}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                bool success = taskManager.DeleteTask(selectedTaskId);

                if (success)
                {
                    MessageBox.Show("Task deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    selectedTaskId = -1;
                    RefreshTaskList();
                }
                else
                {
                    MessageBox.Show("Task not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;

            selectedTaskId = (int)listBox1.SelectedItem;
            Task_Item selectedTask = taskManager.GetTaskById(selectedTaskId);

            if (selectedTask != null)
            {
                textBox1.Text = selectedTask.Title;
                richTextBox1.Text = selectedTask.Description;
                dateTimePicker1.Value = selectedTask.DueDate;
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            RefreshTaskList();
        }
    }
}
