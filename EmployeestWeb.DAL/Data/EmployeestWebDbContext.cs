namespace EmployeestWeb.DAL.Data
{
    using EmployeestWeb.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Task = EmployeestWeb.DAL.Models.Task;

    public partial class EmployeestWebDbContext : DbContext
    {
        public EmployeestWebDbContext()
        {
        }

        public EmployeestWebDbContext(DbContextOptions<EmployeestWebDbContext> options)
            : base(options)
        {
        }

        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        IConfigurationRoot configuration = builder.Build();

        string connectionString = configuration.GetConnectionString("DefaultConnection");

        public virtual DbSet<Event> Events { get; set; } = null!;

        public virtual DbSet<EventMember> EventMembers { get; set; } = null!;

        public virtual DbSet<Permission> Permissions { get; set; } = null!;

        public virtual DbSet<Position> Positions { get; set; } = null!;

        public virtual DbSet<PositionPermission> PositionPermissions { get; set; } = null!;

        public virtual DbSet<Project> Projects { get; set; } = null!;

        public virtual DbSet<ProjectMember> ProjectMembers { get; set; } = null!;

        public virtual DbSet<Models.Task> Tasks { get; set; } = null!;

        public virtual DbSet<Team> Teams { get; set; } = null!;

        public virtual DbSet<TeamMember> TeamMembers { get; set; } = null!;

        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("events");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.EndTime).HasColumnName("end_time");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.StartTime).HasColumnName("start_time");
            });

            modelBuilder.Entity<EventMember>(entity =>
            {
                entity.ToTable("event_members");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventMembers)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("event_members_reference_events_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventMembers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("event_members_reference_users_fk");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("permissions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("positions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PositionPermission>(entity =>
            {
                entity.ToTable("position_permissions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.PositionPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("position_permissions_reference_permissions_fk");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.PositionPermissions)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("position_permissions_reference_positions_fk");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("projects");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("projects_reference_users_fk");
            });

            modelBuilder.Entity<ProjectMember>(entity =>
            {
                entity.ToTable("project_members");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.Salary)
                    .HasPrecision(8, 2)
                    .HasColumnName("salary");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.ProjectMembers)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("project_members_reference_positions_fk");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectMembers)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("project_members_reference_projects_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProjectMembers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("project_members_reference_users_fk");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("tasks");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Estimation).HasColumnName("estimation");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Status)
                    .HasColumnType("character varying")
                    .HasColumnName("status");

                entity.Property(e => e.StoryPoints).HasColumnName("story_points");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tasks_reference_teams_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tasks_reference_users_fk");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("teams");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("projects_reference_projects_fk");
            });

            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.ToTable("team_members");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamMembers)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("team_members_reference_teams_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TeamMembers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("team_members_reference_users_fk");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "users_email_uq")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "users_phone_number_uq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .HasColumnType("character varying")
                    .HasColumnName("full_name");

                entity.Property(e => e.IsBusinessOwner).HasColumnName("is_business_owner");

                entity.Property(e => e.Password)
                    .HasColumnType("character varying")
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("character varying")
                    .HasColumnName("phone_number");
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
