using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCS.DAL.Data;
using SCS.DAL.Entites;

namespace SCS.Api.Controllers
{
    public class NotificationDto
    {

        public int UserId { get; set; }

        public string NotificationTitle { get; set; } = null!;

        public string? NotificationText { get; set; }

        public string? NotificationImagePath { get; set; }

        public DateOnly NotificationDate { get; set; }
        public List<int> RoleIds { get; set; }
        public int sublectclassId { get; set; }
        public int classId { get; set; }
        //public string rolename { get; set; }


    }

    public class ApiResponse
    {
        public object Data { get; set; }
        public object Erorrs { get; set; }
        public string StatusCode { get; set; }

    }


    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        //inject the AppDbContext
        private readonly AppDbContext _context;
        public NotificationsController(AppDbContext context)
        {
            _context = context;
        }

        //create post method create notification in database
        [HttpPost]
        public IActionResult Post(NotificationDto notificationdto)
        {
            try
            {
                //create new notification
                Notification notification = new Notification
                {
                    UserId = notificationdto.UserId,
                    NotificationTitle = notificationdto.NotificationTitle,
                    NotificationText = notificationdto.NotificationText,
                    NotificationImagePath = notificationdto.NotificationImagePath,
                    NotificationDate = notificationdto.NotificationDate
                };
                //add notification to database
                _context.Notifications.Add(notification);
                _context.SaveChanges();
                //get the notification id
                int notificationId = notification.NotificationId;
                int subjectClassId = notificationdto.sublectclassId;
                int classId = notificationdto.classId;
                //loop through the role ids
                foreach (var roleId in notificationdto.RoleIds)
                {
                    //create new notification role
                    NotificationRole notificationRole = new NotificationRole
                    {
                        NotificationId = notificationId,
                        RoleId = roleId,
                        //NotificationRoleName = notificationdto.rolename
                        
                    };
                    //add notification role to database
                    _context.NotificationRoles.Add(notificationRole);
                    _context.SaveChanges();
                    TeacherNotification teacherNotification = new TeacherNotification
                    {
                        NotificationId = notificationId,
                        SubjectClassId = subjectClassId,

                    };
                    _context.TeacherNotifications.Add(teacherNotification);
                    _context.SaveChanges();
                    //SubervisorNotification subervisorNotification = new SubervisorNotification
                    //{
                    //    NotificationId = notificationId,
                    //    ClassId = classId
                    //};
                    //_context.SubervisorNotifications.Add(subervisorNotification);
                    //_context.SaveChanges();
                }
                return Ok("Notification created successfully");
            }
            catch (System.Exception ex)
            {
                //Console.WriteLine($"Error saving notification: {ex.Message}");
                //Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");

                //return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.InnerException?.Message });
                string? statusCode = StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message }).ToString();
                string? erorr = ex.Message;
                ApiResponse apiResponse = new ApiResponse { Data = null, Erorrs = erorr, StatusCode = statusCode };
                return Ok(apiResponse);
            }

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var notifications = _context.Notifications.ToList();
                return Ok(notifications);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet("teachernoti")]
        public IActionResult GetTeacherNotification()
        {
            try
            {
                //var notifications = _context.TeacherNotifications.ToList();
                //return Ok(notifications);
                var notifications = _context.TeacherNotifications
                    .Join(_context.Notifications,
                         tn => tn.NotificationId,
                         n => n.NotificationId,
                         (tn, n) => new
                         {
                             tn.NotificationId,
                             tn.SubjectClassId,
                             n.NotificationTitle,
                             n.NotificationText,
                             n.NotificationImagePath,
                             n.NotificationDate
                         }).ToList();
                return Ok(notifications);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet("ClassNotifications")]
        public IActionResult GetClassNotification()
        {
            try
            {
                //var notifications = _context.TeacherNotifications.ToList();
                //return Ok(notifications);
                var notifications = _context.SubervisorNotifications
                    .Join(_context.Notifications,
                         sn => sn.NotificationId,
                         n => n.NotificationId,
                         (sn, n) => new
                         {
                            sn.NotificationId,
                            sn.ClassId,
                            n.NotificationTitle,
                            n.NotificationText,
                            n.NotificationImagePath,
                            n.NotificationDate
                        }).ToList();
                return Ok(notifications);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        //use this method to get the notification with the response from the class
        //public class ApiResponse
        //public object Data { get; set; }
        //public object Erorrs { get; set; }
        //public string StatusCode { get; set; }
        [HttpGet("NotificationResponse")]
        public IActionResult GetNotificationResponse()
        {
            try
            {
                var notifications = _context.Notifications
                    .Join(_context.NotificationRoles,
                             n => n.NotificationId,
                             nr => nr.NotificationId,
                             (n, nr) => new
                             {
                             n.NotificationId,
                             n.UserId,
                             n.NotificationTitle,
                             n.NotificationText,
                             n.NotificationImagePath,
                             n.NotificationDate,
                             nr.RoleId,
                             nr.NotificationRoleName
                         }).ToList();
                return Ok(new ApiResponse { Data = notifications, Erorrs = null, StatusCode = "200" });
            }
            catch (System.Exception ex)
            {
                string? statusCode = StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message }).ToString();
                string? erorr = ex.Message;
                ApiResponse apiResponse = new ApiResponse { Data = null, Erorrs = erorr, StatusCode = statusCode };
                return Ok(apiResponse);
            }
        }   


    }
}
