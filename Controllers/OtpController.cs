using AlaThuqk.Controllers;
using Gaz_BackEnd.DATA.DTOs.Otp;
using Gaz_BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gaz_BackEnd.Controllers{
    public class OtpController : BaseController{
        private readonly IOtpService _OtpServices;

        public OtpController(IOtpService OptServices) {
            _OtpServices = OptServices;
        }


    }
}