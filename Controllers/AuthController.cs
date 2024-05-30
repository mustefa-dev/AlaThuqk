using AlaThuqk.DATA.DTOs.User;
using AlaThuqk.Services;
using Gaz_BackEnd.DATA.DTOs.Otp;
using Gaz_BackEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlaThuqk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class AuthController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IOtpService _OtpServices;
        public AuthController(IUserService userService, IOtpService otpServices) {
            _userService = userService;
            _OtpServices = otpServices;
        }
        
        [HttpPost("/api/Login")]
        public async Task<ActionResult> Login(LoginForm loginForm) => Ok(await _userService.Login(loginForm));
        [HttpPost("/api/AddUser")]
        public async Task<ActionResult> AddUser(UserForm userForm) => Ok(await _userService.AddUser(userForm));
        [HttpPost("/api/Register")]
        public async Task<ActionResult> Register(RegisterForm registerForm) => Ok(await _userService.Register(registerForm));
        [HttpGet("/api/User")]
        public async Task<ActionResult> GetUsers(int pageNumber = 1) => Ok(await _userService.GetUsers(pageNumber),pageNumber);
        [HttpGet("/api/User/{id}")]
        public async Task<ActionResult> GetUser(Guid id) => OkObject(await _userService.GetUserById(id));
        [HttpPut("/api/User/{id}")]
        public async Task<ActionResult> UpdateUser(UpdateUserForm updateUserForm, Guid id) => Ok(await _userService.UpdateUser(updateUserForm,id));
        [HttpDelete("/api/User/{id}")]
        public async Task<ActionResult> DeleteUser(Guid id) => Ok(await _userService.DeleteUser(id));
        [Authorize]
        [HttpGet("/api/MyProfile")]
        public async Task<ActionResult> MyProfile() => Ok(_userService.GetMyProfile(Id));
        [HttpPost("/api/SendOtp")]
        public async Task<ActionResult> SendOtp(SendSmsForm sendSmsForm) => Ok(await _OtpServices.SendOtp(sendSmsForm));

        [HttpPost("/api/VerifyOtp")]
        public async Task<ActionResult> VerifyOtp(VerifyForm verifyForm) =>
            Ok(await _OtpServices.VerifyOtp(verifyForm));
    }        

    
}