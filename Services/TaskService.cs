using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Services;

public class TaskService
{
    private readonly AppDbContext _context;
        
    public TaskService()
    {
        _context = new AppDbContext();
        _context.Database.EnsureCreated();
    }

    public List<TaskItem> GetAllTasks() => _context.Tasks.ToList();

    public void AddTask(TaskItem task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
    }

    public void UpdateTask(TaskItem task)
    {
        _context.Tasks.Update(task);
        _context.SaveChanges();
    }

    public void DeleteTask(int id)
    {
        var task = _context.Tasks.Find();
        if (task != null)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }
}
