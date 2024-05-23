using Domain.Models;

namespace Application.Interface
{
    public interface IRepository
    {
        //inyeccion
        Task <List <TaskEntity>> GetTask();

        Task<TaskEntity> GetOneNewTask(string id);

        Task<TaskEntity> CreateTask(TaskEntity taskentity);

        Task UpdateAsync(TaskEntity taskentity);
    }
}
