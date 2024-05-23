using Application.Interface;
using Domain.Enums;
using Domain.Models;

namespace Application.DrivingTask.Services
{
    public class UpdateTask: IUpdateTask
    {
        private readonly IRepository _repository;

        public UpdateTask(IRepository repository)
        {
            _repository = repository;
        }

        public async Task UpdateAsync(string id, State state)
        {
            TaskEntity oldTask = await _repository.GetOneNewTask(id);
            if (oldTask != null)
            {
                oldTask.State = state;
                await _repository.UpdateAsync(oldTask);
            }

        }
    }
}
