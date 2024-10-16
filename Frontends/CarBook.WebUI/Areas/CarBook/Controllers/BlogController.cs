﻿using CarBook.Dto.BlogDtos;
using CarBook.Dto.CommentDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.CarBook.Controllers
{
    [Area("CarBook")]
    [Route("CarBook/Blog")]
    public class BlogController : Controller
    {
        private readonly IApiService<ResultGetAllBlogsWithAuthorsDto> _apiService;
        private readonly IApiService<CreateCommentDto> _createApiService;

        public BlogController(IApiService<ResultGetAllBlogsWithAuthorsDto> apiService, IApiService<CreateCommentDto> createApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Blog";
            ViewBag.v2 = "Bloglar";
            ViewBag.url = "/CarBook/Blog/Index/";
            var values = await _apiService.GetListAsync("Blogs/GetAllBlogsWithAuthorsList");
            return View(values);
        }

        [HttpGet("BlogDetail/{id}")]
        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Blog Detayı ve Yorumlar";
            ViewBag.url = "/CarBook/Blog/Index/";
            ViewBag.blogid = id;
            return View();
        }

        [HttpGet("CreateComment/{id}")]
        public PartialViewResult CreateComment(int id)
        {
            ViewBag.blogid = id;
            return PartialView();
        }

        [HttpPost("CreateComment")]
        public async Task<IActionResult> CreateComment(CreateCommentDto commentDto)
        {
            var value = await _createApiService.CreateItemAsync("Comments/", commentDto);
            if(value)
            {
                return RedirectToAction("BlogDetail", new { id = commentDto.BlogID });
            }
            return View();
        }
    }
}
