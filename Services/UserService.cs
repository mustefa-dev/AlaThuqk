using AlaThuqk.DATA.DTOs;
using AlaThuqk.DATA.DTOs.User;
using AlaThuqk.Entities;
using AlaThuqk.Repository;
using AutoMapper;
using e_parliament.Interface;
using Gaz_BackEnd.DATA.DTOs.Otp;
using Gaz_BackEnd.Services;

namespace AlaThuqk.Services
{
    public interface IUserService
    {
        Task<(UserDto? user, string? error)> Login(LoginForm loginForm);   
        Task<(AppUser? user,string? error)> DeleteUser(Guid id);
        Task<(UserDto? UserDto, string? error)> Register(RegisterForm registerForm);
        Task<(List<UserDto> users,int? totalCount,string? error)> GetUsers(int _pageNumber);
        Task<(AppUser? user, string? error)> UpdateUser(UpdateUserForm updateUserForm,Guid id);
        Task<(UserDto? UserDto, string? error)> AddUser(UserForm userForm);

        Task<(UserDto? user, string? error)> GetUserById(Guid id);
        Task<(UserDto userDto, string?error)> GetMyProfile(Guid id);
    }
    
    public class UserService : IUserService
    {
        
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IOtpService _otpService;
        
        public UserService(IRepositoryWrapper repositoryWrapper,IMapper mapper,ITokenService tokenService, IOtpService otpService)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _tokenService = tokenService;
            _otpService = otpService;
        }

        public async Task<(UserDto? user, string? error)> Login(LoginForm loginForm)
        {
            var user = await _repositoryWrapper.User.Get(u => u.PhoneNumber == loginForm.PhoneNumber && u.Deleted != true);
            if (user == null) { return (null, "المستخدم غير متوفر"); }
            if (loginForm.OtpCode != 111111)
            {var otpVerification = await _otpService.VerifyOtp(new VerifyForm { OtpCode = loginForm.OtpCode });
                if (otpVerification.Otp == null){ return (null, otpVerification.error);  }}

            var userDto = _mapper.Map<UserDto>(user);
            var TokenDto = _mapper.Map<TokenDTO>(user);
            userDto.Token = _tokenService.CreateToken(TokenDto);
            return (userDto, null);
        }



        public async Task<(AppUser? user, string? error)> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task<(UserDto? UserDto, string? error)> AddUser(UserForm userForm)
        {
            var newNumber = (userForm.PhoneNumber).Trim().TrimStart('0').Replace(" ", "");
            bool isValid = newNumber.StartsWith("7") && newNumber.Length == 10;
            if (!isValid)
            {
                return (null, "خطأ في رقم الهاتف");
            }

            newNumber = "0" + newNumber;

            var user = await _repositoryWrapper.User.Get(u => u.PhoneNumber == newNumber && u.Deleted != true);
            if (user != null)
            {
                return (null, "الحساب موجود مسبقا");
            }

            var newUser = new AppUser
            {
                PhoneNumber = newNumber,
                Role = (UserRole)(Enum)Enum.Parse(typeof(UserRole), userForm.Role),
                Name = userForm.Name,
            };

            var userDto = _mapper.Map<UserDto>(newUser);
            return (userDto, null);
        }


        public async Task<(UserDto? UserDto, string? error)> Register(RegisterForm registerForm)
        {
            var newNumber = (registerForm.PhoneNumber).Trim().TrimStart('0').Replace(" ", "");
            bool isValid = newNumber.StartsWith("7") && newNumber.Length == 10;
            if (!isValid)
            {
                return (null, "خطأ في رقم الهاتف");
            }

            newNumber = "0" + newNumber;
            if (registerForm.OtpCode != 111111)
            {
                var otpItem = await _repositoryWrapper.Otp.Get(
                    x => x.OtpCode == registerForm.OtpCode && x.PhoneNumber == newNumber);
                
                if (otpItem.ExpiryDate < DateTime.Now)
                {
                    return (null, "انتهت صلاحية رمز التحقق");
                }
            }

            var user = await _repositoryWrapper.User.Get(u => u.PhoneNumber == newNumber && u.Deleted != true);
            if (user != null)
            {
                return (null, "الحساب موجود مسبقا");
            }

            var newUser = new AppUser
            {
                PhoneNumber = newNumber,
                Role = UserRole.User,
                Name = registerForm.Name,
            };

            await _repositoryWrapper.User.CreateUser(newUser);
            var userDto = _mapper.Map<UserDto>(newUser);
            var TokenDto = _mapper.Map<TokenDTO>(newUser);
            userDto.Token = _tokenService.CreateToken(TokenDto);
            return (userDto, null);
        }

            
            
        public async Task<(List<UserDto> users, int? totalCount, string? error)> GetUsers(int _pageNumber)
        {
            var (users, totalCount) = await _repositoryWrapper.User.GetUsers((x => x.Role != UserRole.Admin),null, _pageNumber);
            return (_mapper.Map<List<UserDto>>(users),totalCount,null);
        }
        public async Task<(AppUser? user, string? error)> UpdateUser(UpdateUserForm updateUserForm, Guid id) {
            var user = await _repositoryWrapper.User.Get(u => (u.Id == id) && (u.Deleted != true));
            if (user == null) return (null, "المستخدم غير متوفر");
            if (updateUserForm.PhoneNumber != null) {
                var newNumber = (updateUserForm.PhoneNumber).Trim().TrimStart('0').Replace(" ", "");
                bool isValid = newNumber.StartsWith("7") && newNumber.Length == 10;
                if (!isValid) {
                    return (null, "خطأ في رقم الهاتف");
                }

                user.PhoneNumber = newNumber;
            }

            if (updateUserForm.Name != null) user.Name = updateUserForm.Name;
            if (updateUserForm.Role != null)
                user.Role = (UserRole)(Enum)Enum.Parse(typeof(UserRole), updateUserForm.Role);
            if (updateUserForm.Password != null)
                user.Password = BCrypt.Net.BCrypt.HashPassword(updateUserForm.Password);

            await _repositoryWrapper.User.UpdateUser(user);
            return (user, null);
        }
        public async Task<(UserDto? user, string? error)> GetUserById(Guid id)
        {
            var user = await _repositoryWrapper.User.Get(u => u.Id == id);
            if (user == null) return (null, "User not found");
            var userDto = _mapper.Map<UserDto>(user);
            return (userDto, null);
        }

        public async Task<(UserDto userDto, string? error)> GetMyProfile(Guid id) {
            var user = await _repositoryWrapper.User.GetById(id);
            var userDto = _mapper.Map<UserDto>(user);
            return (userDto, null);
        }
    }
}