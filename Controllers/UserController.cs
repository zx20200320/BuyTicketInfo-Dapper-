using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuyTicketInfo.Models;
using Dapper;
using Dapper.Contrib.Extensions;

namespace BuyTicketInfo.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserInfoModel userInfo)
        {
            using (SqlConnection conn = new SqlConnection(Common.ConnStr))
            {
                UserInfoModel user = conn.GetAll<UserInfoModel>().Where(u => u.LoginName == userInfo.LoginName && u.Pwd == userInfo.Pwd).FirstOrDefault();

                if (user != null)
                {
                    // 用户信息放到Session中
                    Session["userInfo"] = user;

                    return Redirect("/BuyTicket/Index");
                }
            }

            return View();
        }
    }
}