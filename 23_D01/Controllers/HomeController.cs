using _23_D01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace _23_D01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DB002Context _context;

        public HomeController(ILogger<HomeController> logger, DB002Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int id)
        {
            ViewData["Phongs"] = _context.Phongs.ToList();

            int maphong = _context.Phongs.First().Maphong;
            var listDefault = _context.NhanViens.Where(nv => nv.Maphong == maphong).ToList();

            var nhanviens = _context.NhanViens.Where(nv => nv.Maphong == id).ToList();

            ViewData["NhanViens"] = nhanviens.Count == 0 ? listDefault : nhanviens;

            return View();
        }
        public IActionResult LeftMenu()
        {
            ViewData["Phongs"] = _context.Phongs.ToList();
            return PartialView("LeftMenu");
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            ViewData["Phongs"] = _context.Phongs.ToList();
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Privacy()
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
