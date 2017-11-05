using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DataInterface.Interfaces
{
        /**
         * Interface for User Account Model 
         * Definition: This will be used to provide a simple interface of CRUD functions
         **/

    public class IAccount : Models.Account
    {
        private DataOpt.MSSQLConnection _sqlConn;

        public IAccount()
        {
            _sqlConn = new DataOpt.MSSQLConnection(Directory.ConnectionStrings.testing);
        }

        public IAccount(string connectionstring)
        {
            _sqlConn = new DataOpt.MSSQLConnection(connectionstring);
        }

        // for result validation variables
        public string status;
        public string message;
        

        // standard methods for all interfaces <start>

        public string save()
        {
            return null;

        }

        public string insert()
        {
            return null;
        }

        public List<Models.Account> get()
        {
            return null;
        }

        public string remove()
        {
            return null;
        }

        // standard methods for all interfaces <end>



        // special methods for all interfaces <start>
        public IAccount Login(string certificate, string username, string password)
        {
            if (certificate == null) { certificate = "none"; }
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("Certifcate", certificate));
            parameters.Add(_sqlConn.GetParameter("username", username));
            parameters.Add(_sqlConn.GetParameter("password", password));
          
            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_Login, parameters, System.Data.CommandType.StoredProcedure))
                {
                    while (dataReader.Read())
                    {
                        if(dataReader.FieldCount > 1)
                        {
                            this.status = "OK";
                            this.message = "None";
                            this.userid = (string)dataReader["UserID"];
                            this.username = (string)dataReader["u_username"];
                            this.userstatus = (string)dataReader["r_userstatus"];
                            this.userlevel = (string)dataReader["r_userlevel"];
                            this.firstname = (string)dataReader["f_firstname"];
                            this.lastname = (string)dataReader["f_lastname"];
                            this.middlename = (string)dataReader["f_middlename"];
                            this.email = (string)dataReader["f_email"];
                            this.contactno = (string)dataReader["f_contactno"];
                            this.photo = (string)dataReader["f_photo"];
                            this.address = (string)dataReader["f_address"];
                            this.branch = (string)dataReader["r_branch"];
                            this.employeeid = (string)dataReader["f_employeeid"];
                            this.TIN = (string)dataReader["f_TIN"];
                            this.SSS = (string)dataReader["f_SSS"];
                            this.designation = (string)dataReader["r_Designation"];
                            this.gender = (string)dataReader["f_gender"];

                            this.vw_designation = (string)dataReader["vw_desgination"];
                            this.vw_userstatus = (string)dataReader["vw_userstatus"];
                            this.vw_userlevel = (string)dataReader["vw_userlevel"];
                            this.vw_branch = (string)dataReader["vw_branch"];


                            this.isAir =  dataReader["r_isAir"].ToString();
                            this.isSea = dataReader["r_isSea"].ToString();


                            return this;
                        }else
                        {
                            this.status = "DB Thrown Message";
                            this.message = (string)dataReader[0];
                            return this;
                        }
                       
                    }


                }

                this.status = "Empty";
                this.message = "Invalid Username/Password";
                return this;
            }
            catch (Exception ex)
            {
                this.status = "Error on IAccount Login";
                this.message = ex.Message.ToString();
                return this;
               
            }

        }


        public IAccount Certificate(string owner, string username, string password)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_sqlConn.GetParameter("certificateAuthority", username));
            parameters.Add(_sqlConn.GetParameter("certificatePassword", password));
            parameters.Add(_sqlConn.GetParameter("certificateOwner", owner));

            try
            {
                using (DbDataReader dataReader = _sqlConn.GetDataReader(Directory.StoredProcedures.sp_Certificate, parameters, System.Data.CommandType.StoredProcedure))
                {
                    while (dataReader.Read())
                    {
                        if (dataReader.FieldCount > 1)
                        {
                            this.status = "OK";
                            this.message = "None";
                            this.userid = (string)dataReader["Certificate"];
                            this.username = (string)dataReader["Details"];
                            

                            return this;
                        }
                        else
                        {
                            this.status = "DB Thrown Message";
                            this.message = (string)dataReader[0];
                            return this;
                        }

                    }


                }

                this.status = "Empty";
                this.message = "Empty";
                return this;
            }
            catch (Exception ex)
            {
                this.status = "Error on IAccount Certificate";
                this.message = ex.Message.ToString();
                return this;

            }

        }

    }
}
