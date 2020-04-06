using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.ViewModels.DataTransferObjects;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService<AuthorAddDto, AuthorEditDto, AuthorGetDto> _authorService;

        public AuthorController(IAuthorService<AuthorAddDto, AuthorEditDto, AuthorGetDto> authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(AuthorAddDto authorAddDto)
        {
            if (!ModelState.IsValid)
            {
                return View(authorAddDto);
            }

            await _authorService.AddAsync(authorAddDto);

            return Redirect("/");
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(AuthorLoginDto authorLoginDto)
        {
            if (!ModelState.IsValid)
            {
                return View(authorLoginDto);
            }

            if (!await _authorService.ExistsAsync(authorLoginDto))
            {
                ModelState.AddModelError(nameof(AuthorLoginDto.EmailAddress),"Email or password are incorrect");
                return View(authorLoginDto);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, authorLoginDto.EmailAddress),
                new Claim(ClaimTypes.NameIdentifier, authorLoginDto.EmailAddress)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties
            {
                IsPersistent = authorLoginDto.IsPersistent
            };

            await HttpContext.SignInAsync(principal, properties);

            return Redirect("/");
        }

        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/");
        }
    }
}