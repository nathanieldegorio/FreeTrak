using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataInterface.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShippingManagementSystem.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        // GET: api/values
        [HttpPost("List")]
        public IEnumerable<ICustomerProfile> List(string search)
        {
            return new ICustomerProfile().List(search);
        }

        [HttpPost("Create")]
        public string Create(Dictionary<string, string> parameters)
        {
            DataInterface.Models.CustomerProfile br = new DataInterface.Models.CustomerProfile();
            br.CustomerProfileID = parameters["CustomerProfileID"];
            br.Firstname = parameters["Firstname"];
            br.f_Lastname = parameters["f_Lastname"];
            br.Company = parameters["Company"];
            br.Address = parameters["Address"];
            br.CityBranch = parameters["CityBranch"];
            br.HomePhone = parameters["HomePhone"];
            br.OfficePhone = parameters["OfficePhone"];
            br.Email = parameters["Email"];
            br.PriorityClient = parameters["PriorityClient"];
            br.gender = parameters["gender"];

            if (br.CustomerProfileID == null || br.CustomerProfileID == "New" || br.CustomerProfileID == "")
            {
                return new ICustomerProfile().create(br);
            }
            else
            {
                return new ICustomerProfile().update(br);
            }

        }

        [HttpPost("Get")]
        public ICustomerProfile Get(string id)
        {
            return new ICustomerProfile().GetCustomerProfile(id);
        }



        [HttpPost("Remove")]
        public string Remove(Dictionary<string, string> parameters)
        {
            return new ICustomerProfile().remove(parameters["CustomerProfileID"]);
        }
    }
}
