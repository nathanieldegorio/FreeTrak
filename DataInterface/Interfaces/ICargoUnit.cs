using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DataInterface.Interfaces
{
    public class ICargoUnit : Models.CargoUnit
    {
        private DataOpt.MSSQLConnection _sqlConn;

        public ICargoUnit()
        {
            _sqlConn = new DataOpt.MSSQLConnection(Directory.ConnectionStrings.testing);
        }

        public ICargoUnit(string connectionstring)
        {
            _sqlConn = new DataOpt.MSSQLConnection(connectionstring);
        }

        // for result validation variables
        public string status;
        public string message;

        public List<ICargoUnit> List(string searchParam)
        {
            List<ICargoUnit> result = new List<ICargoUnit>();
            List<DbParameter> parameters = new List<DbParameter>();
            if(searchParam == null)
            {
                searchParam = "";
            }
            parameters.Add(_sqlConn.GetParameter("search", searchParam));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_CargoUnit, parameters, System.Data.CommandType.StoredProcedure))
                {

                    while (dataReader.Read())
                    {
                        ICargoUnit item = new ICargoUnit();
                        item.CargoUnitID = dataReader["CargoUnitID"].ToString();
                        item.CargoUnitName = dataReader["CargoUnitName"].ToString();
                   
                        result.Add(item);
                    }

                    
                    return result;

                }


            }
            catch (Exception ex)
            {
                this.status = "Error on ICargoUnit List";
                this.message = ex.Message.ToString();
                result.Add(this);
                return result;

            }

        }

        public ICargoUnit GetBranch(string searchParam)
        {
            List<ICargoUnit> result = new List<ICargoUnit>();
            List<DbParameter> parameters = new List<DbParameter>();
            if (searchParam == null)
            {
                searchParam = "";
            }
            parameters.Add(_sqlConn.GetParameter("getid", searchParam));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_CargoUnit, parameters, System.Data.CommandType.StoredProcedure))
                {

                    while (dataReader.Read())
                    {
                        ICargoUnit item = new ICargoUnit();
                        item.CargoUnitID = dataReader["CargoUnitID"].ToString();
                        item.CargoUnitName = dataReader["CargoUnitName"].ToString();
          
                        return item;
                    }


                    return new ICargoUnit();
                }


            }
            catch (Exception ex)
            {
                this.status = "Error on ICargoUnit Get";
                this.message = ex.Message.ToString();
                return this;

            }

        }


        public string create(Models.CargoUnit param) {

            List<ICargoUnit> result = new List<ICargoUnit>();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("CargoUnitID", null));
            parameters.Add(_sqlConn.GetParameter("CargoUnitName", param.CargoUnitName));
             try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_CargoUnit, parameters, System.Data.CommandType.StoredProcedure))
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

        public string update(Models.CargoUnit param) {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("CargoUnitID", param.CargoUnitID));
            parameters.Add(_sqlConn.GetParameter("CargoUnitName", param.CargoUnitName));
             try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_CargoUnit, parameters, System.Data.CommandType.StoredProcedure))
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

            List<ICargoUnit> result = new List<ICargoUnit>();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("CargoUnitID", BranchID));
            parameters.Add(_sqlConn.GetParameter("@disable", "1"));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_CargoUnit, parameters, System.Data.CommandType.StoredProcedure))
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
