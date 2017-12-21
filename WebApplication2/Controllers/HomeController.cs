using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using Microsoft.AspNetCore.Authorization;
using WebApplication2.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Announcements
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.Announcement.Include(a => a.ApplicationUser);
            //_context.Announcement.Include(a => a.Comments);
            //return View(await applicationDbContext.ToListAsync());


            var announcements = _context.Announcement.Include(a => a.ApplicationUser).ToList();
            var comments = _context.Comment.Include(c => c.ApplicationUser).ToList();

            foreach (Announcement a in announcements)
            {
                foreach (Comment c in comments)
                {
                    if (c.AnnouncementForeignKey == a.AnnouncementId)
                    {
                        a.Comments.Add(c);
                    }
                }
            }

            return View(announcements);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
