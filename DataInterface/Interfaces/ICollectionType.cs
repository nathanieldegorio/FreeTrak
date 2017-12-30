using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DataInterface.Interfaces
{
    public class ICollectionType : Models.CollectionType
    {
        private DataOpt.MSSQLConnection _sqlConn;

        public ICollectionType()
        {
            _sqlConn = new DataOpt.MSSQLConnection(Directory.ConnectionStrings.testing);
        }

        public ICollectionType(string connectionstring)
        {
            _sqlConn = new DataOpt.MSSQLConnection(connectionstring);
        }

        // for result validation variables
        public string status;
        public string message;

        public List<ICollectionType> List(string searchParam)
        {
            List<ICollectionType> result = new List<ICollectionType>();
            List<DbParameter> parameters = new List<DbParameter>();
            if(searchParam == null)
            {
                searchParam = "";
            }
            parameters.Add(_sqlConn.GetParameter("search", searchParam));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_CollectionType, parameters, System.Data.CommandType.StoredProcedure))
                {

                    while (dataReader.Read())
                    {
                        ICollectionType item = new ICollectionType();
                        item.CollectionTypeID = dataReader["CollectionTypeID"].ToString();
                        item.CollectionTypeName = dataReader["CollectionTypeName"].ToString();
                        item.CollectionTypeDelay = dataReader["CollectionTypeDelay"].ToString();
                 
                        result.Add(item);
                    }

                    
                    return result;

                }


            }
            catch (Exception ex)
            {
                this.status = "Error on ICollectionType List";
                this.message = ex.Message.ToString();
                result.Add(this);
                return result;

            }

        }

        public ICollectionType GetBranch(string searchParam)
        {
            List<ICollectionType> result = new List<ICollectionType>();
            List<DbParameter> parameters = new List<DbParameter>();
            if (searchParam == null)
            {
                searchParam = "";
            }
            parameters.Add(_sqlConn.GetParameter("getid", searchParam));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_CollectionType, parameters, System.Data.CommandType.StoredProcedure))
                {

                    while (dataReader.Read())
                    {
                        ICollectionType item = new ICollectionType();
                        item.CollectionTypeID = dataReader["CollectionTypeID"].ToString();
                        item.CollectionTypeName = dataReader["CollectionTypeName"].ToString();
                        item.CollectionTypeDelay = dataReader["CollectionTypeDelay"].ToString();

                        return item;
                    }


                    return new ICollectionType();
                }


            }
            catch (Exception ex)
            {
                this.status = "Error on ICollectionType Get";
                this.message = ex.Message.ToString();
                return this;

            }

        }


        public string create(Models.CollectionType param) {

            List<ICollectionType> result = new List<ICollectionType>();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("CollectionTypeID", null));
            parameters.Add(_sqlConn.GetParameter("CollectionTypeDelay", param.CollectionTypeDelay));
            parameters.Add(_sqlConn.GetParameter("CollectionTypeName", param.CollectionTypeName));
             try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_CollectionType, parameters, System.Data.CommandType.StoredProcedure))
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

        public string update(Models.CollectionType param) {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("CollectionTypeID", param.CollectionTypeID));
            parameters.Add(_sqlConn.GetParameter("CollectionTypeName", param.CollectionTypeName));
            parameters.Add(_sqlConn.GetParameter("CollectionTypeDelay", param.CollectionTypeDelay));
             try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_CollectionType, parameters, System.Data.CommandType.StoredProcedure))
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

            List<ICollectionType> result = new List<ICollectionType>();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("CollectionTypeID", BranchID));
            parameters.Add(_sqlConn.GetParameter("@disable", "1"));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_CollectionType, parameters, System.Data.CommandType.StoredProcedure))
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
