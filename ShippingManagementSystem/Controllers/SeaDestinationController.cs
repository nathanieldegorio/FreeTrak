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
    public class SeaDestinationController : Controller
    {
        // GET: api/values
        [HttpPost("List")]
        public IEnumerable<ISeaDestination> List(string search)
        {
            return new ISeaDestination().List(search);
        }


        [HttpPost("ListForBranch")]
        public IEnumerable<ISeaDestination> ListForBranch(string branch)
        {
            return new ISeaDestination().ListForBranch(branch);
        }

        [HttpPost("Create")]
        public string Create(Dictionary<string, string> parameters)
        {
            DataInterface.Models.SeaDestination br = new DataInterface.Models.SeaDestination();

            br.RouteID = parameters["RouteID"];
            br.RouteOrigin = parameters["RouteOrigin"];
            br.RouteDestination = parameters["RouteDestination"];
            br.DimensionCharge = parameters["DimensionCharge"];
            br.WeightCharge = parameters["WeightCharge"];
            br.ValueCharge = parameters["ValueCharge"];
            br.PickupCharge = parameters["PickupCharge"];
            br.DeliveryCharge = parameters["DeliveryCharge"];
            br.Discount = parameters["Discount"];
            br.Adjusmtent = parameters["Adjusmtent"];
            br.lastupdatedby = parameters["lastupdatedby"];
            br.createdby = parameters["lastupdatedby"];



            if (br.RouteID == null || br.RouteID == "New" || br.RouteID == "")
            {
                return new ISeaDestination().create(br);
            }
            else
            {
                return new ISeaDestination().update(br);
            }

        }

        [HttpPost("Get")]
        public ISeaDestination Get(string id)
        {
            return new ISeaDestination().GetSeaDestination(id);
        }



        [HttpPost("Remove")]
        public string Remove(Dictionary<string, string> parameters)
        {
            return new ISeaDestination().remove(parameters["RouteID"]);
        }
    }
}
