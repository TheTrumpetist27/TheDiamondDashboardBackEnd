namespace TheDiamondDashboardBackEnd.Services.ManagerService
{
    public class ManagerService : IManagerService
    {
        private readonly DataContext _context;
        public ManagerService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Manager>> AddManager(Manager manager)
        {
            _context.manager.Add(manager);
            await _context.SaveChangesAsync();
            return await _context.manager.ToListAsync();
        }

        public async Task<List<Manager>?> DeleteManager(int id)
        {
            var manager = await _context.manager.FindAsync(id);
            if (manager == null)
            {
                return null;
            }
            _context.manager.Remove(manager);
            await _context.SaveChangesAsync();
            return await _context.manager.ToListAsync();
        }

        public async Task<List<Manager>> GetAllManagers()
        {
            var managers = await _context.manager.ToListAsync();
            return managers;
        }

        public async Task<Manager?> GetSingleManager(int id)
        {
            var manager = await _context.manager.FindAsync(id);
            if (manager == null)
            {
                return null;
            }
            return manager;
        }

        public async Task<List<Manager>?> UpdateManager(Manager request)
        {
            var manager = await _context.manager.FindAsync(request.Id);
            if (manager == null)
            {
                return null;
            }

            manager.Name = request.Name;
            manager.ClubName = request.ClubName;

            await _context.SaveChangesAsync();

            return await _context.manager.ToListAsync();
        }
    }
}
