using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DataInterface.Interfaces
{
    public class ISystemNotice : Models.SystemNotice
    {
        private DataOpt.MSSQLConnection _sqlConn;

        public ISystemNotice()
        {
            _sqlConn = new DataOpt.MSSQLConnection(Directory.ConnectionStrings.testing);
        }

        public ISystemNotice(string connectionstring)
        {
            _sqlConn = new DataOpt.MSSQLConnection(connectionstring);
        }

        // for result validation variables
        public string status;
        public string message;

        public List<ISystemNotice> List()
        {
           List<ISystemNotice> result = new List<ISystemNotice>();
           List<DbParameter> parameters = new List<DbParameter>();
      
            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_SystemNotices, parameters, System.Data.CommandType.StoredProcedure))
                {
                   
                    while (dataReader.Read())
                    {
                        ISystemNotice item = new ISystemNotice();
                        item.NoticeID = dataReader["NoticeID"].ToString();
                        item.NoticeBy = dataReader["NoticeBy"].ToString();
                        item.NoticeMessage = dataReader["Message"].ToString();

                        result.Add(item);
                    }

                    return result;

                }

              
            }
            catch (Exception ex)
            {
                this.status = "Error on ISystemNotice List";
                this.message = ex.Message.ToString();
                result.Add(this);
                return result;

            }

        }


    }
}
