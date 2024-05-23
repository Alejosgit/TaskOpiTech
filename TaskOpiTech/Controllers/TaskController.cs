using Application.DrivingTask;
using Application.Interface;
using Application.SendTaskEmail;
using Domain.Enums;
using Domain.Models;
using Infrastructure.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskOpiTech.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ICreateTask _createtask;
        private readonly IGetOneTask _getonetask;
        private readonly IGetTask _gettask;
        private readonly IUpdateTask _updatetask;
        private readonly IEmailSend _emailsend;

        public TaskController(ICreateTask createtask, IGetOneTask getonetask, IGetTask gettask, IUpdateTask updatetask)
        {
            _createtask = createtask;
            _getonetask = getonetask;
            _gettask = gettask;
            _updatetask = updatetask;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var LisdtTask = await _gettask.GetTask();
                return Ok(LisdtTask);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(String id)
        {
            try {
                var OneTask = await _getonetask.GetOneNewTask(id);
                return Ok(OneTask);

            } catch (Exception ex) {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public async Task<TaskEntity>? CreateTask(CreateTaskModels model)
        {
            return await _createtask.CreateNewTask(model.Title, model.State, model.Priority,
                model.DueDate, model.Detail);
        }

        [HttpPut]
        public async Task UpdateTask(UpdateTaskModels model)
        {
             await _updatetask.UpdateAsync(model.Id, model.State);
        }

        [HttpPost]
        [Route("/emailSend")]
        public async Task EmailSend(SendEmailModel sendemail)
        {
            await _emailsend.TaskEmailSend(sendemail.EmailReceiver, sendemail.BodyMenssage);
        }
        
    }

    public class CreateTaskModels
    {
        public string Title { get; set; }
        public State State { get; set; }
        public Priority Priority { get; set; }
        public DateTime DueDate { get; set; }
        public string Detail { get; set; }
    }

    public class UpdateTaskModels
    {
        public string Id { get; set; }
        public State State { get; set; }
    }

}
