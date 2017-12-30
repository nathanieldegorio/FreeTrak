using System;
using System.Collections.Generic;
using System.Text;

namespace DataInterface.Directory
{
    public class StoredProcedures
    {
        ///<summary>
        ///pr_login @Certifcate,@username,@password
        ///</summary>
        public static string sp_Login = "pr_login";

        ///<summary>
        ///pr_CreateCertificate @certificateAuthority,@certificatePassword,@certificateOwner
        ///</summary>
        public static string sp_Certificate = "pr_CreateCertificate";

        ///<summary>
        ///vw_getSystemNotices [no Parameters]
        ///</summary>
        public static string sp_SystemNotices = "vw_getSystemNotices";


        ///<summary>
        ///sp_Branch @BranchID,@BranchName,@BranchCode,@ParentBranch,@Address,@search,@disable <para />
        ///fields are nullable<para />
        ///Disable -> set BranchID and @disable parameter<para />
        ///Create -> set @BranchID,@BranchName,@BranchCode,@ParentBranch,@Address parameter<para />
        ///Update -> set @BranchID,@BranchName,@BranchCode,@ParentBranch,@Address parameter<para />
        ///Search -> set @search parameter
        ///</summary>
        public static string sp_Branch = "sp_Branch";


        public static string sp_UserDesignation = "sp_UserDesignation";

        public static string sp_PaymentType = "sp_PaymentType";

        public static string sp_CollectionType = "sp_CollectionType";


        public static string sp_CargoUnit = "sp_CargoUnit";
        public static string sp_CustomerProfile  = "sp_CustomerProfiles";

        public static string sp_SeaDestination = "sp_DestinationRoutes";


        public static string sp_SeaShipments = "sp_SeaShipments";


        




    }
}
