using System;
using System.Net.Http;
using System.Threading.Tasks;
using SiGGTransactionFinancialVI.Client.Interfaces;
using SiGGTransactionFinancialVI.Client.Settings;
using SiGGTransactionFinancialVI.Common.HttpModels.Authentication;
using SiGGTransactionFinancialVI.Common.Models;
using SiGGTransactionFinancialVI.Common.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace SiGGTransactionFinancialVI.Client.Services
{
    public class BodyGuardConfigurationApiService : BodyGuardBaseApiService
    {

        private readonly CommonSettings _commonSettings;

        public BodyGuardConfigurationApiService(IBodyGuardClientSettings settings,
                                                IHttpClientFactory httpClientFactory,
                                                IHttpContextAccessor httpContextAccessor,
                                                IOptions<CommonSettings> commonSettings) :
            base(settings, httpClientFactory, httpContextAccessor)
        {
            _commonSettings = commonSettings.Value;
        }

        public async Task ConfigureCommonSettings()
        {
            await PostRequest<UserCreateResponse>("ConfigureCommonSettings", _commonSettings);
        }

    }
}