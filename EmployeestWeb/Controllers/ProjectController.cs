namespace EmployeestWeb.Controllers;

using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

public class ProjectController : Controller
{
    private readonly IProjectService projectService;

    public ProjectController(IProjectService projectService)
    {
        this.projectService = projectService;
    }

    public ActionResult Index()
    {
        Log.Information("ProjectrController Index");
        var projects = this.projectService.GetAllProjects();
        return this.View(projects);
    }

    public ActionResult Details(long id)
    {
        Log.Information("ProjectController Details {@id}", id);
        var project = this.projectService.GetProjectById(id);

        if (project == null)
        {
            return this.NotFound();
        }

        return this.View(project);
    }

    public ActionResult Create()
    {
        Log.Information("ProjectController Create");
        return this.View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Project project)
    {
        Log.Information("ProjectController Create {@project}", project);
        if (this.ModelState.IsValid)
        {
            this.projectService.CreateProject(project);
            return this.RedirectToAction(nameof(this.Index));
        }

        return this.View(project);
    }

    public ActionResult Edit(long id)
    {
        Log.Information("ProjectController Edit {@id}", id);
        var project = this.projectService.GetProjectById(id);

        if (project == null)
        {
            return this.NotFound();
        }

        return this.View(project);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(long id, Project project)
    {
        Log.Information("ProjectController Edit {@id} {@project}", id, project);
        if (id != project.Id)
        {
            return this.NotFound();
        }

        if (this.ModelState.IsValid)
        {
            this.projectService.UpdateProject(id, project);
            return this.RedirectToAction(nameof(this.Index));
        }

        return this.View(project);
    }

    public ActionResult Delete(long id)
    {
        Log.Information("ProjectController Delete {@id}", id);
        var project = this.projectService.GetProjectById(id);

        if (project == null)
        {
            return this.NotFound();
        }

        return this.View(project);
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(long id)
    {
        Log.Information("ProjectController DeleteConfirmed {@id}", id);
        this.projectService.DeleteProject(id);
        return this.RedirectToAction(nameof(this.Index));
    }
}
