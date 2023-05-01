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
            try
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
                else
                {
                    throw new Exception("User with this email not found!");
                }
            }
            catch
            {
                throw;
            }
        }

        public async System.Threading.Tasks.Task RemoveEmployee(int teamId, string email, int userId)
        {
            try
            {
                var user = await this.workerRepository.GetEmployeeByEmail(email);

                if (user is not null)
                {
                    TeamMember teamMember = new TeamMember
                    {
                        TeamId = teamId,
                        UserId = user.Id,
                    };

                    await this.teamRepository.RemoveEmployee(teamMember);
                }
                else
                {
                    throw new Exception("User with this email not found!");
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
