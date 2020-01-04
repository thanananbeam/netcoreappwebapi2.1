using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplicationWebapp.BusinessContext.BussinessData;
using WebApplicationWebapp.BusinessContext.BussinessModel;
using WebApplicationWebapp.Model;
using WebApplicationWebapp.Model.DBContext;
using WebApplicationWebapp.Service;

namespace WebApplicationWebapp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IConfiguration _configuration;
        private ITokenService _tokenService;
        private IBL_APIProvider _BLAPIProvider;
        private IBL_Member _BLMember;

        public AuthController(IConfiguration configuration, 
            ITokenService tokenService, IBL_APIProvider BL_APIProvider,
            IBL_Member BL_Member)
        {
            _configuration = configuration;
            _tokenService = tokenService;
            _BLAPIProvider = BL_APIProvider;
            _BLMember = BL_Member;
        }

        [AllowAnonymous]
        [HttpPost("GetToken")]
        public IActionResult GetToken([FromBody]Api_ProviderRequest user_provider)
        {
            var respond = _BLAPIProvider.getListProvider(user_provider);
            if (respond.status == "success")
            {
                respond.data = _tokenService.GenToken(respond);
                return StatusCode(200, respond);

            }else
            {
                return StatusCode(401, respond);
            }

        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody]MemberRequest user_member)
        {

            var respond = _BLMember.Login(user_member);

            if (respond.status == "success") {

                // update is login active 
                _BLMember.updateIslogin(respond, true);

                respond.data = null;
                respond.message = "Login finished";
            }

            return Ok(respond);
        }

        [HttpPost("Logout")]
        public IActionResult Logout([FromBody]MemberRequest user_member)
        {

            var respond = _BLMember.Logout(user_member);

            if (respond.status == "success")
            {
                // update is logout  
                _BLMember.updateIslogin(respond, false);

                respond.status = "success";
                respond.data = null;
                respond.message = "Logout finished";
            }

            return Ok(respond);
        }
    }
}