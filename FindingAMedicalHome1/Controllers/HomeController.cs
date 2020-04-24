using FindingAMedicalHome1.Models;
using FindingAMedicalHome1.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;


namespace FindingAMedicalHome1.Controllers
{
    public class HomeController : Controller
    {       
            public ActionResult Index()
            {
                return View();
            }

       
        [HttpPost]
        public async Task<IActionResult> Index(LoginModel loginModel)
        {
            if (loginModel == null || !ModelState.IsValid)
            {
                // some form of validation here, no username or password was provided
                // front end should have validation too
                //this statement protects from the event that someone makes a web request without your ui
            }

            var isAuthenticated = await AuthenticationManager.AuthenticateUser(loginModel.Username, loginModel.Password);

            if (!isAuthenticated)
            {
                // authentication failed; user cannot be validated and therefore will not be logged in
            }
            else
            {
                
                var claims = new List<Claim>
                {
                    // nameidentifier is a unique ID which identifies the user. This is the User ID from the database
                    new Claim(ClaimTypes.NameIdentifier, "12345"), 

                    // email 
                    new Claim(ClaimTypes.Email, "auser@adomain.com"), 

                    // these are customizable but can be used with Authorize attribute 
                    
                    new Claim(ClaimTypes.Role, "Admin")
                };

                // creates an identity
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    RedirectUri = "/adminoptions/index"
                };

                // sign the user in, create a cookie that will be sent back over to the client
                // the cookie will then be sent back to the server on every request to validate them
                await HttpContext.SignInAsync(
                  CookieAuthenticationDefaults.AuthenticationScheme,
                  new ClaimsPrincipal(claimsIdentity),
                  authProperties
                );
            }

            return View();
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
