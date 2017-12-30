using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DataInterface.Interfaces
{
    public class ICustomerProfile : Models.CustomerProfile
    {
        private DataOpt.MSSQLConnection _sqlConn;

        public ICustomerProfile()
        {
            _sqlConn = new DataOpt.MSSQLConnection(Directory.ConnectionStrings.testing);
        }

        public ICustomerProfile(string connectionstring)
        {
            _sqlConn = new DataOpt.MSSQLConnection(connectionstring);
        }

        // for result validation variables
        public string status;
        public string message;

        public List<ICustomerProfile> List(string searchParam)
        {
            List<ICustomerProfile> result = new List<ICustomerProfile>();
            List<DbParameter> parameters = new List<DbParameter>();
            if(searchParam == null)
            {
                searchParam = "";
            }
            parameters.Add(_sqlConn.GetParameter("search", searchParam));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_CustomerProfile, parameters, System.Data.CommandType.StoredProcedure))
                {

                    while (dataReader.Read())
                    {
                        ICustomerProfile item = new ICustomerProfile();
                        item.CustomerProfileID = dataReader["CustomerProfileID"].ToString();
                        item.Firstname = dataReader["Firstname"].ToString();
                        item.f_Lastname = dataReader["f_Lastname"].ToString();
                        item.Company = dataReader["Company"].ToString();
                        item.Address = dataReader["Address"].ToString();
                        item.CityBranch = dataReader["CityBranch"].ToString();
                        item.HomePhone = dataReader["HomePhone"].ToString();
                        item.OfficePhone = dataReader["OfficePhone"].ToString();
                        item.Email = dataReader["Email"].ToString();
                        item.PriorityClient = dataReader["PriorityClient"].ToString();
                        item.CurrentBalance = dataReader["CurrentBalance"].ToString();
                        item.gender = dataReader["gender"].ToString();

                        result.Add(item);
                    }

                    
                    return result;

                }


            }
            catch (Exception ex)
            {
                this.status = "Error on ICustomerProfile List";
                this.message = ex.Message.ToString();
                result.Add(this);
                return result;

            }

        }

        public ICustomerProfile GetCustomerProfile(string searchParam)
        {
            List<ICustomerProfile> result = new List<ICustomerProfile>();
            List<DbParameter> parameters = new List<DbParameter>();
            if (searchParam == null)
            {
                searchParam = "";
            }
            parameters.Add(_sqlConn.GetParameter("getid", searchParam));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_CustomerProfile, parameters, System.Data.CommandType.StoredProcedure))
                {

                    while (dataReader.Read())
                    {
                        ICustomerProfile item = new ICustomerProfile();
                        item.CustomerProfileID = dataReader["CustomerProfileID"].ToString();
                        item.Firstname = dataReader["Firstname"].ToString();
                        item.f_Lastname = dataReader["f_Lastname"].ToString();
                        item.Company = dataReader["Company"].ToString();
                        item.Address = dataReader["Address"].ToString();
                        item.CityBranch = dataReader["CityBranch"].ToString();
                        item.HomePhone = dataReader["HomePhone"].ToString();
                        item.OfficePhone = dataReader["OfficePhone"].ToString();
                        item.Email = dataReader["Email"].ToString();
                        item.PriorityClient = dataReader["PriorityClient"].ToString();
                        item.CurrentBalance = dataReader["CurrentBalance"].ToString();
                        item.gender = dataReader["gender"].ToString();
                        return item;
                    }


                    return new ICustomerProfile();
                }


            }
            catch (Exception ex)
            {
                this.status = "Error on ICustomerProfile Get";
                this.message = ex.Message.ToString();
                return this;

            }

        }


        public string create(Models.CustomerProfile param) {

            List<ICustomerProfile> result = new List<ICustomerProfile>();
            List<DbParameter> parameters = new List<DbParameter>();
            param.CustomerProfileID = Guid.NewGuid().ToString();
            parameters.Add(_sqlConn.GetParameter("CustomerProfileID", param.CustomerProfileID));
            parameters.Add(_sqlConn.GetParameter("@firstname", param.Firstname));
            parameters.Add(_sqlConn.GetParameter("@lastname", param.f_Lastname));
            parameters.Add(_sqlConn.GetParameter("@gender", param.gender));
            parameters.Add(_sqlConn.GetParameter("@email", param.Email));
            parameters.Add(_sqlConn.GetParameter("@address", param.Address));
            parameters.Add(_sqlConn.GetParameter("@company", param.Company));
            parameters.Add(_sqlConn.GetParameter("@citybranch", param.CityBranch));
            parameters.Add(_sqlConn.GetParameter("@homephone", param.HomePhone));
            parameters.Add(_sqlConn.GetParameter("@officephone", param.OfficePhone));
            parameters.Add(_sqlConn.GetParameter("@priority", param.PriorityClient));


            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_CustomerProfile, parameters, System.Data.CommandType.StoredProcedure))
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

        public string update(Models.CustomerProfile param) {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("CustomerProfileID", param.CustomerProfileID));
            parameters.Add(_sqlConn.GetParameter("@firstname", param.Firstname));
            parameters.Add(_sqlConn.GetParameter("@lastname", param.f_Lastname));
            parameters.Add(_sqlConn.GetParameter("@gender", param.gender));
            parameters.Add(_sqlConn.GetParameter("@email", param.Email));
            parameters.Add(_sqlConn.GetParameter("@address", param.Address));
            parameters.Add(_sqlConn.GetParameter("@company", param.Company));
            parameters.Add(_sqlConn.GetParameter("@citybranch", param.CityBranch));
            parameters.Add(_sqlConn.GetParameter("@homephone", param.HomePhone));
            parameters.Add(_sqlConn.GetParameter("@officephone", param.OfficePhone));
            parameters.Add(_sqlConn.GetParameter("@priority", param.PriorityClient));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_CustomerProfile, parameters, System.Data.CommandType.StoredProcedure))
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
        
        public string remove(string CustomerProfileID) {

            List<ICustomerProfile> result = new List<ICustomerProfile>();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("CustomerProfileID", CustomerProfileID));
            parameters.Add(_sqlConn.GetParameter("@disable", "1"));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_CustomerProfile, parameters, System.Data.CommandType.StoredProcedure))
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
