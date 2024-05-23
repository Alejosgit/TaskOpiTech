using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DrivingTask
{
    public interface IGetOneTask
    {
        Task<TaskEntity> GetOneNewTask(string id);
    }
}
