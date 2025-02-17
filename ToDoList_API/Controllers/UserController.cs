using Microsoft.AspNetCore.Mvc;
using ToDoList_BusinessLayer;
using ToDoList_DataAccessLayer.DTO.User;

namespace ToDoList_API.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly clsUser _user;

        public UserController(clsUser user)
        {
            _user = user;
        }

        [HttpGet("{id}", Name = "GetUserByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDTO> GetUserByID(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not Accepted ID {id}");
            }

            clsUser? user = _user.Find(id);

            if (user == null)
            {
                return NotFound($"User with ID = {id} Not Found!");
            }

            return Ok(user.UserDTO);
        }

        [HttpPost("Signup", Name = "AddUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<UserDTO> AddUser(UserDTO userDTO)
        {
            // Plan to check the username or the password if they already used

            if (userDTO == null || string.IsNullOrEmpty(userDTO.UserName) || string.IsNullOrEmpty(userDTO.Password) ||
                string.IsNullOrEmpty(userDTO.Email))
            {
                return BadRequest("Invalid User Data");
            }

            _user.Initialize(userDTO);

            if (!_user.Save())
            {
                return Conflict("Username or Email already exists");
            }

            userDTO.UserID = _user.UserID;
            return CreatedAtRoute("GetUserByID", new { id = userDTO.UserID }, userDTO);
        }

        [HttpPost("Login", Name = "Login")]
        public ActionResult<UserDTO> Login(UserLoginDTO userLoginDTO)
        {
            if (string.IsNullOrEmpty(userLoginDTO.UserName) || string.IsNullOrEmpty(userLoginDTO.Password))
            {
                return BadRequest("Invalid User Data");
            }

            int userID = _user.Login(userLoginDTO);

            if (userID == -1)
            {
                return NotFound("Username/Password not found!");
            }

            clsUser? user = _user.Find(userID);
            //if (user != null)
            //{
            //    return Ok(user.UserDTO);
            //}
            return Ok(user.UserDTO);
            // return Ok(userID);
        }

        [HttpPut("{id}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UserDTO> UpdateUser(int id, UserDTO updatedUser)
        {
            if (id < 1 || updatedUser == null || string.IsNullOrEmpty(updatedUser.UserName) ||
                string.IsNullOrEmpty(updatedUser.Password) || string.IsNullOrEmpty(updatedUser.Email))
            {
                return BadRequest("Invalid User Data");
            }

            clsUser? user = _user.Find(id);

            if (user == null)
            {
                return NotFound($"User with id {id} not found!");
            }

            user.Initialize(updatedUser, clsUser.enMode.Update);
            user.UserID = id;

            if (user.Save())
            {
                return Ok(user.UserDTO);
            }

            return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An error occurred while updating the user.");
        }


        [HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteUser(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

            if (_user.DeleteUser(id))
            {
                return Ok($"User with ID {id} has been deleted.");
            }

            return NotFound($"User with ID {id} not found. No rows deleted!");
        }
    }
}
