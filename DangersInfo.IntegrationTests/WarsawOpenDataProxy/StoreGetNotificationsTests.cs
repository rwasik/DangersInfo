using System.Linq;
using System.Threading.Tasks;
using DangersInfo.Configuration.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WarsawOpenData.Proxy.Services;
using WarsawOpenData.Proxy.Utils;

namespace DangersInfo.IntegrationTests.WarsawOpenDataProxy
{
    [TestClass]
    public class StoreGetNotificationsTests
    {
        private IOptions<WarsawOpenDataSettings> _options;

        [TestInitialize]
        public void Init()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false);

            IConfigurationRoot configuration = configurationBuilder.Build();

            var settings = configuration.GetSection("WarsawOpenDataSettings").Get<WarsawOpenDataSettings>();
            _options = Options.Create(settings);            
        }

        [TestMethod, TestCategory("Integration")]
        public async Task GetSerialObjectsByContainerIdAsync_ReturnsContainerWithSerialObjects()
        {
            // arrange
            var service = new WarsawOpenDataService(new RemoteClient(), _options);

            // act
            var notifications = await service.GetReportedNotificationsAsync();

            // assert
            Assert.IsNotNull(notifications);
            Assert.IsTrue(notifications.Any());
        }
    }
}
