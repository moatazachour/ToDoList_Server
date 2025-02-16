using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList_BusinessLayer;
using ToDoList_DataAccessLayer.DTO.Task;

namespace ToDoList_API.Controllers
{
    [Route("api/Tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly clsTask _task;

        public TaskController(clsTask task)
        {
            _task = task;
        }


        [HttpGet("{id}", Name = "GetTaskByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TaskDetailsDTO> GetTaskByID(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

            clsTask? task = _task.Find(id);

            if (task == null)
            {
                return NotFound($"Task with ID {id} not found!");
            }

            return Ok(task.TaskDetailsDTO);
        }




        [HttpGet("All/{userID}", Name = "GetAllTasksByUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<TaskListDTO>> GetAllTasksByUser(int userID)
        {
            if (userID < 1)
            {
                return BadRequest($"Not accepted ID {userID}!");
            }

            List<TaskListDTO> tasksList = _task.GetAllTasksByUser(userID);

            //if (tasksList.Count == 0)
            //{
            //    return NotFound("No tasks founds!");
            //}

            return Ok(tasksList);
        }



        [HttpGet("Earlier/{userID}", Name = "GetEarlierTasksByUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<TaskListDTO>> GetEarlierTasksByUser(int userID)
        {
            if (userID < 1)
            {
                return BadRequest($"Not accepted ID {userID}!");
            }

            List<TaskListDTO> tasksList = _task.GetEarlierTasksByUser(userID);

            //if (tasksList.Count == 0)
            //{
            //    return NotFound("No tasks founds!");
            //}

            return Ok(tasksList);
        }

        [HttpGet("Today/{userID}", Name = "GetTodayTasksByUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<TaskListDTO>> GetTodayTasksByUser(int userID)
        {
            if (userID < 1)
            {
                return BadRequest($"Not accepted ID {userID}!");
            }

            List<TaskListDTO> tasksList = _task.GetTodayTasksByUser(userID);

            //if (tasksList.Count == 0)
            //{
            //    return NotFound("No tasks founds!");
            //}

            return Ok(tasksList);
        }


        [HttpGet("Important/{userID}", Name = "GetImportantTasksByUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<TaskListDTO>> GetImportantTasksByUser(int userID)
        {
            if (userID < 1)
            {
                return BadRequest($"Not accepted ID {userID}!");
            }

            List<TaskListDTO> tasksList = _task.GetImportantTasksByUser(userID);

            //if (tasksList.Count == 0)
            //{
            //    return NotFound("No tasks founds!");
            //}

            return Ok(tasksList);
        }

        [HttpGet("Tomorrow/{userID}", Name = "GetTomorrowTasksByUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<TaskListDTO>> GetTomorrowTasksByUser(int userID)
        {
            if (userID < 1)
            {
                return BadRequest($"Not accepted ID {userID}!");
            }

            List<TaskListDTO> tasksList = _task.GetTomorrowTasksByUser(userID);

            //if (tasksList.Count == 0)
            //{
            //    return NotFound("No tasks founds!");
            //}

            return Ok(tasksList);
        }



        [HttpPost(Name = "AddNewTask")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TaskDetailsDTO> AddNewTask(CreateTaskDTO createTaskDTO)
        {
            if (createTaskDTO == null)
            {
                return BadRequest("Invalid Task Data!");
            }

            _task.Initialize(createTaskDTO);

            if (_task.Save())
            {
                var taskDetailsDTO = new TaskDetailsDTO(_task.TaskID, _task.Title, _task.Description,
                    _task.IssueDate, _task.DueDate, _task.IsImportant, _task.StatusID, _task.StatusName, _task.UserID);
                
                return CreatedAtRoute("GetTaskByID", new { id = taskDetailsDTO.TaskID }, taskDetailsDTO);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }


        [HttpPut("{taskID}", Name = "UpdateTask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TaskListDTO> UpdateTask(int taskID, UpdateTaskDTO updateTaskDTO)
        {
            if (taskID < 1 || updateTaskDTO == null)
            {
                return BadRequest("Invalid tadk data!");
            }

            clsTask? task = _task.Find(taskID);

            if (task == null)
            {
                return NotFound($"Task with ID {taskID} not found!");
            }

            task.Initialize(updateTaskDTO);
            task.TaskID = taskID;

            if (task.Save())
            {
                return Ok(task.TaskListDTO);
            }

            return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An error occurred while updating the user.");
        }


        [HttpDelete("{taskID}", Name = "DeleteTask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteTask(int taskID)
        {
            if (_task.Delete(taskID))
            {
                return Ok($"Task with ID {taskID} is deleted successfully");
            }
            else
            {
                return NotFound($"Student with ID {taskID} not found. no rows deleted!");
            }
        }
    }
}
