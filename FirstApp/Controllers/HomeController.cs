using FirstApp.Models;
using FirstApp.Storage;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MessageList()
        {
            return View(MessageStorage.Massages);
        }
        [HttpPost]
        public IActionResult Send(MessageModel model)
        {
            MessageStorage.Massages.Add(model);
            return RedirectToAction("MessageList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}