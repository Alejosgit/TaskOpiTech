using Application.Interface;
using Domain.Models;
using Infrastructure.TaskContens;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class TaskRepository : IRepository
    {
        private readonly TaskContext _context;

        public TaskRepository(TaskContext context)
        {
            _context = context;
        }

        public async Task<TaskEntity> CreateTask(TaskEntity taskentity)
        {
            _context.Add(taskentity);
            await _context.SaveChangesAsync();
            return taskentity;
        }

        public async Task<TaskEntity> GetOneNewTask(string id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<List<TaskEntity>> GetTask()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task UpdateAsync(TaskEntity taskentity)
        {
            _context.Update(taskentity);
            await _context.SaveChangesAsync();
        }
    }
}
