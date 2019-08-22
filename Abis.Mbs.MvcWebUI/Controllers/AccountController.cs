using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using Abis.Mbs.MvcWebUI.Entities;
using Abis.Mbs.MvcWebUI.ExtensionMethods;
using Abis.Mbs.MvcWebUI.Models;
using Abis.Mbs.MvcWebUI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Abis.Mbs.MvcWebUI.Controllers
{

    public class AccountController : Controller
    {
        private UserManager<CustomIdentityUser> _userManager;
        private RoleManager<CustomIdentityRole> _roleManager;
        private SignInManager<CustomIdentityUser> _signInManager;

        private readonly IEmailSender _emailSender;





        public AccountController
            (UserManager<CustomIdentityUser> userManager,
            RoleManager<CustomIdentityRole> roleManager, 
            SignInManager<CustomIdentityUser> signInManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _emailSender = emailSender;

        }

        [TempData]
        public string ErrorMessage { get; set; }

        public ActionResult Register()
        {
            return View();
        }

        // 8/1/2019
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                CustomIdentityUser user = new CustomIdentityUser
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email
                };

                IdentityResult result = _userManager.CreateAsync(user, registerViewModel.Password).Result;


                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("User").Result)
                    {
                        CustomIdentityRole role = new CustomIdentityRole
                        {
                            Name = "User"
                        };

                        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "We can't add the role!");
                            return View(registerViewModel);
                        }
                    }

                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    //await _emailSender.SendEmailConfirmationAsync(registerViewModel.Email, callbackUrl);
                    _userManager.AddToRoleAsync(user, "User").Wait();
                    
                    // Email Confirmation
                    string confirmationToken = _userManager.GenerateEmailConfirmationTokenAsync(user).Result;
                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new
                    {
                        userid = user.Id,
                        token = confirmationToken
                    },

                    protocol: HttpContext.Request.Scheme);

                    string confirmationEmailBody = string.Format("<a href='" + confirmationLink + "'>") + "</a>";// confirmation link
                    SmtpClient client = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        Credentials = new NetworkCredential("gueye.amadou1996@gmail.com", "np13novembre"),
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        EnableSsl = true
                    };
                    MailMessage mail = new MailMessage
                    {
                      //string link = String.Format("<a href=\"http://localhost:1900/ResetPassword/?username={0}&reset={1}\">Click here</a>", user.UserName, HashResetParams( user.UserName, user.ProviderUserKey.ToString() ));

                        From = new MailAddress("gueye.amadou1996@gmail.com", user.Email),
                        Body = "Dear " + user.Email + ",\nYour Mbs account has been created successfully." +
                        "Please confirm",
                        Subject = "your account is activated"
                    };
                    mail.To.Add(new MailAddress(user.Email));

                    client.Send(mail);
                    // End email confirmation


                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(" ", error.Description);
                }
            }

            return View(registerViewModel);
        }
        // confirm email 8/1/2019
        [AllowAnonymous]
        public IActionResult ConfirmEmail(string userid, string token)
        {
            CustomIdentityUser user = _userManager.FindByIdAsync(userid).Result;
            IdentityResult result = _userManager.ConfirmEmailAsync(user, token).Result;

            if (result.Succeeded)
            {
                ViewBag.Message = "Email confirmed successfully!";
                return View("Success");
            }

            else
            {
                ViewBag.Message = "Error while confirming Email";
                return View("Error");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(loginViewModel.UserName,
                    loginViewModel.Password, loginViewModel.RememberMe, false).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Homepage");
                }

                ModelState.AddModelError("", "Invalid login!");
            }

            return View(loginViewModel);
        }


        public ActionResult LogOff()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToAction(nameof(Login));
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            // Sign in the user with this external login provider if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            if (result.IsLockedOut)
            {
                return RedirectToAction(nameof(LogOff));
            }
            else
            {
                // If the user does not have an account, then ask the user to create an account.
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["LoginProvider"] = info.LoginProvider;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                return View("ExternalLogin", new ExternalLoginViewModel { Email = email });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    throw new ApplicationException("Error loading external login information during confirmation.");
                }
                var user = new CustomIdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(nameof(ExternalLogin), model);
        }

       


        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin"});
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
