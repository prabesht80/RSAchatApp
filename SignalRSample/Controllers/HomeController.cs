using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRSample.Data;
using SignalRSample.Hubs;
using SignalRSample.Models;
using SignalRSample.Models.ViewModel;
using System.Diagnostics;
using System.Security.Claims;

namespace SignalRSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;  
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        
        }
        [Authorize]
        public IActionResult Chat()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ChatVM chatVm = new()
            {
                Rooms = _context.ChatRoom.ToList(),
                MaxRoomAllowed = 4,
                UserId = userId,
            };
            return View(chatVm);
        }
        public IActionResult AdvancedChat()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ChatVM chatVm = new()
            {
                Rooms = _context.ChatRoom.ToList(),
                MaxRoomAllowed = 4,
                UserId = userId,
            };
            return View(chatVm);
        }
        public IActionResult BasicChat()
        {
            return View();
        }
       

    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        

       

    }
}