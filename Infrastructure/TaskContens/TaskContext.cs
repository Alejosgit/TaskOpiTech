using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.TaskContens
{
    public class TaskContext:DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<TaskEntity> Tasks { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskEntity>(entity =>
            {
                entity.HasKey(task => task.Id);
                entity.Property(task => task.Title).IsRequired();
                entity.Property(task => task.State).IsRequired();
                entity.Property(task => task.Detail).IsRequired();
                entity.Property(task => task.State).IsRequired();
                entity.Property(task => task.Priority).IsRequired();
                entity.Property(task => task.DueDate).IsRequired();

            });

            modelBuilder.Entity<User>().HasData(
                new User
                { 
                    Id = Guid.NewGuid().ToString(),
                    Name = "Alejandro Hurtado",
                    Password = "123456",
                    Email = "alejo@gmail.com",
                    Preference =  preference.OneDay
                }              
                );
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(user => user.Id);
                entity.Property(user => user.Name).IsRequired();
                entity.Property(user => user.Email).IsRequired();
                entity.Property(user => user.Password).IsRequired();
                entity.Property(user => user.Preference).IsRequired();
            });

            modelBuilder.Entity<TaskEntity>().HasOne(task => task.Users);
        }

    }
}
