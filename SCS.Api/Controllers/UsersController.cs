using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCS.BLL;
using SCS.BLL.UnitOfWork;
using SCS.DAL.Data;
using SCS.DAL.Entites;
using System.Collections.Generic;

namespace SCS.Api.Controllers
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string RoleId { get; set; }

        public string UserName { get; set; } = null!;
    }

    public class SubjectClassDetails
    {
        public int SubjectClassId { get; set; }

        public string SubjectName { get; set; }

        public string LevelName { get; set; }
        public string ClassName { get; set; }
    }
     

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //inject the UnitOfWork

        //private readonly IUnitOfWork _unitOfWork;
        //public UsersController(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    try
        //    {
        //        var users = _unitOfWork.Users.GetAll();
        //        return Ok(users);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
        //    }
        //}
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    try
        //    {
        //        var user = _unitOfWork.Users.GetById(id);
        //        return Ok(user);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
        //    }
        //}



        //create action method to get the user where the role is student
        //

        //inject the AppDbContext
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }
        //create action method to get the user where the role is
        //create action method to get the user where the role is student
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var users = _context.Users.Where(u => u.Role.RoleName == "Student").ToList();
                var x = users.Select(u => new UserDto
                {
                    UserId = u.UserId,
                    RoleId = u.Role.RoleName,
                    UserName = u.UserName
                });
                return Ok( new Respons<UserDto>((UserDto?)x,"sgdsjgdj"));
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }


        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetUserWithRole(int id)
        //{
        //    try
        //    {
        //        var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.UserId == id);

        //        if (user == null)
        //        {
        //            return NotFound();
        //        }

        //        // Return an anonymous object with user properties and role name
        //        return Ok(new
        //        {
        //            UserId = user.UserId,
        //            UserName = user.UserName,
        //            Usernumber = user.Usernumber,
        //            UserImage = user.UserImage,
        //            RoleName = user.Role?.RoleName
        //        });
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
        //    }
        //}



        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SubjectClass>>> GetSubjectClassesByTeacher(int id)
        {
            List<string> names = new List<string>();
            names.Add("John");

            try
            {
                var user = await _context.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();

                if (user == null)
                {
                    return NotFound();
                }

                var subjectClasses = await _context.SubjectClasses
                    .Where(sc => sc.SubjectTeacher == id)
                    .Select(sc => new SubjectClassDetails
                    {
                        SubjectClassId = sc.SubjectClassId,
                        SubjectName = sc.Subject.SubjectName,
                        LevelName = sc.Subject.Level.LevelName,
                        ClassName = sc.Class.ClassName
                    })
                    .ToListAsync();

                return Ok(subjectClasses);
            }
            catch (System.Exception ex)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
                return Ok(names);
            }
        }






    }
}





