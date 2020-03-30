using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuyTicketInfo.Models
{
    [Table("UserInfo")]
    public class UserInfoModel
    {
        /// <summary>
        ///  
        /// <summary>
        public int Id { get; set; }

        /// <summary>
        ///  
        /// <summary>
        public string Name { get; set; }

        /// <summary>
        ///  
        /// <summary>
        public string LoginName { get; set; }

        /// <summary>
        ///  
        /// <summary>
        public string Pwd { get; set; }

        /// <summary>
        ///  
        /// <summary>
        public string Remark { get; set; }

    }
}

