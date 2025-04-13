using Microsoft.EntityFrameworkCore;
using MyWebApp.Server.Data;
using NLog;

namespace MyWebApp.Server.Service
{
    public class TasksServices
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public TasksServices(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<List<Tasks>> GetAllTasks()
        {
            try
            {
                return await _dbContext.tasks.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Не удалось получить данные из таблицы Tasks в TasksServices");
                return new List<Tasks>();
            }
        }
    }
}
