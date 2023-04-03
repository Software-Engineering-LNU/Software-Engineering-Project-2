namespace EmployeestWeb.DAL.Repositories.Implementation
{
    using EmployeestWeb.DAL.Data;
    using EmployeestWeb.DAL.Models;
    using EmployeestWeb.DAL.Repositories.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public sealed class WorkerRepository : IWorkerRepository
    {
        private readonly EmployeestWebDbContext db;

        public WorkerRepository(EmployeestWebDbContext db)
        {
            this.db = db;
        }

        public async System.Threading.Tasks.Task AddEmployee(User user)
        {
            if (user is not null)
            {
                await this.db.Users.AddAsync(user);
                await this.db.SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task RemoveEmployeeByEmail(string email)
        {
            var user = await this.db.Users.SingleAsync(x => x.Email == email);
            this.db.Users.Remove(user);
            await this.db.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task RemoveEmployeeByPhoneNumber(string phoneNumber)
        {
            var user = await this.db.Users.SingleAsync(x => x.PhoneNumber == phoneNumber);
            this.db.Users.Remove(user);
            await this.db.SaveChangesAsync();
        }
    }
}
