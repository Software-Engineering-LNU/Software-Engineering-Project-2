namespace EmployeestWeb.BLL.Services;

using Interfaces;
using EmployeestWeb.DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using EmployeestWeb.BLL.Interfaces;

public class ProjectService : IProjectService
{
    private const string ProjectNotFoundMessage = "Project with ID=[%s] does not exist.";

    private readonly IProjectRepository projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        this.projectRepository = projectRepository;
    }

    public IEnumerable<Project> GetAllProjects()
    {
        return this.projectRepository.GetAllProjects();
    }

    public Project GetProjectById(long id)
    {
        var project = this.projectRepository.GetProjectById(id);

        if (project == null)
        {
            throw new ArgumentException(ProjectNotFoundMessage);
        }

        return project;
    }

    public void CreateProject(Project project)
    {
        if (project == null)
        {
            var errorMessage = $"Project cannot be null.";
            throw new ArgumentNullException(nameof(project), errorMessage);
        }

        this.projectRepository.CreateProject(project);
    }

    public void UpdateProject(long id, Project project)
    {
        var existingProject = this.projectRepository.GetProjectById(id);

        if (existingProject == null)
        {
            var errorMessage = $"Project with ID {id} does not exist.";
            throw new ArgumentException(errorMessage, nameof(id));
        }

        if (project == null)
        {
            var errorMessage = $"Project cannot be null.";
            throw new ArgumentNullException(nameof(project), errorMessage);
        }

        existingProject.Name = project.Name;
        existingProject.Description = project.Description;
        existingProject.OwnerId = project.OwnerId;

        this.projectRepository.UpdateProject(existingProject);
    }

    public void DeleteProject(long id)
    {
        var projectToDelete = this.projectRepository.GetProjectById(id);

        if (projectToDelete == null)
        {
            var errorMessage = $"Project with ID {id} does not exist.";
            throw new ArgumentException(errorMessage, nameof(id));
        }

        this.projectRepository.DeleteProject(projectToDelete);
    }
}
