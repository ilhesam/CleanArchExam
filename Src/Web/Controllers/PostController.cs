using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.ViewModels.DataTransferObjects;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService<PostAddDto, PostEditDto, PostGetDto> _postService;

        public PostController(IPostService<PostAddDto, PostEditDto, PostGetDto> postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var posts = await _postService.ListAllAsync();

            return View(posts);
        }
    }
}