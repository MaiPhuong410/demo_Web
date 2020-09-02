using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using QuanLyCuaHang.Models;
namespace QuanLyCuaHang.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(Account acc, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (acc.UserName == "obama" && acc.PassWord == "123")
                {
                    FormsAuthentication.SetAuthCookie(acc.UserName, true);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1
                        && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Your username or password is incorrect");
                }
            }
            return View(acc);
        }


    }
}