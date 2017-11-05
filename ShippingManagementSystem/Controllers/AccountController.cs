using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataInterface.Interfaces;
using DataInterface.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShippingManagementSystem.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        [HttpPost("Login")]
        public Account Login(Dictionary<string, string> parameters)
        {
            return new IAccount().Login(parameters["certificate"], parameters["username"], parameters["password"]);
        }

        [HttpPost("Certificate")]
        public Account Certificate(Dictionary<string, string> parameters)
        {
            return new IAccount().Certificate(parameters["owner"], parameters["username"], parameters["password"]);
        }

        [HttpPost("Notices")]
        public List<ISystemNotice> Notices(Dictionary<string, string> parameters)
        {
            return new ISystemNotice().List();
        }


    }
}
