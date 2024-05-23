using Application.Interface;
using Domain.Enums;
using Domain.Models;

namespace Application.DrivingTask.Services
{
    public class GetTask: IGetTask
    {
        private readonly IRepository _repository;

        public GetTask(IRepository repository)
        {
            _repository = repository;
        }

        async Task<List<TaskEntity>> IGetTask.GetTask()
        {
            List<TaskEntity> filterPrority = await _repository.GetTask();
            return (filterPrority.OrderByDescending(b=> b.Priority==Priority.high).ThenBy(b=> b.Priority == Priority.medium)).ToList();
        }
    }
}
