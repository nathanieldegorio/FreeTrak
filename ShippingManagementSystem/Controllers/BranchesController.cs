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
    public class BranchesController : Controller
    {
        // GET: api/values
        [HttpPost("List")]
        public IEnumerable<IBranch> List(string search)
        {
            return new IBranch().List(search);
        }

        [HttpPost("Create")]
        public string Create(Dictionary<string, string> parameters)
        {
            DataInterface.Models.Branch br = new DataInterface.Models.Branch();
            br.Address = parameters["Address"];
            br.BranchID = parameters["BranchID"];
            br.BranchCode = parameters["BranchCode"];
            br.BranchName = parameters["BranchName"];
            br.ParentBranch = parameters["ParentBranch"];

            if(br.BranchID == null || br.BranchID=="New" || br.BranchID == "")
            {
                return new IBranch().create(br);
            }else
            {
                return new IBranch().update(br);
            }
          
        }

        [HttpPost("Get")]
        public IBranch Get(string id)
        {
            return new IBranch().GetBranch(id);
        }

        

        [HttpPost("Remove")]
        public string Remove(Dictionary<string, string> parameters)
        {
            return new IBranch().remove(parameters["BranchID"]);
        }


    }
}
