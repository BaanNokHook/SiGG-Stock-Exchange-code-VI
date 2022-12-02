using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SiGGTransactionFinancialVI.Client.Interfaces;
using SiGGTransactionFinancialVI.Client.Settings;
using SiGGTransactionFinancialVI.Common.HttpModels.Authentication;
using SiGGTransactionFinancialVI.Common.HttpModels.Authorization;
using SiGGTransactionFinancialVI.Common.Settings;
using Microsoft.AspNetCore.Http;

namespace SiGGTransactionFinancialVI.Client.Services
{
    public class BodyGuardAuthorizationApiService : BodyGuardBaseApiService, IBodyGuardAuthorizationApiService
    {

        public BodyGuardAuthorizationApiService(IBodyGuardClientSettings settings,
                                                IHttpClientFactory httpClientFactory,
                                                IHttpContextAccessor httpContextAccessor) :
            base(settings, httpClientFactory, httpContextAccessor)
        {
        }

        public async Task<GetRolesResponse> GetRoles()
        {
            var baseApiResult =
                await GetRequest<GetRolesResponse>("GetRoles");

            if (!baseApiResult.Success)
                throw new Exception(baseApiResult.Message);

            return baseApiResult.Response;
        }

        public async Task<CanResponse> Can(string id,
                                           List<string> roles,
                                           Dictionary<string, string> claims,
                                           bool canAll)
        {
            var baseApiResult =
                await PostRequest<CanResponse>("Can", new CanRequest
                {
                    Id = id,
                    Roles = roles,
                    Claims = claims,
                    CanAll = canAll
                });

            if (!baseApiResult.Success)
                throw new Exception(baseApiResult.Message);

            return baseApiResult.Response;
        }

        public async Task<ManageRoleResponse> AssignRole(string emailAddress,
                                                         string role)
        {
            var manageRoleRequest = new ManageRoleRequest
            {
                EmailAddress = emailAddress,
                Role = role
            };

            var baseApiResult =
                await PutRequest<ManageRoleResponse>("AssignRole", manageRoleRequest);

            if (!baseApiResult.Success)
                throw new Exception(baseApiResult.Message);

            return baseApiResult.Response;
        }

        public async Task<ManageRoleResponse> RevokeRole(string emailAddress,
                                                         string role)
        {
            var manageRoleRequest = new ManageRoleRequest
            {
                EmailAddress = emailAddress,
                Role = role
            };

            var baseApiResult =
                await PutRequest<ManageRoleResponse>("RevokeRole", manageRoleRequest);

            if (!baseApiResult.Success)
                throw new Exception(baseApiResult.Message);

            return baseApiResult.Response;
        }

    }
}