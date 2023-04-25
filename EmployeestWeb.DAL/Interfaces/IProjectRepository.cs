namespace EmployeestWeb.DAL.Interfaces;

using Models;

public interface IProjectRepository
{
    IEnumerable<Project> GetAllProjects();

    Project? GetProjectById(long id);

    void CreateProject(Project project);

    void UpdateProject(Project project);

    void DeleteProject(Project project);
}