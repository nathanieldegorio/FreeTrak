using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DataInterface.Interfaces
{
    public class IBranch : Models.Branch
    {
        private DataOpt.MSSQLConnection _sqlConn;

        public IBranch()
        {
            _sqlConn = new DataOpt.MSSQLConnection(Directory.ConnectionStrings.testing);
        }

        public IBranch(string connectionstring)
        {
            _sqlConn = new DataOpt.MSSQLConnection(connectionstring);
        }

        // for result validation variables
        public string status;
        public string message;

        public List<IBranch> List(string searchParam)
        {
            List<IBranch> result = new List<IBranch>();
            List<DbParameter> parameters = new List<DbParameter>();
            if(searchParam == null)
            {
                searchParam = "";
            }
            parameters.Add(_sqlConn.GetParameter("search", searchParam));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_Branch, parameters, System.Data.CommandType.StoredProcedure))
                {

                    while (dataReader.Read())
                    {
                        IBranch item = new IBranch();
                        item.BranchID = dataReader["BranchID"].ToString();
                        item.BranchCode = dataReader["u_Branchcode"].ToString();
                        item.BranchName = dataReader["u_Branchname"].ToString();
                        item.Address = dataReader["f_Address"].ToString();
                        item.ParentBranch = dataReader["r_ParentBranch"].ToString();
                        item.vw_ParentBranch = dataReader["vw_ParentBranch"].ToString();
                        result.Add(item);
                    }

                    
                    return result;

                }


            }
            catch (Exception ex)
            {
                this.status = "Error on IBranch List";
                this.message = ex.Message.ToString();
                result.Add(this);
                return result;

            }

        }

        public IBranch GetBranch(string searchParam)
        {
            List<IBranch> result = new List<IBranch>();
            List<DbParameter> parameters = new List<DbParameter>();
            if (searchParam == null)
            {
                searchParam = "";
            }
            parameters.Add(_sqlConn.GetParameter("getid", searchParam));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_Branch, parameters, System.Data.CommandType.StoredProcedure))
                {

                    while (dataReader.Read())
                    {
                        IBranch item = new IBranch();
                        item.BranchID = dataReader["BranchID"].ToString();
                        item.BranchCode = dataReader["u_Branchcode"].ToString();
                        item.BranchName = dataReader["u_Branchname"].ToString();
                        item.Address = dataReader["f_Address"].ToString();
                        item.ParentBranch = dataReader["r_ParentBranch"].ToString();
                        item.vw_ParentBranch = dataReader["vw_ParentBranch"].ToString();
                        return item;
                    }


                    return new IBranch();
                }


            }
            catch (Exception ex)
            {
                this.status = "Error on IBranch Get";
                this.message = ex.Message.ToString();
                return this;

            }

        }


        public string create(Models.Branch param) {

            List<IBranch> result = new List<IBranch>();
            List<DbParameter> parameters = new List<DbParameter>();
            param.BranchID = Guid.NewGuid().ToString();
            parameters.Add(_sqlConn.GetParameter("BranchID", param.BranchID));
            parameters.Add(_sqlConn.GetParameter("BranchCode", param.BranchCode));
            parameters.Add(_sqlConn.GetParameter("BranchName", param.BranchName));
            parameters.Add(_sqlConn.GetParameter("Address", param.Address));
            parameters.Add(_sqlConn.GetParameter("ParentBranch", param.ParentBranch));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_Branch, parameters, System.Data.CommandType.StoredProcedure))
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

        public string update(Models.Branch param) {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("BranchID", param.BranchID));
            parameters.Add(_sqlConn.GetParameter("BranchCode", param.BranchCode));
            parameters.Add(_sqlConn.GetParameter("BranchName", param.BranchName));
            parameters.Add(_sqlConn.GetParameter("Address", param.Address));
            parameters.Add(_sqlConn.GetParameter("ParentBranch", param.ParentBranch));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_Branch, parameters, System.Data.CommandType.StoredProcedure))
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

            List<IBranch> result = new List<IBranch>();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("BranchID", BranchID));
            parameters.Add(_sqlConn.GetParameter("@disable", "1"));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_Branch, parameters, System.Data.CommandType.StoredProcedure))
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
