using Domain.Enums;
using Domain.Models;


namespace Application.DrivingTask
{
    public interface ICreateTask
    {
        Task<TaskEntity> CreateNewTask(string title, 
            State state, Priority priority, DateTime dueDate, string detail);
    }
}
