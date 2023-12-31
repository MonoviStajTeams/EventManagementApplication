﻿using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailController : ControllerBase
    {
        private readonly IUserDetailService _userDetailService;

        public UserDetailController(IUserDetailService userDetailService)
        {
            _userDetailService = userDetailService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult UserDetailList()
        {
            var userDetailList = _userDetailService.GetAll();
            return Ok(userDetailList);
        }


        [HttpPost]
        [Route("Create")]
        public IActionResult AddUserDetail(UserDetail userDetail)
        {
            _userDetailService.Create(userDetail);
            return Ok();
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult UpdateUserDetail(UserDetail userDetail)
        {
            _userDetailService.Update(userDetail);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteUserDetail(int id)
        {
            _userDetailService.Delete(id);
            return Ok();
        }


        [HttpGet]
        [Route("GetUserDetailByUserId/{id}")]
        public IActionResult GetUserDetailByUserId(int id)
        {
            var userDetailList = _userDetailService.GetUserDetailByUserId(id);
            return Ok(userDetailList);
        }

    }
}
