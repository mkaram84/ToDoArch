using Microsoft.AspNetCore.Mvc;
using ToDoMonolithApi.Core;
using ToDoMonolithApi.Domain.Dtos;

namespace ToDoMonolithApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserCore _userCore;

        public UserController(UserCore userCore)
        {
            _userCore = userCore;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            return Ok(_userCore.GetUsers());
        }

        [HttpGet("{userId:guid}")]
        public ActionResult<UserDto> GetUser(Guid userId)
        {
            return Ok(_userCore.GetUserByGuid(userId));
        }

        [HttpPost]
        public ActionResult<bool> AddUser([FromBody] UserToAddDto userToAddDto)
        {
            var result = _userCore.AddUser(userToAddDto);
            return (result == true) ? Ok(true) : BadRequest(false);
        }

        [HttpPut]
        public ActionResult<bool> UpdateUser([FromBody] UserToUpdateDto userToUpdateDto)
        {
            var result = _userCore.UpdateUser(userToUpdateDto);
            return (result == true) ? Ok(true) : BadRequest(false);
        }

        [HttpDelete("{userId:guid}")]
        public ActionResult<bool> DeleteUser(Guid userId)
        {
            var result = _userCore.DeleteUser(userId);
            return (result == true) ? Ok(true) : BadRequest(false);
        }
    }
}
