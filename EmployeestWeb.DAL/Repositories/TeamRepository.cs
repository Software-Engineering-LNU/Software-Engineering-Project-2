namespace EmployeestWeb.DAL.Repositories
{
    using EmployeestWeb.DAL.Data;
    using EmployeestWeb.DAL.Interfaces;
    using EmployeestWeb.DAL.Models;

    public class TeamRepository : ITeamRepository
    {
        private readonly EmployeestWebDbContext db;

        public TeamRepository(EmployeestWebDbContext db)
        {
            this.db = db;
        }

        public async System.Threading.Tasks.Task AddEmployee(TeamMember teamMember)
        {
            if (teamMember is not null)
            {
                await this.db.TeamMembers.AddAsync(teamMember);
                await this.db.SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task RemoveEmployee(TeamMember teamMember)
        {
            if (teamMember is not null)
            {
                this.db.TeamMembers.Remove(teamMember);
                await this.db.SaveChangesAsync();
            }
        }
    }
}
