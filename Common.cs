using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BuyTicketInfo
{
    public class Common
    {
        public static string ConnStr = ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString;
    }
}