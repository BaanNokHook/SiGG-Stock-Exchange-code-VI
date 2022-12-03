using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StockExchange.API.Infrastructure;
using StockExchange.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace StockExchange.API.Controllers.V1
{
    //[Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class StockproviderController : ControllerBase
    {
        private readonly IStockproviderService StockproviderService;

        public StockproviderController(IStockproviderService StockproviderService)
        {
            //this.config = config;
            this.StockproviderService = StockproviderService;
        }

        [HttpPost(ApiRoutes.Stockprovider.StockproviderInfo)]
        public IActionResult BankInfo([FromRoute] long userId)
        {
            var response = StockproviderService.GetBankInfo(userId);

            return Ok(response);
        }

    }
}




