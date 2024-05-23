using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Models
{
    public class TaskEntity
    {
        [Key]
        public string Id { get; set; }

        public string UserId { get; set; }
        public string Title { get; set; }

        public State State { get; set; }

        public Priority Priority { get; set; }

        public DateTime DueDate { get; set; }

        public string Detail { get; set; }

        public User? Users { get; set; }
    }
}
