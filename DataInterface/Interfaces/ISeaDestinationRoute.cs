using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DataInterface.Interfaces
{
    public class ISeaDestination : Models.SeaDestination
    {
        private DataOpt.MSSQLConnection _sqlConn;

        public ISeaDestination()
        {
            _sqlConn = new DataOpt.MSSQLConnection(Directory.ConnectionStrings.testing);
        }

        public ISeaDestination(string connectionstring)
        {
            _sqlConn = new DataOpt.MSSQLConnection(connectionstring);
        }

        // for result validation variables
        public string status;
        public string message;

        public List<ISeaDestination> List(string searchParam)
        {
            List<ISeaDestination> result = new List<ISeaDestination>();
            List<DbParameter> parameters = new List<DbParameter>();
            if(searchParam == null)
            {
                searchParam = " ";
            }
            parameters.Add(_sqlConn.GetParameter("search", searchParam));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_SeaDestination, parameters, System.Data.CommandType.StoredProcedure))
                {

                    while (dataReader.Read())
                    {
                        ISeaDestination item = new ISeaDestination();
                        item.RouteID = dataReader["RouteID"].ToString();
                        item.RouteOrigin = dataReader["RouteOrigin"].ToString();
                        item.vw_RouteOrigin = dataReader["vw_RouteOrigin"].ToString();
                        item.RouteDestination = dataReader["RouteDestination"].ToString();
                        item.vw_RouteDestination = dataReader["vw_RouteDestination"].ToString();
                        item.DimensionCharge = dataReader["DimensionCharge"].ToString();
                        item.WeightCharge = dataReader["WeightCharge"].ToString();
                        item.ValueCharge = dataReader["ValueCharge"].ToString();
                        item.PickupCharge = dataReader["PickupCharge"].ToString();
                        item.DeliveryCharge = dataReader["DeliveryCharge"].ToString();
                        item.Discount = dataReader["Discount"].ToString();
                        item.Adjusmtent = dataReader["Adjustment"].ToString();
                        item.lastupdatedby = dataReader["lastupdatedby"].ToString();
                        item.createdby = dataReader["createdby"].ToString();

                        result.Add(item);
                    }

                    
                    return result;

                }


            }
            catch (Exception ex)
            {
                this.status = "Error on ISeaDestination List";
                this.message = ex.Message.ToString();
                result.Add(this);
                return result;

            }

        }

        public List<ISeaDestination> ListForBranch(string searchParam)
        {
            List<ISeaDestination> result = new List<ISeaDestination>();
            List<DbParameter> parameters = new List<DbParameter>();
            if (searchParam == null)
            {
                searchParam = " ";
            }
            parameters.Add(_sqlConn.GetParameter("searchByBranch", searchParam));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_SeaDestination, parameters, System.Data.CommandType.StoredProcedure))
                {

                    while (dataReader.Read())
                    {
                        ISeaDestination item = new ISeaDestination();
                        item.RouteID = dataReader["RouteID"].ToString();
                        item.RouteOrigin = dataReader["RouteOrigin"].ToString();
                        item.vw_RouteOrigin = dataReader["vw_RouteOrigin"].ToString();
                        item.RouteDestination = dataReader["RouteDestination"].ToString();
                        item.vw_RouteDestination = dataReader["vw_RouteDestination"].ToString();
                        item.DimensionCharge = dataReader["DimensionCharge"].ToString();
                        item.WeightCharge = dataReader["WeightCharge"].ToString();
                        item.ValueCharge = dataReader["ValueCharge"].ToString();
                        item.PickupCharge = dataReader["PickupCharge"].ToString();
                        item.DeliveryCharge = dataReader["DeliveryCharge"].ToString();
                        item.Discount = dataReader["Discount"].ToString();
                        item.Adjusmtent = dataReader["Adjustment"].ToString();
                        item.lastupdatedby = dataReader["lastupdatedby"].ToString();
                        item.createdby = dataReader["createdby"].ToString();

                        result.Add(item);
                    }


                    return result;

                }


            }
            catch (Exception ex)
            {
                this.status = "Error on ISeaDestination List";
                this.message = ex.Message.ToString();
                result.Add(this);
                return result;

            }

        }



        public ISeaDestination GetSeaDestination(string searchParam)
        {
            List<ISeaDestination> result = new List<ISeaDestination>();
            List<DbParameter> parameters = new List<DbParameter>();
            if (searchParam == null)
            {
                searchParam = "";
            }
            parameters.Add(_sqlConn.GetParameter("getid", searchParam));
   
            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_SeaDestination, parameters, System.Data.CommandType.StoredProcedure))
                {

                    while (dataReader.Read())
                    {
                        ISeaDestination item = new ISeaDestination();
                        item.RouteID = dataReader["RouteID"].ToString();
                        item.RouteOrigin = dataReader["RouteOrigin"].ToString();
                        item.vw_RouteOrigin = dataReader["vw_RouteOrigin"].ToString();
                        item.RouteDestination = dataReader["RouteDestination"].ToString();
                        item.vw_RouteDestination = dataReader["vw_RouteDestination"].ToString();
                        item.DimensionCharge = dataReader["DimensionCharge"].ToString();
                        item.WeightCharge = dataReader["WeightCharge"].ToString();
                        item.ValueCharge = dataReader["ValueCharge"].ToString();
                        item.PickupCharge = dataReader["PickupCharge"].ToString();
                        item.DeliveryCharge = dataReader["DeliveryCharge"].ToString();
                        item.Discount = dataReader["Discount"].ToString();
                        item.Adjusmtent = dataReader["Adjustment"].ToString();
                        item.lastupdatedby = dataReader["lastupdatedby"].ToString();
                        item.createdby = dataReader["createdby"].ToString();
                        return item;
                    }


                    return new ISeaDestination();
                }


            }
            catch (Exception ex)
            {
                this.status = "Error on ISeaDestination Get";
                this.message = ex.Message.ToString();
                return this;

            }

        }


        public string create(Models.SeaDestination param) {

            List<ISeaDestination> result = new List<ISeaDestination>();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("@RouteOrigin", param.RouteOrigin));
            parameters.Add(_sqlConn.GetParameter("@RouteDestination", param.RouteDestination));
            parameters.Add(_sqlConn.GetParameter("@DimensionCharge", param.DimensionCharge));
            parameters.Add(_sqlConn.GetParameter("@WeightCharge", param.WeightCharge));
            parameters.Add(_sqlConn.GetParameter("@ValueCharge", param.ValueCharge));
            parameters.Add(_sqlConn.GetParameter("@PickupCharge", param.PickupCharge));
            parameters.Add(_sqlConn.GetParameter("@DeliveryCharge", param.DeliveryCharge));
            parameters.Add(_sqlConn.GetParameter("@Discount", param.Discount));
            parameters.Add(_sqlConn.GetParameter("@Adjustment", param.Adjusmtent));
            parameters.Add(_sqlConn.GetParameter("@lastupdatedby", param.lastupdatedby));
            parameters.Add(_sqlConn.GetParameter("@createdby", param.createdby));



            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_SeaDestination, parameters, System.Data.CommandType.StoredProcedure))
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

        public string update(Models.SeaDestination param) {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("@RouteID", param.RouteID));
            parameters.Add(_sqlConn.GetParameter("@RouteOrigin", param.RouteOrigin));
            parameters.Add(_sqlConn.GetParameter("@RouteDestination", param.RouteDestination));
            parameters.Add(_sqlConn.GetParameter("@DimensionCharge", param.DimensionCharge));
            parameters.Add(_sqlConn.GetParameter("@WeightCharge", param.WeightCharge));
            parameters.Add(_sqlConn.GetParameter("@ValueCharge", param.ValueCharge));
            parameters.Add(_sqlConn.GetParameter("@PickupCharge", param.PickupCharge));
            parameters.Add(_sqlConn.GetParameter("@DeliveryCharge", param.DeliveryCharge));
            parameters.Add(_sqlConn.GetParameter("@Discount", param.Discount));
            parameters.Add(_sqlConn.GetParameter("@Adjustment", param.Adjusmtent));
            parameters.Add(_sqlConn.GetParameter("@lastupdatedby", param.lastupdatedby));
            parameters.Add(_sqlConn.GetParameter("@createdby", param.createdby));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_SeaDestination, parameters, System.Data.CommandType.StoredProcedure))
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
        
        public string remove(string RouteID) {

            List<ISeaDestination> result = new List<ISeaDestination>();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("RouteID", RouteID));
            parameters.Add(_sqlConn.GetParameter("@disable", "1"));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_SeaDestination, parameters, System.Data.CommandType.StoredProcedure))
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
