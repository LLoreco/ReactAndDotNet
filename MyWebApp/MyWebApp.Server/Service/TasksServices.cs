using Microsoft.EntityFrameworkCore;
using MyWebApp.Server.Data;
using MyWebApp.Server.Model;
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

        public async Task<List<TaskDto>> GetAllTasks()
        {
            try
            {
                var entities = await _dbContext.tasks.ToListAsync();
                var result = entities.Select(t => new TaskDto
                {
                    Id = t.id,
                    TaskName = t.TaskName,
                    TaskTime = t.TaskTime.ToString("dd.MM.yyyy HH:mm"),
                    IsCompleted = t.IsCompleted
                }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Не удалось получить данные из таблицы Tasks в TasksServices");
                return new List<TaskDto>();
            }
        }
        public async Task<TaskResult<Tasks>> GetTask(int id)
        {
            try
            {
                var task = await _dbContext.tasks.FindAsync(id);
                return new TaskResult<Tasks>
                {
                    IsSuccess = true,
                    Result = task
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Не удалось получить данные из таблицы Tasks в TasksServices");
                return new TaskResult<Tasks>
                {
                    IsSuccess = false,
                    Result = null
                };
            }
        }
        public async Task<TaskResult<bool>> InsertRecord(Tasks task)
        {
            try
            {
                if (task != null)
                {
                    _dbContext.tasks.Add(task);
                    await _dbContext.SaveChangesAsync();
                    _logger.Info("Создана новая запись и сохранена в таблицу Tasks");
                    return new TaskResult<bool>
                    {
                        IsSuccess = true,
                        Result = true
                    };
                }
                else
                {
                    _logger.Info("Ваша задача пустая");
                    return new TaskResult<bool>
                    {
                        IsSuccess = false,
                        Result = false
                    };
                }
                
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Не удалось записать данные в таблицу Tasks в TasksService");
                return new TaskResult<bool>
                {
                    IsSuccess = false,
                    Result = false
                };
            }
        }
        public async Task<TaskResult<bool>> UpdateRecord(Tasks taskUpdate)
        {
            try
            {
                var taskRecordUpdate = await _dbContext.tasks.FindAsync(taskUpdate.id);
                if (taskRecordUpdate != null)
                {
                    taskRecordUpdate.id = taskUpdate.id;
                    taskRecordUpdate.TaskName = taskUpdate.TaskName;
                    taskRecordUpdate.TaskCreated = taskUpdate.TaskCreated;
                    taskRecordUpdate.TaskTime = taskUpdate.TaskTime;
                    taskRecordUpdate.IsCompleted = taskUpdate.IsCompleted;
                    _logger.Info("Запись обновлена");
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    _logger.Info("Не найдена такая задача");
                    return new TaskResult<bool>
                    {
                        IsSuccess = false,
                        Result = false
                    };
                }
                return new TaskResult<bool>
                {
                    IsSuccess = true,
                    Result = true
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Не удалось обновить данные в таблице Task в TasksService");
                return new TaskResult<bool>
                {
                    IsSuccess = false,
                    Result = false
                };
            }
        }
        public async Task<TaskResult<bool>> DeleteRecord(Tasks task)
        {
            try
            {
                var taskRecordDelete = await _dbContext.tasks.FindAsync(task.id);
                if (taskRecordDelete != null)
                {
                    _dbContext.tasks.Remove(taskRecordDelete);
                    await _dbContext.SaveChangesAsync();
                    return new TaskResult<bool>
                    {
                        IsSuccess = true,
                        Result = true
                    };
                }
                else
                {
                    return new TaskResult<bool>
                    {
                        IsSuccess = false,
                        Result = false
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Не удалось удалить данные из таблицы Tasks в TasksService");
                return new TaskResult<bool>
                {
                    IsSuccess = false,
                    Result = false
                };
            }
        }
    }
}
