using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KPMGLoginForm.Models;

namespace KPMGLoginForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository )
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(TblUser User)
        {
            if (User.UserEmail == null && User.Password == null && User.Username == null)
            {
                return View();
            }
            TblUser user = null;
            user = this._userRepository.GetUser(User.UserEmail, User.Password);
            if(user != null)
            {
                return RedirectToAction("UserDashboard", user);
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid UserName or Password";
                return View();
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(TblUser User)
        {
            if (User.UserEmail == null && User.Password == null && User.Username == null)
            {
                return View();
            }
            if (User != null)
            {
                try
                {
                    this._userRepository.AddUser(User);
                    bool Val = this._userRepository.Save();
                    ViewBag.SuccessMessage = "User Registered Successfully";
                    return View();
                   // return RedirectToAction("Login");
                }
                catch(Exception ex)
                {
                    ViewBag.ErrorMessage = "An Error occured while trying to process your request. Please try again!";
                    return View();
                }
                
                
            }
            else
            {
                return View();
            }

            return View();
        }

        public IActionResult UserDashboard(TblUser user)
        {
            if(user != null)
            {
                ViewBag.Username = user.Username;
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

    }
}
