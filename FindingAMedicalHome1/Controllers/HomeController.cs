using System;
using System.Collections.Generic;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindingAMedicalHome1.Models;

namespace FindingAMedicalHome1.Controllers
{
    public class HomeController : Controller
    {       
            public ActionResult Index()
            {
                return View();
            }

        

        /* 
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        } Need this function? */

        [HttpPost]
        public ActionResult Index(Credentials UserName, Credentials Password) 
        {
        String Uname = UserName.ToString();
        String Upass = Password.ToString();
        String result = "";
       // Credentials cred = new Credentials();
        

        //String result = Credentials.CompareCredentials(Uname, Upass);
        if (result != "Login Successful")
        {
            //Login failed
        }
        else
        {
            //Login success

        }

            return View();
        //return RedirectToAction();
        }

       
        public ActionResult FindClinics()
            {
                ViewBag.Message = "Find Clinics page.";

                return View();
            }

            
        public ActionResult AdminOptions()
            {
                ViewBag.Message = "Admin Options page.";
                return View();
            }

         

        public ActionResult Logout()
        {
            ViewBag.Message = "Logout";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
    }
}
