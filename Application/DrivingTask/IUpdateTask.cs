using Domain.Enums;

namespace Application.DrivingTask
{
    public interface IUpdateTask
    {
        Task UpdateAsync(string id, State state);
    }
}
