using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using BackEnd.Services;
using System.Collections.Generic;
using System;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{username}/{password}")]
        public object GetAuth(string username, string password)
        {
           // Console.WriteLine("******************************************************jennifer \n \n");
            return _userService.VerifyCredentials(username, password);
        }


        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return _userService.AllUsers();
        }

        /*[HttpGet]
        public ActionResult<User> GetId(string id)
        {
            return _userService.OneUser(id);
        }*/

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _userService.Create(user);
            return Ok(user);
        }

        [HttpPut]
        public ActionResult Update(User user)
        {
            _userService.Update(user.Id, user);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            _userService.Delete(id);
            return Ok();
        }

    }
}
