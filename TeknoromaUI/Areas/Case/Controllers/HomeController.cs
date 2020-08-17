using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstract;
using DAL.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace TeknoromaUI.Areas.Case.Controllers
{
    [Area("Case")]
    [Authorize(Roles ="Case")]
    public class HomeController : Controller
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ICustomerService customerService;

        public HomeController(Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ICustomerService customerService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.customerService = customerService;
        }
        public IActionResult Index()
        {
            return View(customerService.GetActive());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customerService.Add(customer);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult GetCustomerByTC(Guid id)
        {
            return RedirectToAction("GetCustomer",customerService.GetById(id));
        }
        public IActionResult GetCustomer(Customer customer)
        {
            var c = customerService.GetByTc(customer);
            return View(c);
        }
        public async Task<IActionResult> LogOut()
        {
          await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Member", new { area = "" });
        }
    }
}
