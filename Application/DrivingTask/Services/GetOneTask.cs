using Application.Interface;
using Domain.Models;

namespace Application.DrivingTask.Services
{
   
    public class GetOneTask: IGetOneTask
    {
        private readonly IRepository _repisitory;

        public GetOneTask(IRepository repisitory)
        {
            _repisitory = repisitory;
        }

        public async Task<TaskEntity> GetOneNewTask(string id)
        {
                return await _repisitory.GetOneNewTask(id);   
        }
    }
}
