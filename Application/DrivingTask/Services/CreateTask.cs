using Application.Interface;
using Domain.Enums;
using Domain.Models;

namespace Application.DrivingTask.Services
{
    public class CreateTask: ICreateTask
    {
        private readonly IRepository _repository;

        public CreateTask(IRepository repository)
        {
            _repository = repository;
        }


        public async Task<TaskEntity> CreateNewTask(string title, State state, Priority priority, DateTime dueDate, string detail)
        {
            TaskEntity taskentity = new TaskEntity()
            {
                UserId = "9ce0d181-f99e-48dd-ae1d-dbc19093a0f1",
                Title = title,
                State = state,
                Priority = priority,
                DueDate = dueDate,
                Detail = detail,
            };
            taskentity.DueDate = DateTime.Now.AddDays(1);
            taskentity.Id = Guid.NewGuid().ToString();
            await _repository.CreateTask(taskentity);

            return taskentity;
        }
    }
}
