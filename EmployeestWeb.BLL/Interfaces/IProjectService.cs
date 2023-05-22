namespace EmployeestWeb.BLL.Interfaces;

using EmployeestWeb.DAL.Models;

public interface IProjectService
{
    IEnumerable<Project> GetAllProjects();

    Project? GetProjectById(long id);

    void CreateProject(Project project);

    void UpdateProject(long id, Project project);

    void DeleteProject(long id);
}