namespace EmployeestWeb.BLL.Services
{
    using EmployeestWeb.BLL.Interfaces;
    using EmployeestWeb.DAL.Interfaces;
    using EmployeestWeb.DAL.Models;

    public class TeamService : ITeamService
    {
        private readonly ITeamRepository teamRepository;
        private readonly IWorkerRepository workerRepository;

        public TeamService(ITeamRepository teamRepository, IWorkerRepository workerRepository)
        {
            this.teamRepository = teamRepository;
            this.workerRepository = workerRepository;
        }

        public async System.Threading.Tasks.Task AddEmployee(int teamId, string email)
        {
            var user = await this.workerRepository.GetEmployeeByEmail(email);

            if (user is not null)
            {
                TeamMember teamMember = new TeamMember
                {
                    TeamId = teamId,
                    UserId = user.Id,
                };

                await this.teamRepository.AddEmployee(teamMember);
            }
        }
    }
}
