using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TaskService _taskService;
        private List<TaskItem> _tasks;

        public MainWindow()
        {
            InitializeComponent();
            _taskService = new TaskService();
            LoadTasks();
        }

        private void LoadTasks()
        {
            _tasks = _taskService.GetAllTasks();
            taskListView.ItemsSource = _tasks;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            var newTask = new TaskItem
            {
                Title = txtTitle.Text,
                CreatedDate = DateTime.Now,
                IsCompleted = false,
                Priority = TaskPriority.Medium
            };

            _taskService.AddTask(newTask);
            LoadTasks();
            txtTitle.Text = "";
        }

        private void DeleteSelected_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = taskListView.SelectedItems.Cast<TaskItem>().ToList();
            foreach (var task in selectedItems)
            {
                _taskService.DeleteTask(task.Id);
            }
            LoadTasks();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (((CheckBox)sender).DataContext is TaskItem task)
            {
                task.IsCompleted = true;
                _taskService.UpdateTask(task);
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (((CheckBox)sender).DataContext is TaskItem task)
            {
                task.IsCompleted = false;
                _taskService.UpdateTask(task);
            }
        }

    }
}