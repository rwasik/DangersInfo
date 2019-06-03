using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DangersInfo.Configuration.Configs;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WarsawOpenData.Proxy.Contracts;
using WarsawOpenData.Proxy.Services;
using WarsawOpenData.Proxy.Utils;

namespace DangersInfo.Tests.WarsawOpenDataProxy.Services
{
    [TestClass]
    public class WarsawOpenDataServiceTests
    {
        private Mock<IRemoteClient> _remoteClientMock;
        private Mock<IOptions<WarsawOpenDataSettings>> _settingsMock;

        private IWarsawOpenDataService _warsawOpenDataService;

        [TestInitialize]
        public void Init()
        {
            _remoteClientMock = new Mock<IRemoteClient>();
            _settingsMock = new Mock<IOptions<WarsawOpenDataSettings>>();
            _settingsMock.Setup(options => options.Value).Returns(new WarsawOpenDataSettings { ApiId = "id", ApiKey = "key", ApiUrl = "url" });

            _warsawOpenDataService = new WarsawOpenDataService(_remoteClientMock.Object, _settingsMock.Object);
        }

        [TestMethod]
        public async Task GetReportedNotificationsAsync_WhenResponseSucceedeed_ReturnsNotifications()
        {
            // arrange
            _remoteClientMock.Setup(client => client.GetAsync<NotificationsResponse>(It.IsAny<string>())).ReturnsAsync(
                new NotificationsResponse
                {
                    Result = new NotificationsResult
                    {
                        Success = true,
                        Data = new NotificationsData {Notifications = new List<Notification> {new Notification()}}
                    }
                });
            
            // act
            var notifications = await _warsawOpenDataService.GetReportedNotificationsAsync();

            // assert
            Assert.AreEqual(1, notifications.Count());
        }

        [TestMethod]
        public async Task GetReportedNotificationsAsync_WhenResponseFailed_ThrowsAnException()
        {
            // arrange
            _remoteClientMock.Setup(client => client.GetAsync<NotificationsResponse>(It.IsAny<string>())).ReturnsAsync(
                new NotificationsResponse
                {
                    Result = new NotificationsResult
                    {
                        Success = false,
                        ResponseCode = "999",
                        ResponseDesc = "failure"
                    }
                });

            // act
            try
            {
                await _warsawOpenDataService.GetReportedNotificationsAsync();
            }
            catch(Exception ex)
            {
                // assert
                Assert.AreEqual("[WarsawOpenDataService] 19115store_getNotifications failed. Response code: 999. Description: failure", ex.Message);
            }
        }
    }
}
