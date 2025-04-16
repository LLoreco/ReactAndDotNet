using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Server.Data;
using MyWebApp.Server.Service;
using NLog;
using System.Text.Json;

namespace MyWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly TasksServices _tasksService;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
            _tasksService = new TasksServices(_context);
        }

        //GET: api/Tasks/GetAllTasks
        [HttpGet("GetAllTasks")]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetTasks()
        {
            try
            {
                var tasks = await _tasksService.GetAllTasks();
                if (tasks.Count > 0)
                {
                    _logger.Info("Получил вcе задачи через GET запрос");
                    return Ok(JsonSerializer.Serialize(tasks));
                }
                else
                {
                    return StatusCode(404, "Задачи не найдены.");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Произошла ошибка при получении всех задач.");
                return StatusCode(500, "Произошла ошибка при получении всех задач. Попробуйте позже.");
            }
        }

        //GET: api/Tasks/GetTask/id
        [HttpGet("GetTask/{id}")]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetTask(int id)
        {
            try
            {
                var tasks = await _tasksService.GetTask(id);
                if (tasks.IsSuccess)
                {
                    _logger.Info($"Получил задачу {id} через GET запрос");
                    return Ok(JsonSerializer.Serialize(tasks));
                }
                else
                {
                    return StatusCode(404, $"Задача {id} не найдена.");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Произошла ошибка при получении задачи {id}.");
                return StatusCode(500, "Произошла ошибка при получении задачи {id}. Попробуйте позже.");
            }
        }

        //GET: api/Tsks/GetActiveTask
        [HttpGet("GetActiveTask")]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetActiveTask()
        {
            try
            {
                var activeTask = await _tasksService.GetActiveTasks();
                if (activeTask.IsSuccess)
                {
                    _logger.Info($"Получил активную задачу");
                    return Ok(JsonSerializer.Serialize(activeTask));
                }
                else
                {
                    return StatusCode(404, $"Активная задача не найдена.");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Произошла ошибка при получении активной задачи");
                return StatusCode(500, "Произошла ошибка при получении активной задачи. Попробуйте позже.");
            }
        }
        //POST: api/Tasks/AddTask
        [HttpPost("AddTask")]
        public async Task<ActionResult<Tasks>> AddTask(Tasks item)
        {
            try
            {
                var result = await _tasksService.InsertRecord(item);
                if (result.IsSuccess)
                {
                    _logger.Info($"Добавил задачу {item.id} через POST запрос");
                    return Ok(JsonSerializer.Serialize(item));
                }
                else
                {
                    return StatusCode(404, "Задача не добавлена.");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Произошла ошибка при добавлении задачи {item.id}.");
                return StatusCode(500, $"Произошла ошибка при добавлении задачи {item.id}. Попробуйте позже.");
            }
        }

        //PUT: api/Tasks/UpdateTask/id
        [HttpPut("UpdateTask/{id}")]
        public async Task<IActionResult> UpdateTask(int id, Tasks item)
        {
            try
            {
                var result = await _tasksService.UpdateRecord(item);
                if (result.IsSuccess)
                {
                    _logger.Info($"Обновил задачу {item.id} через PUT запрос");
                    await _context.SaveChangesAsync();
                    return Ok(JsonSerializer.Serialize(item));
                }
                else
                {
                    return StatusCode(404, "Задача не обновлена.");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Произошла ошибка при обновлении задачи {item.id}.");
                return StatusCode(500, $"Произошла ошибка при обновлении задачи {item.id}. Попробуйте позже.");
            }
        }

        //DELETE: api/Tasks/DeleteTask/id
        [HttpDelete("DeleteTask/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var taskResult = await _tasksService.GetTask(id);
                if (taskResult.IsSuccess)
                {
                    var task = taskResult.Result;
                    var deleteTask = await _tasksService.DeleteRecord(task);
                    if (deleteTask.IsSuccess)
                    {
                        _logger.Info($"Удалил Задачу {id} через DELETE запрос");
                        await _context.SaveChangesAsync();
                        return Ok(JsonSerializer.Serialize(deleteTask));
                    }
                    else
                    {
                        return StatusCode(500, "Задача не удалена.");
                    }
                }
                else
                {
                    return StatusCode(404, "Задача не удалена.");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Произошла ошибка при удалении задачи {id}.");
                return StatusCode(500, $"Произошла ошибка при удалении задачи {id}. Попробуйте позже.");
            }
        }
    }
}
