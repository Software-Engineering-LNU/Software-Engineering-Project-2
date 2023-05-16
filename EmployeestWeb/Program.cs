namespace EmployeestWeb;

using EmployeestWeb.BLL;
using EmployeestWeb.DAL;
using EmployeestWeb.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Configuration;
using Serilog;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add logger
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();

        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(Log.Logger);

        builder.Host.UseSerilog();

        // Add services to the container.
        builder.Services.AddBLL();
        builder.Services.AddDAL();

        builder.Services.AddDbContext<EmployeestWebDbContext>(options =>
            options.UseNpgsql(
                builder.Configuration.GetConnectionString("EmployeestDbConnString"),
                npgsqlOptions =>
                {
                    npgsqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(5),
                        errorCodesToAdd: new List<string> { "4060" });
                }));
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseSerilogRequestLogging();

        app.UseRouting();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "Home",
                pattern: "{controller=Home}/{action=Home}");
        });
        try
        {
            Log.Information("Application starting up");
            app.Run();
        }
        catch (Exception e)
        {
            Log.Fatal(e, "The application failed to start");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
