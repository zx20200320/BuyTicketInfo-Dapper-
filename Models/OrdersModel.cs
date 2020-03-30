using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuyTicketInfo.Models
{
    [Table("Orders")]
    public class OrdersModel
    {
        /// <summary>
        ///  
        /// <summary>
        public int Id { get; set; }

        /// <summary>
        ///  
        /// <summary>
        public int UserId { get; set; }

        /// <summary>
        ///  
        /// <summary>
        public int TicketId { get; set; }

        /// <summary>
        ///  
        /// <summary>
        public float Price { get; set; }

        /// <summary>
        ///  
        /// <summary>
        public DateTime OrderTime { get; set; }

        /// <summary>
        ///  
        /// <summary>
        public DateTime DepartTime { get; set; }

    }
}