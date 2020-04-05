using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.ViewModels.DataTransferObjects;
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

            return RedirectToAction("");
        }
    }
}