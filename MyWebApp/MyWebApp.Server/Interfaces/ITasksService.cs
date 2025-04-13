using MyWebApp.Server.Data;
using MyWebApp.Server.Model;

namespace MyWebApp.Server.Interfaces
{
    public interface ITasksService
    {
        public Task<List<Tasks>> GetALlRecoveryHistory();
        public Task<TaskResult<Tasks>> GetRecoveryHistory(int id);
        public Task<TaskResult<bool>> InsertRecord(Tasks recoveryHistory, bool fromWork);
        public Task<TaskResult<Tasks>> EditRecord(int recoveryHistoryId);
        public Task<TaskResult<bool>> UpdateRecord(Tasks recoveryHistoryUpdate);
        public Task<TaskResult<bool>> DeleteRecord(Tasks recoveryHistoryDelete);
    }
}
