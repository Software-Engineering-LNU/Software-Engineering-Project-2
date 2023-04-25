namespace EmployeestWeb.BLL.Services;

using Interfaces;
using EmployeestWeb.DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;

public class TaskService : ITaskService
{
    private const string TaskNotFoundMessage = "Task with ID=[%s] does not exist.";

    private readonly ITaskRepository taskRepository;
    private readonly IUserRepository userRepository;

    public TaskService(ITaskRepository taskRepository, IUserRepository userRepository)
    {
        this.taskRepository = taskRepository;
        this.userRepository = userRepository;
    }

    public IEnumerable<Task> GetAllTasks()
    {
        return this.taskRepository.GetAllTasks();
    }

    public Task GetTaskById(long id)
    {
        var task = this.taskRepository.GetTaskById(id);

        if (task == null)
        {
            throw new ArgumentException(TaskNotFoundMessage);
        }

        return task;
    }

    public IEnumerable<Task> GetTasksByUserId(long userId)
    {
        IEnumerable<Task>? tasks = this.userRepository.GetUser(userId)?.Tasks;

        if (tasks == null)
        {
            throw new ArgumentException(TaskNotFoundMessage);
        }

        return tasks;
    }

    public void CreateTask(Task task)
    {
        if (task == null)
        {
            var errorMessage = $"Task cannot be null.";
            throw new ArgumentNullException(nameof(task), errorMessage);
        }

        this.taskRepository.CreateTask(task);
    }

    public void UpdateTask(long id, Task task)
    {
        var existingTask = this.taskRepository.GetTaskById(id);

        if (existingTask == null)
        {
            var errorMessage = $"Task with ID {id} does not exist.";
            throw new ArgumentException(errorMessage, nameof(id));
        }

        if (task == null)
        {
            var errorMessage = $"Task cannot be null.";
            throw new ArgumentNullException(nameof(task), errorMessage);
        }

        existingTask.Name = task.Name;
        existingTask.Description = task.Description;
        existingTask.Status = task.Status;
        existingTask.StoryPoints = task.StoryPoints;
        existingTask.UserId = task.UserId;
        existingTask.User = task.User;
        existingTask.Team = task.Team;
        existingTask.TeamId = task.TeamId;

        this.taskRepository.UpdateTask(existingTask);
    }

    public void DeleteTask(long id)
    {
        var taskToDelete = this.taskRepository.GetTaskById(id);

        if (taskToDelete == null)
        {
            var errorMessage = $"Task with ID {id} does not exist.";
            throw new ArgumentException(errorMessage, nameof(id));
        }

        this.taskRepository.DeleteTask(taskToDelete);
    }
}
