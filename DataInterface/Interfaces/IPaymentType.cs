using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DataInterface.Interfaces
{
    public class IPaymentType : Models.PaymentType
    {
        private DataOpt.MSSQLConnection _sqlConn;

        public IPaymentType()
        {
            _sqlConn = new DataOpt.MSSQLConnection(Directory.ConnectionStrings.testing);
        }

        public IPaymentType(string connectionstring)
        {
            _sqlConn = new DataOpt.MSSQLConnection(connectionstring);
        }

        // for result validation variables
        public string status;
        public string message;

        public List<IPaymentType> List(string searchParam)
        {
            List<IPaymentType> result = new List<IPaymentType>();
            List<DbParameter> parameters = new List<DbParameter>();
            if(searchParam == null)
            {
                searchParam = "";
            }
            parameters.Add(_sqlConn.GetParameter("search", searchParam));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_PaymentType, parameters, System.Data.CommandType.StoredProcedure))
                {

                    while (dataReader.Read())
                    {
                        IPaymentType item = new IPaymentType();
                        item.PaymentTypeID = dataReader["PaymentTypeID"].ToString();
                        item.PaymentTypeName = dataReader["PaymentTypeName"].ToString();
                        item.PaymentAccount = dataReader["PaymentAccount"].ToString();
                        item.PaymentCollect = dataReader["PaymentCollect"].ToString();

                        item.vw_PaymentAccount = "Shipper";
                        item.vw_PaymentCollect = "Bill On Delivery";
                         if (dataReader["PaymentAccount"].ToString() == "1")
                        {
                            item.vw_PaymentAccount = "Consignee";
                        }

                        if (dataReader["PaymentCollect"].ToString() == "1")
                        {
                            item.vw_PaymentCollect = "Bill on Shipment";
                        }

                        if (dataReader["PaymentCollect"].ToString() == "2")
                        {
                            item.vw_PaymentCollect = "Collect on Shipment";
                        }

                        if (dataReader["PaymentCollect"].ToString() == "3")
                        {
                            item.vw_PaymentCollect = "Collect on Delivery";
                        }
                        result.Add(item);
                    }

                    
                    return result;

                }


            }
            catch (Exception ex)
            {
                this.status = "Error on IPaymentType List";
                this.message = ex.Message.ToString();
                result.Add(this);
                return result;

            }

        }

        public IPaymentType GetBranch(string searchParam)
        {
            List<IPaymentType> result = new List<IPaymentType>();
            List<DbParameter> parameters = new List<DbParameter>();
            if (searchParam == null)
            {
                searchParam = "";
            }
            parameters.Add(_sqlConn.GetParameter("getid", searchParam));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_PaymentType, parameters, System.Data.CommandType.StoredProcedure))
                {

                    while (dataReader.Read())
                    {
                        IPaymentType item = new IPaymentType();
                        item.PaymentTypeID = dataReader["PaymentTypeID"].ToString();
                        item.PaymentTypeName = dataReader["PaymentTypeName"].ToString();
                        item.PaymentAccount = dataReader["PaymentAccount"].ToString();
                        item.PaymentCollect = dataReader["PaymentCollect"].ToString();

                        item.vw_PaymentAccount = "Shipper";
                        item.vw_PaymentCollect = "On Delivery";
                        if (dataReader["PaymentAccount"].ToString() == "1")
                        {
                            item.vw_PaymentAccount = "Consignee";
                        }

                        if (dataReader["PaymentCollect"].ToString() == "1")
                        {
                            item.vw_PaymentCollect = "Prepaid";
                        }

                        return item;
                    }


                    return new IPaymentType();
                }


            }
            catch (Exception ex)
            {
                this.status = "Error on IPaymentType Get";
                this.message = ex.Message.ToString();
                return this;

            }

        }


        public string create(Models.PaymentType param) {

            List<IPaymentType> result = new List<IPaymentType>();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("PaymentTypeID", null));
            parameters.Add(_sqlConn.GetParameter("PaymentTypeName", param.PaymentTypeName));
            parameters.Add(_sqlConn.GetParameter("PaymentAccount", param.PaymentAccount));
            parameters.Add(_sqlConn.GetParameter("PaymentCollect", param.PaymentCollect));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_PaymentType, parameters, System.Data.CommandType.StoredProcedure))
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

        public string update(Models.PaymentType param) {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("PaymentTypeID", param.PaymentTypeID));
            parameters.Add(_sqlConn.GetParameter("PaymentTypeName", param.PaymentTypeName));
            parameters.Add(_sqlConn.GetParameter("PaymentAccount", param.PaymentAccount));
            parameters.Add(_sqlConn.GetParameter("PaymentCollect", param.PaymentCollect));
            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_PaymentType, parameters, System.Data.CommandType.StoredProcedure))
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
        
        public string remove(string BranchID) {

            List<IPaymentType> result = new List<IPaymentType>();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("PaymentTypeID", BranchID));
            parameters.Add(_sqlConn.GetParameter("@disable", "1"));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_PaymentType, parameters, System.Data.CommandType.StoredProcedure))
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
