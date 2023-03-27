namespace EmployeestWeb
{
    using EmployeestWeb.BLL;
    using EmployeestWeb.DAL;
    using EmployeestWeb.DAL.Data;
    using Microsoft.EntityFrameworkCore;

    public class Program
    {
        protected Program()
        {
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddBLL();
            builder.Services.AddDAL();

            builder.Services.AddDbContext<EmployeestWebDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("EmployeestDbConnString"), npgsqlOptions =>
                {
                    npgsqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(5),
                        errorCodesToAdd: new List<string> { "4060" });
                }));

            builder.Services.AddControllersWithViews();

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<EmployeestWebDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("EmployeestDbConnString"), npgsqlOptions =>
                {
                    npgsqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(5),
                        errorCodesToAdd: new List<string> { "4060" });
                }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Authorization}/{action=SignIn}/{id?}");

            app.Run();
        }
    }
}
