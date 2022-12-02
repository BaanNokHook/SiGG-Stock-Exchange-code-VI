using System.Net.Http;
using SiGGTransactionFinancialVI.Client.Services;
using SiGGTransactionFinancialVI.Client.Settings;
using SiGGTransactionFinancialVI.Common.BaseClasses;
using SiGGTransactionFinancialVI.Common.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace SiGGTransactionFinancialVI.Client.Utilities
{
    public class BodyGuardConfigurationUtility : InjectableServicesBaseStaticClass
    {

        public static void ConfigureCommonSettings()
        {
            using (var scope = Services.CreateScope())
            {
                var bodyGuardClientSettings =
                    scope.ServiceProvider.GetService<IBodyGuardClientSettings>();
                var httpClientFactory = scope.ServiceProvider.GetService<IHttpClientFactory>();
                var httpContextAccessor = Services.GetService<IHttpContextAccessor>();
                var options = scope.ServiceProvider.GetService<IOptions<CommonSettings>>();
                var configurationApiService =
                    new BodyGuardConfigurationApiService(bodyGuardClientSettings, httpClientFactory,
                                                         httpContextAccessor, options);
                var task = configurationApiService.ConfigureCommonSettings();
            }

        }

    }

}