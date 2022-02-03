using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAPI.Data;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserDbContext _context;
        public LoginController(UserDbContext userDbContext)
        {
            _context = userDbContext;
        }
        

        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var userdetails = _context.userModels.AsQueryable();
            return Ok(userdetails);
        }
        
        
        [HttpPost("signup")]
        public IActionResult SigbUp([FromBody] UserModel userObj)
        {
            if(userObj == null)
            {
                return BadRequest();
            }
            else
            {
                _context.userModels.Add(userObj);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "User Added Successfully"
                });
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserModel userObj)
        {
            if(userObj == null)
            {
                return BadRequest();
            }
            else
            {
                var user = _context.userModels.Where(a =>
                a.UserName == userObj.UserName
                && a.Passwords == userObj.Passwords).FirstOrDefault();
                if(user != null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Logged In Successfully",
                        UserData = userObj.FullName
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "User Not Found"
                    });
                }
            }
        }
    }
}
