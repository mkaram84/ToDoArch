using Microsoft.AspNetCore.Mvc;
using ToDoMonolithApi.Core;
using ToDoMonolithApi.Domain.Dtos;

namespace ToDoMonolithApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskCore _taskCore;

        public TaskController(TaskCore taskCore)
        {
            _taskCore = taskCore;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskDto>> GetTasksByUserId([FromBody] Guid userId)
        {
            return Ok(_taskCore.GetTasksByUserId(userId));
        }

        [HttpGet("{taskId:guid}")]
        public ActionResult<TaskDto> GetTaskById(Guid taskId)
        {
            return Ok(_taskCore.GetTaskById(taskId));
        }

        [HttpPost]
        public ActionResult<bool> AddTask([FromBody] TaskToAddDto taskToAddDto)
        {
            var result = _taskCore.AddTask(taskToAddDto);
            return (result == true) ? Ok(true) : BadRequest(false);
        }

        [HttpPut]
        public ActionResult<bool> UpdateTask([FromBody] TaskToUpdateDto taskToUpdateDto)
        {
            var result = _taskCore.UpdateTask(taskToUpdateDto);
            return (result == true) ? Ok(true) : BadRequest(false);
        }

        [HttpDelete("{taskId:guid}")]
        public ActionResult<bool> DeleteTask(Guid taskId)
        {
            var result = _taskCore.DeleteTask(taskId);
            return (result == true) ? Ok(true) : BadRequest(false);
        }
    }
}
