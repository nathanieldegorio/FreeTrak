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
    public class SeaShipmentController : Controller
    {
        // GET: api/values
        [HttpPost("List")]
        public IEnumerable<ISeaShipment> List(string search)
        {
            return new ISeaShipment().List(search);
        }


        [HttpPost("Create")]
        public string Create(Dictionary<string, string> parameters)
        {
            DataInterface.Models.SeaShipment br = new DataInterface.Models.SeaShipment();

            br.TrackingNo = parameters["TrackingNo"].ToString();
            br.OriginBranch = parameters["OriginBranch"].ToString();
            br.DestinationBranch = parameters["DestinationBranch"].ToString();
            br.ConFirstname = parameters["ConFirstname"].ToString();
            br.ConLastname = parameters["ConLastname"].ToString();
            br.ConAddress = parameters["ConAddress"].ToString();
            br.ConCompany = parameters["ConCompany"].ToString();
            br.WaybillNo = parameters["WaybillNo"].ToString();
            br.PRNo = parameters["PRNo"].ToString();
            br.TotalGrossCharge = parameters["TotalGrossCharge"].ToString();
            br.EVAT = parameters["EVAT"].ToString();
            br.DimensionCharge = parameters["DimensionCharge"].ToString();
            br.WeigthCharge = parameters["WeigthCharge"].ToString();
            br.ValueCharge = parameters["ValueCharge"].ToString();
            br.PickupCharge = parameters["PickupCharge"].ToString();
            br.PaymentType = parameters["PaymentType"].ToString();
            br.DeliveryCharge = parameters["DeliveryCharge"].ToString();
            br.Discount = parameters["Discount"].ToString();
            br.Adjustment = parameters["Adjustment"].ToString();
            br.TotalNetCharge = parameters["TotalNetCharge"].ToString();
            br.TrackingStatus = parameters["TrackingStatus"].ToString();
            br.createdby = parameters["createdby"].ToString();



            if (br.TrackingNo == null || br.TrackingNo == "0" || br.TrackingNo == "")
            {
                return new ISeaShipment().create(br);
            }
            else
            {
                return new ISeaShipment().update(br);
            }

        }

        [HttpPost("Get")]
        public ISeaShipment Get(string id)
        {
            return new ISeaShipment().GetSeaShipment(id);
        }



    }
}
