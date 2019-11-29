using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TheWorldTree.Controllers
{
    /// <summary>
    /// 获取IP地址
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class IPAddressController : ControllerBase
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        
        public IPAddressController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Content(this.httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString());
        }
    }
}