using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace Todo1
{
    // The main form class of the application
    public partial class Form1 : Form
    {
        // Path to the JSON file where todo items are stored
        private const string filePath = "todos.json";
        // Index of the item to be deleted
        private int deleteListItemIndex;

        public Form1()
        {
            InitializeComponent();
            // Load existing todo items from the JSON file
            LoadTodoItems();
        }

        // Loads todo items from the JSON file and displays them in the ListView
        private void LoadTodoItems()
        {
            // Temporarily disable the ItemCheck event handler to prevent unwanted updates
            todoListView.ItemCheck -= todoListView_ItemCheck;

            // Read todo items from the JSON file
            Todo[] todos = ReadData();
            if (todos != null)
            {
                foreach (var todo in todos)
                {
                    // Add each todo item to the ListView
                    todoListView.Items.Add(todo.TodoMessage, todo.Completed);
                }
            }

            // Re-enable the ItemCheck event handler
            todoListView.ItemCheck += todoListView_ItemCheck;
        }

        // Adds a new todo item to the JSON file
        void AppendTodoItem(string todoMsg)
        {
            int id = GetNextId(); // Get the next available ID
            Todo todo = new Todo
            {
                Id = id,
                TodoMessage = todoMsg,
                Completed = false
            };
            // Write the new todo item to the JSON file
            WriteData(todo);
        }

        // Reads todo items from the JSON file
        Todo[] ReadData()
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                if (string.IsNullOrEmpty(jsonString))
                {
                    return null;
                }
                // Deserialize the JSON data into an array of Todo objects
                return JsonSerializer.Deserialize<Todo[]>(jsonString);
            }
            else
            {
                return new Todo[0]; // Return an empty array if the file does not exist
            }
        }

        // Writes a todo item to the JSON file
        void WriteData(Todo todoItem)
        {
            List<Todo> todos = ReadData() != null ? ReadData().ToList() : new List<Todo>();
            todos.Add(todoItem); // Add the new todo item to the list
            string jsonString = JsonSerializer.Serialize(todos); // Serialize the list to JSON
            File.WriteAllText(filePath, jsonString); // Write JSON data to the file
        }

        // Updates the completion status of a todo item
        void UpdateTodoStatus(int index)
        {
            List<Todo> todos = ReadData().ToList();
            string todoMessage = todoListView.Items[index].ToString();

            // Find the todo item by message
            var todo = todos.FirstOrDefault(t => t.TodoMessage == todoMessage);

            if (todo != null)
            {
                // Toggle the completion status
                todo.Completed = !todo.Completed;
                string jsonString = JsonSerializer.Serialize(todos);
                File.WriteAllText(filePath, jsonString); // Save the updated list to the file
            }
        }

        // Gets the next available ID for a new todo item
        int GetNextId()
        {
            Todo[] todos = ReadData();
            if (todos != null)
            {
                // Return the highest existing ID plus one, or zero if no items exist
                return todos.Any() ? todos.Max(t => t.Id) + 1 : 0;
            }
            return 0;
        }

        // Handles the click event to add a new todo item
        private void handleClick()
        {
            string todoMsg = todoInput.Text;
            if (!string.IsNullOrWhiteSpace(todoMsg))
            {
                if (todoListView.Items.Contains(todoMsg))
                {
                    MessageBox.Show("This task already exists!", "Repeated Todo");
                    todoInput.Clear(); // Clear the input box
                }
                else
                {
                    AppendTodoItem(todoMsg); // Add the new item
                    todoListView.Items.Add(todoMsg); // Display it in the ListView
                    todoInput.Clear(); // Clear the input box
                }
            }
        }

        // Event handler for the button click to add a new todo item
        private void button1_Click(object sender, EventArgs e)
        {
            handleClick(); // Call the handleClick method
        }

        // Event handler for item check/uncheck events in the ListView
        private void todoListView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            UpdateTodoStatus(e.Index); // Update the status of the todo item
            deleteListItemIndex = e.Index; // Set the index for deletion

            // Enable or disable the Delete button based on the number of items
            DeleteButton.Enabled = todoListView.Items.Count > 0;
        }

        // Event handler for the Delete button click
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (todoListView.Items.Count > 0 && deleteListItemIndex < todoListView.Items.Count)
            {
                // Remove item from ListView
                todoListView.Items.RemoveAt(deleteListItemIndex);

                // Remove item from the underlying data
                List<Todo> todos = ReadData().ToList();
                todos.RemoveAt(deleteListItemIndex);

                // Write the updated list back to the file
                string jsonString = JsonSerializer.Serialize(todos);
                File.WriteAllText(filePath, jsonString);

                // Disable the Delete button if no items are left
                DeleteButton.Enabled = todoListView.Items.Count > 0;
            }
        }

        // Event handler for pressing Enter key in the input box
        private void todoInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the default beep sound
                handleClick(); // Call the handleClick method
            }
        }
    }
}
