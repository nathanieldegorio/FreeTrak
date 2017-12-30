using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DataInterface.Interfaces
{
    public class IUserDesignation : Models.UserDesignation
    {
        private DataOpt.MSSQLConnection _sqlConn;

        public IUserDesignation()
        {
            _sqlConn = new DataOpt.MSSQLConnection(Directory.ConnectionStrings.testing);
        }

        public IUserDesignation(string connectionstring)
        {
            _sqlConn = new DataOpt.MSSQLConnection(connectionstring);
        }

        // for result validation variables
        public string status;
        public string message;

        public List<IUserDesignation> List(string searchParam)
        {
            List<IUserDesignation> result = new List<IUserDesignation>();
            List<DbParameter> parameters = new List<DbParameter>();
            if(searchParam == null)
            {
                searchParam = "";
            }
            parameters.Add(_sqlConn.GetParameter("search", searchParam));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_UserDesignation, parameters, System.Data.CommandType.StoredProcedure))
                {

                    while (dataReader.Read())
                    {
                        IUserDesignation item = new IUserDesignation();
                        item.UserDesignationID = dataReader["UserDesignationID"].ToString();
                        item.UserDesignationCode = dataReader["u_UserDesignationCode"].ToString();
                        item.Description = dataReader["f_Description"].ToString();

                        item.isAir = dataReader["r_isAir"].ToString();
                        item.isSea = dataReader["r_isSea"].ToString();
                        item.vw_isAir = "Yes";
                        if (dataReader["r_isAir"].ToString() == "0")
                        {
                            item.vw_isAir = "No";
                        }
                        item.vw_isSea = "Yes";
                        if (dataReader["r_isSea"].ToString() == "0")
                        {
                            item.vw_isSea = "No";
                        }
                        result.Add(item);
                    }

                    
                    return result;

                }


            }
            catch (Exception ex)
            {
                this.status = "Error on IUSerDesignation List";
                this.message = ex.Message.ToString();
                result.Add(this);
                return result;

            }

        }

        public IUserDesignation GetBranch(string searchParam)
        {
            List<IUserDesignation> result = new List<IUserDesignation>();
            List<DbParameter> parameters = new List<DbParameter>();
            if (searchParam == null)
            {
                searchParam = "";
            }
            parameters.Add(_sqlConn.GetParameter("getid", searchParam));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_UserDesignation, parameters, System.Data.CommandType.StoredProcedure))
                {

                    while (dataReader.Read())
                    {
                        IUserDesignation item = new IUserDesignation();
                        item.UserDesignationID = dataReader["UserDesignationID"].ToString();
                        item.UserDesignationCode = dataReader["u_UserDesignationCode"].ToString();
                        item.Description = dataReader["f_Description"].ToString();

                        item.isAir = dataReader["r_isAir"].ToString();
                        item.isSea = dataReader["r_isSea"].ToString();
                        item.vw_isAir = "Yes";
                        if (dataReader["r_isAir"].ToString() == "0")
                        {
                            item.vw_isAir = "No";
                        }
                        item.vw_isSea = "Yes";
                        if (dataReader["r_isSea"].ToString() == "0")
                        {
                            item.vw_isSea = "No";
                        }

                        return item;
                    }


                    return new IUserDesignation();
                }


            }
            catch (Exception ex)
            {
                this.status = "Error on IUSerDesignation Get";
                this.message = ex.Message.ToString();
                return this;

            }

        }


        public string create(Models.UserDesignation param) {

            List<IUserDesignation> result = new List<IUserDesignation>();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("UserDesignationID", null));
            parameters.Add(_sqlConn.GetParameter("u_UserDesignationCode", param.UserDesignationCode));
            parameters.Add(_sqlConn.GetParameter("f_Description", param.Description));
            parameters.Add(_sqlConn.GetParameter("r_isAir", param.isAir));
            parameters.Add(_sqlConn.GetParameter("r_isSea", param.isSea));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_UserDesignation, parameters, System.Data.CommandType.StoredProcedure))
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

        public string update(Models.UserDesignation param) {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("UserDesignationID", param.UserDesignationID));
            parameters.Add(_sqlConn.GetParameter("u_UserDesignationCode", param.UserDesignationCode));
            parameters.Add(_sqlConn.GetParameter("f_Description", param.Description));
            parameters.Add(_sqlConn.GetParameter("r_isAir", param.isAir));
            parameters.Add(_sqlConn.GetParameter("r_isSea", param.isSea));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_UserDesignation, parameters, System.Data.CommandType.StoredProcedure))
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

            List<IUserDesignation> result = new List<IUserDesignation>();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("UserDesignationID", BranchID));
            parameters.Add(_sqlConn.GetParameter("@disable", "1"));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_UserDesignation, parameters, System.Data.CommandType.StoredProcedure))
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
