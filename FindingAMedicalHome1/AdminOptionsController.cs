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
    public class AdminOptionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult AddClinics()
        {
            ViewBag.Message = "Add a New Clinic page.";
            return View();
        }

        public ActionResult EditClinics()
        {
            ViewBag.Message = "Edit Clinics page.";
            return View();
        }

        public ActionResult DeleteClinics()
        {
            ViewBag.Message = "Delete Clinics page.";
            return View();
        }

        public ActionResult ViewDemographics()
        {
            ViewBag.Message = "View Demographics page.";
            return View();
        }


        public ActionResult ClinicAdded()
        {
            ViewBag.Message = "Clinic added";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}