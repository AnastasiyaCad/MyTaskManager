using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models;

public enum TaskPriority
{
    Low,
    Medium,
    High,
}

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    //public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    //public DateTime? DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public TaskPriority Priority { get; set; }
    //public string Category {  get; set; }
}
