using StockExchange.API.ViewModels;
using StockExchange.Domain;
using Microsoft.AspNetCore.Mvc;
using System;

namespace StockExchange.API.Services
{
    public class CardsService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}



