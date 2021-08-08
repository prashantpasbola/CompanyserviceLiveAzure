using companyservice.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace companyservice.Controllers
{
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/v1.0/market/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        public AuthController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;

        }

         

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public LoggedinUser Authenticate([FromBody] UserCred userCred)
        {
            LoggedinUser loggedinUser = new LoggedinUser();
          var token=  jwtAuthenticationManager.Authenticate(userCred.username, userCred.password);
            if (token == null)
                return loggedinUser;
            else
                loggedinUser.access_token = token;
            return loggedinUser;
        }
    }

}
