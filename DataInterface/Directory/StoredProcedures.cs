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
    }
}
