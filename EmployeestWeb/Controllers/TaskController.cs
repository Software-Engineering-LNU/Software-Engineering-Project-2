namespace EmployeestWeb.Controllers;

using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

public class TaskController : Controller
{
    private readonly ITaskService taskService;

    public TaskController(ITaskService taskService)
    {
        this.taskService = taskService;
    }

    public ActionResult Index()
    {
        Log.Information("TasksController Index");
        var tasks = this.taskService.GetAllTasks();
        return this.View(tasks);
    }

    public ActionResult Details(long id)
    {
        Log.Information("TasksController Details {@id}", id);
        var task = this.taskService.GetTaskById(id);

        if (task == null)
        {
            Log.Error("Task with specified Id not found: " + Convert.ToString(id));
            return this.NotFound();
        }

        return this.View(task);
    }

    public ActionResult Create()
    {
        Log.Information("TasksController Create");
        return this.View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Task task)
    {
        Log.Information("TasksController Create {@task}", task);
        if (this.ModelState.IsValid)
        {
            this.taskService.CreateTask(task);
            return this.RedirectToAction(nameof(this.Index));
        }

        Log.Information("Task with specified Id created: " + Convert.ToString(task.Id));
        return this.View(task);
    }

    public ActionResult Edit(long id)
    {
        Log.Information("TasksController Edit {@id}", id);
        var task = this.taskService.GetTaskById(id);

        if (task == null)
        {
            Log.Error("Task with specified Id not found: " + Convert.ToString(id));
            return this.NotFound();
        }

        return this.View(task);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(long id, Task task)
    {
        Log.Information("TasksController Edit {@id} {@task}", id, task);
        if (id != task.Id)
        {
            Log.Error("Task with specified Id not found: " + Convert.ToString(id));
            return this.NotFound();
        }

        if (this.ModelState.IsValid)
        {
            this.taskService.UpdateTask(id, task);
            return this.RedirectToAction(nameof(this.Index));
        }

        Log.Information("Task with specified Id edited: " + Convert.ToString(id));
        return this.View(task);
    }

    public ActionResult Delete(long id)
    {
        Log.Information("TasksController Delete {@id}", id);
        var task = this.taskService.GetTaskById(id);

        if (task == null)
        {
            Log.Error("Task with specified Id not found: " + Convert.ToString(id));
            return this.NotFound();
        }

        return this.View(task);
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(long id)
    {
        Log.Information("TasksController DeleteConfirmed {@id}", id);
        this.taskService.DeleteTask(id);
        Log.Information("Task with specified Id deleted: " + Convert.ToString(id));
        return this.RedirectToAction(nameof(this.Index));
    }
}
