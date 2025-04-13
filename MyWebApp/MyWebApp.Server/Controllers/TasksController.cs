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
    }
}
