﻿using EventManagementApplication.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventManagementApplication.WebUI.ViewComponents
{
    public class Settings:ViewComponent
    {
        private readonly IUserService _userService;
        private readonly IUserDetailService _userDetailService;

        public Settings(IUserService userService, IUserDetailService userDetailService)
        {
            _userService = userService;
            _userDetailService = userDetailService;
        }

        public IViewComponentResult Invoke()
        {
          
            string email = HttpContext.Session.GetString("Email")!;

            var user = _userService.GetByMail(email!);
            var userDetail = _userDetailService.GetUserDetailByUserId(user.Id);
            ViewBag.User = user;
            return View(userDetail);
        }
    }
}
