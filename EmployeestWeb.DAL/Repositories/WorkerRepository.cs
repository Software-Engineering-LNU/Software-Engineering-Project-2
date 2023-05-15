namespace EmployeestWeb.DAL.Repositories
{
    using EmployeestWeb.DAL.Data;
    using EmployeestWeb.DAL.Interfaces;
    using EmployeestWeb.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Serilog;

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
                Log.Information("Employee added");
            }
        }

        public async System.Threading.Tasks.Task RemoveEmployeeByEmail(string email)
        {
            var user = await this.db.Users.SingleAsync(x => x.Email == email);
            this.db.Users.Remove(user);
            await this.db.SaveChangesAsync();
            Log.Information("Employee removed by email");
        }

        public async System.Threading.Tasks.Task RemoveEmployeeByPhoneNumber(string phoneNumber)
        {
            var user = await this.db.Users.SingleAsync(x => x.PhoneNumber == phoneNumber);
            this.db.Users.Remove(user);
            await this.db.SaveChangesAsync();
            Log.Information("Employee removed by phone number");
        }

        public async Task<User?> GetEmployeeByEmail(string email)
        {
            try
            {
                var user = await this.db.Users.FirstOrDefaultAsync(x => x.Email == email);
                if (user is not null)
                {
                    Log.Information("Employee gotten by email");
                    return user;
                }
            }
            catch
            {
                Log.Error("Error in GetEmployeeByEmail");
                throw;
            }

            return null;
        }
    }
}
