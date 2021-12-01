using System.Collections.Generic;
using HotelApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HotelApplication.Controllers
{
    public class HotelController : Controller
    {
        private readonly IConfiguration _configuration;

        private static readonly List<Client> _clients = new()
        {
            new Client() { Id = 1, FirstName = "Ivan", LastName = "Ivanov", Patronymic = "Ivanovich", PassportData = "Russian", Notes = "No Smoking" },
            new Client() { Id = 2, FirstName = "Ivan", LastName = "Ivanov", Patronymic = "Ivanovich", PassportData = "Russian", Notes = "No Smoking" },
            new Client() { Id = 3, FirstName = "Ivan", LastName = "Ivanov", Patronymic = "Ivanovich", PassportData = "Russian", Notes = "No Smoking" },
        };

        public HotelController(IConfiguration configuration) => _configuration = configuration;

        public IActionResult Index()
        {
            return View(_clients);
        }
    }
}
