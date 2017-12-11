using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormAuthSample4.Repository;
using FormAuthSample4.Models;
using FormAuthSample4.ViewModel;
namespace FormAuthSample4.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            User userAccount = checkCOokies();
            if (userAccount == null)
                return View();

            else
            {
                AccountModel accModel = new AccountModel();
                if (accModel.login(userAccount.UserName, userAccount.Password))
                {
                    Session["userName"] = userAccount.UserName;
                    return View();
                }
                else
                {
                    ViewBag.Error = "Account Invalid.";
                    return View();
                }
            }

        }
        public User checkCOokies()
        {
            User userAccount = null;
            string userName = string.Empty, password = string.Empty;
            if (Request.Cookies["userName"] != null)
            {
                userName = Request.Cookies["userName"].Value;
            }
            if (Request.Cookies["password"] != null)
            {
                userName = Request.Cookies["password"].Value;
            }
            if (!String.IsNullOrEmpty(userName) && !String.IsNullOrEmpty(password))
            {
                userAccount = new User
                {
                    UserName = userName,
                    Password = password
                };

            }
            return userAccount;

        }
        public ActionResult Logout()
        {
            Session.Remove("userName");

            if (Response.Cookies["userName"] != null)
            {
                HttpCookie cookieUsrName = new HttpCookie("userName");
                cookieUsrName.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(cookieUsrName);
            }
            if (Response.Cookies["password"] != null)
            {
                HttpCookie cookiepassword = new HttpCookie("password");
                cookiepassword.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(cookiepassword);
            }
            return View("Index");
        }
        public ActionResult Login(AccountViewModel avm)
        {
            AccountModel accmodel = new AccountModel();
            if (accmodel.login(avm.accountViewModel.UserName, avm.accountViewModel.Password))
            {
                Session["userName"] = avm.accountViewModel.UserName;
                if (avm.rememberMe)
                {
                    HttpCookie cookieUsrName = new HttpCookie("userName");
                    cookieUsrName.Expires = DateTime.Now.AddSeconds(3600);
                    Response.Cookies.Add(cookieUsrName);

                    HttpCookie cookiepassword = new HttpCookie("password");
                    cookiepassword.Expires = DateTime.Now.AddSeconds(3600);
                    Response.Cookies.Add(cookiepassword);
                }
                return View("Welcome");
            }
            else
            {
                return View("Index");
            }

        }
    }
}