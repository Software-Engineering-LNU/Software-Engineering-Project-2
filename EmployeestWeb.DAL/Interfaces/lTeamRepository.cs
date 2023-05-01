namespace EmployeestWeb.DAL.Interfaces
{
    using EmployeestWeb.DAL.Models;

    public interface ITeamRepository
    {
        System.Threading.Tasks.Task AddEmployee(TeamMember teamMember);

        System.Threading.Tasks.Task RemoveEmployee(TeamMember teamMember);
    }
}
