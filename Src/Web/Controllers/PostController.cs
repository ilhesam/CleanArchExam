using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.ViewModels.DataTransferObjects;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize]
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

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!await _postService.ExistsByIdAsync(id))
            {
                return RedirectToAction(nameof(Index));
            }

            var post = await _postService.GetByIdAsync(id);

            return View(post);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(PostAddDto postAddDto)
        {
            if (!ModelState.IsValid)
            {
                return View(postAddDto);
            }

            await _postService.AddAsync(postAddDto);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await _postService.ExistsByIdAsync(id))
            {
                return RedirectToAction(nameof(Index));
            }

            var post = await _postService.GetEditDtoByIdAsync(id);

            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostEditDto postEditDto)
        { 
            if (!ModelState.IsValid)
            {
                return View(postEditDto);
            }

            if (await _postService.ExistsByIdAsync(id))
            {
                await _postService.UpdateAsync(id, postEditDto);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> DetailsForDelete(int id)
        {
            if (!await _postService.ExistsByIdAsync(id))
            {
                return RedirectToAction(nameof(Index));
            }

            var post = await _postService.GetByIdAsync(id);

            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _postService.ExistsByIdAsync(id))
            {
                await _postService.DeleteAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}