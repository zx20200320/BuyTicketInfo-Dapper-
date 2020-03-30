using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuyTicketInfo.Models
{
    [Table("Tickets")]
    public class TicketsModel
    {
        /// <summary>
        ///  主键
        /// <summary>
        public int Id { get; set; }

        /// <summary>
        ///  出发站
        /// <summary>
        [Display(Name ="出发站")]
        public string DepartureStation { get; set; }

        /// <summary>
        ///  
        /// <summary>
        [Display(Name = "到达站")]
        public string ArrivalStation { get; set; }

        /// <summary>
        ///  
        /// <summary>
        [Display(Name = "车次")]
        public string TrainNumber { get; set; }

        /// <summary>
        ///  
        /// <summary>
        /// 

        [Display(Name = "开点")]
        public DateTime OpenPoint { get; set; }

        /// <summary>
        ///  
        /// <summary>
        /// 
        [Display(Name = "座位号")]
        public string SeatNo { get; set; }

        /// <summary>
        ///  
        /// <summary>
        [Display(Name = "座次")]
        public string SeatLevel { get; set; }

        /// <summary>
        ///  
        /// <summary>
        [Display(Name = "票价")]
        public float TicketPrice { get; set; }

        /// <summary>
        ///  
        /// <summary>
        [Display(Name = "是否售出")]
        public bool IsSaleOut { get; set; }

    }

}