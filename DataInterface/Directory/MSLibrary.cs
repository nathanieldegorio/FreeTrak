using System;
using System.Collections.Generic;
using System.Text;

namespace DataInterface.Directory
{
    public class MSLibrary
    {
        public static string Login = "Select UserID, UserDesignation from userAccounts where login=@login and pass=@pass";
        public static string getMenuAccess = "SELECT menuID, userDesignationAccess , defaultDashboard FROM dbo.tbl_designationMenus where userDesignation = @userDesignation";

    }
}
