using Microsoft.AspNetCore.Http.HttpResults;

namespace TheDiamondDashboardBackEnd.Services.ManagerService
{
    public class ManagerTestService : IManagerService
    {
        public List<Manager> managers = new List<Manager>
        {
            new Manager(1, "Mark", "Pirates"),
            new Manager(2, "John", "Cubs")
        };

        public async Task<List<Manager>> AddManager(Manager manager)
        {
           managers.Add(manager);
           return managers;
        }

        public async Task<List<Manager>?> DeleteManager(int id)
        {
            var manager = managers.Find(m => m.Id == id);
            if (manager == null)
                return null;
            managers.Remove(manager);
            return managers;
        }

        public async Task<List<Manager>> GetAllManagers()
        {
            return managers;
        }

        public async Task<Manager?> GetSingleManager(int id)
        {
            var manager = managers.Find(m => m.Id == id);
            if (manager == null)
                return null;
            return manager;
        }

        public async Task<List<Manager>?> UpdateManager(Manager request)
        {
            var manager = managers.Find(m => m.Id == request.Id);
            if (manager == null)
                return null;
            manager.Name = request.Name;
            manager.ClubName = request.ClubName;
            return managers;
        }
    }
}
