using TheDiamondDashboardBackEnd.Services.ManagerService;
using Microsoft.Extensions.DependencyInjection;
using TheDiamondDashboardBackEnd.Data;

namespace TheDiamondDashboardBackEnd.InterfaceFactory
{
    public class InterfaceCollection
    {
        public static IManagerService GetIManagerService()
        {
            var serviceProvider = new ServiceCollection()
                .BuildServiceProvider();
            var dataContext = serviceProvider.GetRequiredService<DataContext>();
            return new ManagerService(dataContext);
        }

        public static IManagerService GetTestIManagerService()
        {
            return new ManagerTestService();
        }
    }
}
