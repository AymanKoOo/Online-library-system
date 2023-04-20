using Core.Entites;
using Core.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using Web.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Route("/Account/")]
    public class AccountController : Controller
    {
        //usermanger
        //signInManager
        //roleManger

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly SignInManager<ApplicationUser> _signInManger;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            this.unitOfWork = unitOfWork;
            _signInManger = signInManager;
            _roleManager = roleManager;
        }


        /////Helper Funtions////
        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            if (await _userManager.FindByEmailAsync(email) == null) return false;
            else return true;
        }
        ////// //////// ////// /////// /////

        [HttpGet]
        [Route("Register")]
        public ActionResult Register()
        {
            return View("~/Views/Account/Register.cshtml");
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            
            if (!ModelState.IsValid && await _roleManager.RoleExistsAsync("User")==true)
            {
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }

            await _userManager.AddToRoleAsync(user, "User");

            await _signInManger.SignInAsync(user, isPersistent: false);

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        [Route("Login")]
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
          
            return View("~/Views/Account/Login.cshtml");
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginVM model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (!ModelState.IsValid || user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return View(model);
            }
            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return View(model);
            }

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password) && await _userManager.IsInRoleAsync(user, "User"))
            {
                var username = user.UserName;
                var email = user.Email;
                var roleName = "User";
                var userId = user.Id;

                var claims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Email,email),
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Role, roleName),
                    };

                //authentication ticket//
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                    AllowRefresh = true,
                };

                CookieOptions options = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(7),
                    IsEssential = true
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimIdentity),
                    authProperties
                    );
                return RedirectToAction("Index", "Home");
            }

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password) && await _userManager.IsInRoleAsync(user, "Admin"))
              {
                    var username = user.UserName;
                    var email = user.Email;
                    var roleName = "Admin";
                    var userId = user.Id;

                    var claims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Email,email),
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Role, roleName),
                    };

                    //authentication ticket
                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true, //When IsPersistent is set to true, the authentication cookie will be stored on the user's machine even after the browser is closed, and will remain valid until its expiration time is reached. 
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                        AllowRefresh = true, //get authentication token again from middleware will renew the expiredate
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity), // ClaimsPrincipal is a class that represents the user's identity and associated claims, and is used to perform authorization checks in your application. A ClaimsPrincipal object is created from a ClaimsIdentity object, which contains a collection of claims that represent the user's identity.
                        authProperties
                        );
                    return RedirectToAction("Index", "Admin");
            }

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        ///////////////////Account Setting///////////////////

        [HttpGet]
        [Authorize]
        [Route("MyAccount")]
        public async Task<IActionResult> MyAccount()
        {

            return View();
        }

    }
}
