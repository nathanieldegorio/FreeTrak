using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DataInterface.Interfaces
{
    public class ISeaShipment : Models.SeaShipment
    {
        private DataOpt.MSSQLConnection _sqlConn;

        public ISeaShipment()
        {
            _sqlConn = new DataOpt.MSSQLConnection(Directory.ConnectionStrings.testing);
        }

        public ISeaShipment(string connectionstring)
        {
            _sqlConn = new DataOpt.MSSQLConnection(connectionstring);
        }

        // for result validation variables
        public string status;
        public string message;

        public List<ISeaShipment> List(string searchParam)
        {
            List<ISeaShipment> result = new List<ISeaShipment>();
            List<DbParameter> parameters = new List<DbParameter>();
            if(searchParam == null)
            {
                searchParam = " ";
            }
            
            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_SeaShipments, parameters, System.Data.CommandType.StoredProcedure))
                {

                    while (dataReader.Read())
                    {
                        ISeaShipment item = new ISeaShipment();
                        item.TrackingNo = dataReader["TrackingNo"].ToString();
                        item.OriginBranch = dataReader["OriginBranch"].ToString();
                        item.DestinationBranch = dataReader["DestinationBranch"].ToString();
                        item.vw_OriginBranch = dataReader["vw_OriginBranch"].ToString();
                        item.createdon = dataReader["createdon"].ToString();
                        item.vw_DestinationBranch = dataReader["vw_DestinationBranch"].ToString();
                        item.ConFirstname = dataReader["ConFirstname"].ToString();
                        item.ConLastname = dataReader["ConLastname"].ToString();
                        item.ConAddress = dataReader["ConAddress"].ToString();
                        item.ConCompany = dataReader["ConCompany"].ToString();
                        item.WaybillNo = dataReader["WaybillNo"].ToString();
                        item.PRNo = dataReader["PRNo"].ToString();
                        item.TotalGrossCharge = dataReader["TotalGrossCharge"].ToString();
                        item.EVAT = dataReader["EVAT"].ToString();
                        item.DimensionCharge = dataReader["DimensionCharge"].ToString();
                        item.WeigthCharge = dataReader["WeigthCharge"].ToString();
                        item.ValueCharge = dataReader["ValueCharge"].ToString();
                        item.PickupCharge = dataReader["PickupCharge"].ToString();
                        item.PaymentType = dataReader["PaymentType"].ToString();
                        item.DeliveryCharge = dataReader["DeliveryCharge"].ToString();
                        item.Discount = dataReader["Discount"].ToString();
                        item.Adjustment = dataReader["Adjustment"].ToString();
                        item.TotalNetCharge = dataReader["TotalNetCharge"].ToString();
                        item.TrackingStatus = dataReader["TrackingStatus"].ToString();
                        item.createdby = dataReader["createdby"].ToString();
                        item.shipper = dataReader["Shipper"].ToString();
                        item.vw_shipper = dataReader["vw_Shipper"].ToString();
                        item.createdby = dataReader["createdby"].ToString();

                        result.Add(item);
                    }

                    
                    return result;

                }


            }
            catch (Exception ex)
            {
                this.status = "Error on ISeaShipment List";
                this.message = ex.Message.ToString();
                result.Add(this);
                return result;

            }

        }

       
        public ISeaShipment GetSeaShipment(string searchParam)
        {
            List<ISeaShipment> result = new List<ISeaShipment>();
            List<DbParameter> parameters = new List<DbParameter>();
            if (searchParam == null)
            {
                searchParam = "";
            }
       
            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_SeaShipments, parameters, System.Data.CommandType.StoredProcedure))
                {

                    while (dataReader.Read())
                    {
                        ISeaShipment item = new ISeaShipment();
                        item.TrackingNo = dataReader["TrackingNo"].ToString();
                        item.OriginBranch = dataReader["OriginBranch"].ToString();
                        item.createdon = dataReader["createdon"].ToString();
                        item.DestinationBranch = dataReader["DestinationBranch"].ToString();
                        item.vw_OriginBranch = dataReader["vw_OriginBranch"].ToString();
                        item.vw_DestinationBranch = dataReader["vw_DestinationBranch"].ToString();
                        item.ConFirstname = dataReader["ConFirstname"].ToString();
                        item.ConLastname = dataReader["ConLastname"].ToString();
                        item.ConAddress = dataReader["ConAddress"].ToString();
                        item.ConCompany = dataReader["ConCompany"].ToString();
                        item.WaybillNo = dataReader["WaybillNo"].ToString();
                        item.PRNo = dataReader["PRNo"].ToString();
                        item.TotalGrossCharge = dataReader["TotalGrossCharge"].ToString();
                        item.EVAT = dataReader["EVAT"].ToString();
                        item.DimensionCharge = dataReader["DimensionCharge"].ToString();
                        item.WeigthCharge = dataReader["WeigthCharge"].ToString();
                        item.ValueCharge = dataReader["ValueCharge"].ToString();
                        item.PickupCharge = dataReader["PickupCharge"].ToString();
                        item.PaymentType = dataReader["PaymentType"].ToString();
                        item.DeliveryCharge = dataReader["DeliveryCharge"].ToString();
                        item.Discount = dataReader["Discount"].ToString();
                        item.Adjustment = dataReader["Adjustment"].ToString();
                        item.TotalNetCharge = dataReader["TotalNetCharge"].ToString();
                        item.TrackingStatus = dataReader["TrackingStatus"].ToString();
                        item.createdby = dataReader["createdby"].ToString();
                        item.shipper = dataReader["Shipper"].ToString();
                        item.vw_shipper = dataReader["vw_Shipper"].ToString();
                        return item;
                    }


                    return new ISeaShipment();
                }


            }
            catch (Exception ex)
            {
                this.status = "Error on ISeaShipment Get";
                this.message = ex.Message.ToString();
                return this;

            }

        }


        public string create(Models.SeaShipment param) {

            List<ISeaShipment> result = new List<ISeaShipment>();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("@TrackingNo", 0));
            parameters.Add(_sqlConn.GetParameter("@OriginBranch", param.OriginBranch));
            parameters.Add(_sqlConn.GetParameter("@DestinationBranch", param.DestinationBranch));
            parameters.Add(_sqlConn.GetParameter("@ConFirstname", param.ConFirstname));
            parameters.Add(_sqlConn.GetParameter("@ConLastname", param.ConLastname));
            parameters.Add(_sqlConn.GetParameter("@ConAddress", param.ConAddress));
            parameters.Add(_sqlConn.GetParameter("@ConCompany", param.ConCompany));
            parameters.Add(_sqlConn.GetParameter("@WaybillNo", param.WaybillNo));
            parameters.Add(_sqlConn.GetParameter("@PRNo", param.PRNo));
            parameters.Add(_sqlConn.GetParameter("@TotalGrossCharge", param.TotalGrossCharge));
            parameters.Add(_sqlConn.GetParameter("@EVAT", param.EVAT));
            parameters.Add(_sqlConn.GetParameter("@DimensionCharge", param.DimensionCharge));
            parameters.Add(_sqlConn.GetParameter("@WeigthCharge", param.WeigthCharge));
            parameters.Add(_sqlConn.GetParameter("@ValueCharge", param.ValueCharge));
            parameters.Add(_sqlConn.GetParameter("@PickupCharge", param.PickupCharge));
            parameters.Add(_sqlConn.GetParameter("@PaymentType", param.PaymentType));
            parameters.Add(_sqlConn.GetParameter("@DeliveryCharge", param.DeliveryCharge));
            parameters.Add(_sqlConn.GetParameter("@Discount", param.Discount));
            parameters.Add(_sqlConn.GetParameter("@Adjustment", param.Adjustment));
            parameters.Add(_sqlConn.GetParameter("@TotalNetCharge", param.TotalNetCharge));
            parameters.Add(_sqlConn.GetParameter("@TrackingStatus", param.TrackingStatus));
            parameters.Add(_sqlConn.GetParameter("@Shipper", param.shipper));

            parameters.Add(_sqlConn.GetParameter("@createdby", param.createdby));




            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_SeaShipments, parameters, System.Data.CommandType.StoredProcedure))
                {

                    while (dataReader.Read())
                    {
                        return dataReader["result"].ToString();
                    }
                    
                }


            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
                
            }
            return "Module under construction";
        }

        public string update(Models.SeaShipment param) {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("@TrackingNo", param.TrackingNo));
            parameters.Add(_sqlConn.GetParameter("@OriginBranch", param.OriginBranch));
            parameters.Add(_sqlConn.GetParameter("@DestinationBranch", param.DestinationBranch));
            parameters.Add(_sqlConn.GetParameter("@ConFirstname", param.ConFirstname));
            parameters.Add(_sqlConn.GetParameter("@ConLastname", param.ConLastname));
            parameters.Add(_sqlConn.GetParameter("@ConAddress", param.ConAddress));
            parameters.Add(_sqlConn.GetParameter("@ConCompany", param.ConCompany));
            parameters.Add(_sqlConn.GetParameter("@WaybillNo", param.WaybillNo));
            parameters.Add(_sqlConn.GetParameter("@PRNo", param.PRNo));
            parameters.Add(_sqlConn.GetParameter("@TotalGrossCharge", param.TotalGrossCharge));
            parameters.Add(_sqlConn.GetParameter("@EVAT", param.EVAT));
            parameters.Add(_sqlConn.GetParameter("@DimensionCharge", param.DimensionCharge));
            parameters.Add(_sqlConn.GetParameter("@WeigthCharge", param.WeigthCharge));
            parameters.Add(_sqlConn.GetParameter("@ValueCharge", param.ValueCharge));
            parameters.Add(_sqlConn.GetParameter("@PickupCharge", param.PickupCharge));
            parameters.Add(_sqlConn.GetParameter("@PaymentType", param.PaymentType));
            parameters.Add(_sqlConn.GetParameter("@DeliveryCharge", param.DeliveryCharge));
            parameters.Add(_sqlConn.GetParameter("@Discount", param.Discount));
            parameters.Add(_sqlConn.GetParameter("@Adjustment", param.Adjustment));
            parameters.Add(_sqlConn.GetParameter("@TotalNetCharge", param.TotalNetCharge));
            parameters.Add(_sqlConn.GetParameter("@TrackingStatus", param.TrackingStatus));
            parameters.Add(_sqlConn.GetParameter("@createdby", param.createdby));
            parameters.Add(_sqlConn.GetParameter("@Shipper", param.shipper));


            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_SeaShipments, parameters, System.Data.CommandType.StoredProcedure))
                {

                    while (dataReader.Read())
                    {
                        return dataReader["result"].ToString();
                    }

                }


            }
            catch (Exception ex)
            {
                return ex.Message.ToString();

            }
            return "Module under construction";
        }
        
    }
}
