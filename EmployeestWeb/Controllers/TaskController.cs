namespace EmployeestWeb.Controllers;

using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

public class TaskController : Controller
{
    private readonly ITaskService taskService;

    public TaskController(ITaskService taskService)
    {
        this.taskService = taskService;
    }

    public ActionResult Index()
    {
        var tasks = this.taskService.GetAllTasks();
        return this.View(tasks);
    }

    public ActionResult Details(long id)
    {
        var task = this.taskService.GetTaskById(id);

        if (task == null)
        {
            return this.NotFound();
        }

        return this.View(task);
    }

    public ActionResult Create()
    {
        return this.View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Task task)
    {
        if (this.ModelState.IsValid)
        {
            this.taskService.CreateTask(task);
            return this.RedirectToAction(nameof(this.Index));
        }

        var allErrors = this.ModelState.Values.SelectMany(x => x.Errors);

        return this.View(task);
    }

    public ActionResult Edit(long id)
    {
        var task = this.taskService.GetTaskById(id);

        if (task == null)
        {
            return this.NotFound();
        }

        return this.View(task);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(long id, Task task)
    {
        if (id != task.Id)
        {
            return this.NotFound();
        }

        if (this.ModelState.IsValid)
        {
            this.taskService.UpdateTask(id, task);
            return this.RedirectToAction(nameof(this.Index));
        }

        return this.View(task);
    }

    public ActionResult Delete(long id)
    {
        var task = this.taskService.GetTaskById(id);

        if (task == null)
        {
            return this.NotFound();
        }

        return this.View(task);
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(long id)
    {
        this.taskService.DeleteTask(id);
        return this.RedirectToAction(nameof(this.Index));
    }
}
