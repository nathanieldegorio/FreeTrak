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
    public class AdministrationController : Controller
    {
       
        // POST api/values
        [HttpPost("Designations/list")]
        public IEnumerable<IUserDesignation> Post(string search)
        {
            return new IUserDesignation().List(search);
        }

        [HttpPost("Designations/Remove")]
        public string Remove(Dictionary<string, string> parameters)
        {
            return new IUserDesignation().remove(parameters["UserDesignationID"]);
        }

        [HttpPost("Designations/Create")]
        public string Create(Dictionary<string, string> parameters)
        {
            DataInterface.Models.UserDesignation br = new DataInterface.Models.UserDesignation();
            br.UserDesignationCode = parameters["userDesignationCode"];
            br.UserDesignationID = parameters["userDesignationID"];
            br.Description = parameters["userDesignationDescription"];
            br.isAir = parameters["isAir"];
            br.isSea = parameters["isSea"];

            if (br.UserDesignationID == null || br.UserDesignationID == "New" || br.UserDesignationID == "")
            {
                br.UserDesignationID = "";
                return new IUserDesignation().create(br);
            }
            else
            {
                return new IUserDesignation().update(br);
            }

        }

        [HttpPost("Designations/Get")]
        public IUserDesignation Get(string id)
        {
            return new IUserDesignation().GetBranch(id);
        }


        //Payment Types
        // POST api/values
        [HttpPost("PaymentType/list")]
        public IEnumerable<IPaymentType> PaymentTypeList(string search)
        {
            return new IPaymentType().List(search);
        }

        [HttpPost("PaymentType/Remove")]
        public string PaymentTypeRemove(Dictionary<string, string> parameters)
        {
            return new IPaymentType().remove(parameters["PaymentTypeID"]);
        }

        [HttpPost("PaymentType/Create")]
        public string PaymentTypeCreate(Dictionary<string, string> parameters)
        {
            DataInterface.Models.PaymentType br = new DataInterface.Models.PaymentType();
            br.PaymentTypeID = parameters["PaymentTypeID"];
            br.PaymentTypeName = parameters["PaymentTypeName"];
            br.PaymentAccount = parameters["PaymentAccount"];
            br.PaymentCollect = parameters["PaymentCollect"];

            if (br.PaymentTypeID == null || br.PaymentTypeID == "New" || br.PaymentTypeID == "")
            {
                br.PaymentTypeID = "";
                return new IPaymentType().create(br);
            }
            else
            {
                return new IPaymentType().update(br);
            }

        }

        [HttpPost("PaymentType/Get")]
        public IPaymentType PaymentTypeGet(string id)
        {
            return new IPaymentType().GetBranch(id);
        }


        //Collection Types
        // POST api/values
        [HttpPost("CollectionType/list")]
        public IEnumerable<ICollectionType> CollectionTypeList(string search)
        {
            return new ICollectionType().List(search);
        }

        [HttpPost("CollectionType/Remove")]
        public string CollectionTypeRemove(Dictionary<string, string> parameters)
        {
            return new ICollectionType().remove(parameters["CollectionTypeID"]);
        }

        [HttpPost("CollectionType/Create")]
        public string CollectionTypeCreate(Dictionary<string, string> parameters)
        {
            DataInterface.Models.CollectionType br = new DataInterface.Models.CollectionType();
            br.CollectionTypeID = parameters["CollectionTypeID"];
            br.CollectionTypeName = parameters["CollectionTypeName"];
            br.CollectionTypeDelay = parameters["CollectionTypeDelay"];
       
            if (br.CollectionTypeID == null || br.CollectionTypeID == "New" || br.CollectionTypeID == "")
            {
                br.CollectionTypeID = "";
                return new ICollectionType().create(br);
            }
            else
            {
                return new ICollectionType().update(br);
            }

        }

        [HttpPost("CollectionType/Get")]
        public ICollectionType CollectionTypeGet(string id)
        {
            return new ICollectionType().GetBranch(id);
        }

        //Cargo Types
        // POST api/values
        [HttpPost("CargoUnit/list")]
        public IEnumerable<ICargoUnit> CargoUnitList(string search)
        {
            return new ICargoUnit().List(search);
        }

        [HttpPost("CargoUnit/Remove")]
        public string CargoUnitRemove(Dictionary<string, string> parameters)
        {
            return new ICargoUnit().remove(parameters["CargoUnitID"]);
        }

        [HttpPost("CargoUnit/Create")]
        public string CargoUnitCreate(Dictionary<string, string> parameters)
        {
            DataInterface.Models.CargoUnit br = new DataInterface.Models.CargoUnit();
            br.CargoUnitID = parameters["CargoUnitID"];
            br.CargoUnitName = parameters["CargoUnitName"];
        
            if (br.CargoUnitID == null || br.CargoUnitID == "New" || br.CargoUnitID == "")
            {
                br.CargoUnitID = "";
                return new ICargoUnit().create(br);
            }
            else
            {
                return new ICargoUnit().update(br);
            }

        }

        [HttpPost("CargoUnit/Get")]
        public ICargoUnit CargoUnitGet(string id)
        {
            return new ICargoUnit().GetBranch(id);
        }


    }
}
