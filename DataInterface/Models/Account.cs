using System;
using System.Collections.Generic;
using System.Text;

namespace DataInterface.Models
{
    public class Account
    {
        //from main table 
        public string userid;
        public string username;
        public string userstatus;
        public string userlevel;
        public string designation;
        public string firstname;
        public string lastname;
        public string middlename;
        public string gender;
        public string email;
        public string contactno;
        public string photo;
        public string address;
        public string branch;
        public string employeeid;
        public string TIN;
        public string SSS;

        //for display purposes
        public string vw_designation;
        public string vw_userstatus;
        public string vw_userlevel;
        public string vw_branch;


        //for userlevel validation
        public string isAir;
        public string isSea;
        



    }
}
