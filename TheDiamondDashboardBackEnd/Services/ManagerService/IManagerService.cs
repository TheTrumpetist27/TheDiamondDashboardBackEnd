namespace TheDiamondDashboardBackEnd.Services.ManagerService
{
    public interface IManagerService
    {
        Task<List<Manager>> GetAllManagers();
        Task<Manager?> GetSingleManager(int id);
        Task<List<Manager>> AddManager(Manager manager);
        Task<List<Manager>?> UpdateManager(Manager request);
        Task<List<Manager>?> DeleteManager(int id);
    }
}
