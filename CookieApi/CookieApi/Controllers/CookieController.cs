using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CookieController : Controller
    {
        SqlKing SqlClass { get; set; }
        public CookieController(SqlKing sqlKing)
        {
            SqlClass = sqlKing;
        }

        [Route("/userdata/{UserName}")]
        [HttpGet]

        public async Task<CookieModel> GetUserData(string UserName)
        {
           var cookieModel = await SqlClass.GetUser(UserName);
            return cookieModel;
        }
    }
}
