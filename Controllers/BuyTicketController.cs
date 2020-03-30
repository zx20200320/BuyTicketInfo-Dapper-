using BuyTicketInfo.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuyTicketInfo.Controllers
{
    public class BuyTicketController : Controller
    {
        SqlConnection conn = new SqlConnection(Common.ConnStr);

        // GET: BuyTicket
        public ActionResult Index()
        {
            using (conn)
            {
                List<TicketsModel> ticketsModels = conn.GetAll<TicketsModel>().ToList();

                return View(ticketsModels);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TicketsModel model)
        {
            using (conn)
            {
                long cnt = conn.Insert<TicketsModel>(model);
                if (cnt > 0)
                {
                    return Content("<script>alert('添加成功！'); window.location.href='/BuyTicket/Index'</script>");
                }
                else
                {
                    return Content("<script>alert('添加失败！'); window.location.href='/BuyTicket/Index'</script>");
                }
            }
        }

        public ActionResult Buy()
        {
            using (conn)
            {
                // 判断有没有票
                var ticketInfos = conn.GetAll<TicketsModel>().Where(t => !t.IsSaleOut);
                if (ticketInfos.Count() < 1)
                {
                    return Content("<script>alert('没有余票!');</script>");
                }

                // 获取用户Id
                int userId = ((UserInfoModel)Session["userInfo"]).Id;
                var buyTicketInfos = conn.GetAll<OrdersModel>().Where(o => o.UserId == userId && o.DepartTime.Subtract(DateTime.Now).Ticks > 0);
                if (buyTicketInfos.Count() > 0)
                {
                    return Content("<script>alert('已买到票， 不需要再购买');</script>");
                }

                // 把车票信息放到队列中去
                Queue<TicketsModel> ticketsAsQueue = new Queue<TicketsModel>();
                foreach (TicketsModel item in ticketInfos)
                {
                    // 入队列
                    ticketsAsQueue.Enqueue(item);
                }

                bool isOk = false;
                TicketsModel ti = null;
                while (ticketsAsQueue.Count() > 0)
                {
                    // 出队列
                    ti = ticketsAsQueue.Dequeue();

                    //[UserId]
                    //[TicketId]
                    //[Price]
                    //[OrderTime]
                    //[DepartTime]

                    //保存购票信息
                    isOk = conn.Insert<OrdersModel>(new OrdersModel
                    {
                        UserId = userId,
                        TicketId = ti.Id,
                        Price = ti.TicketPrice,
                        OrderTime = DateTime.Now,
                        DepartTime = ti.OpenPoint.AddDays(1)
                    }) > 0;

                    break;
                }

                if (isOk)
                {
                    // 更新车票是否已售出状态
                    conn.Update<TicketsModel>(new TicketsModel
                    {
                        Id = ti.Id,
                        ArrivalStation = ti.ArrivalStation,
                        DepartureStation = ti.DepartureStation,
                        SeatLevel = ti.SeatLevel,
                        SeatNo = ti.SeatNo,
                        TicketPrice = ti.TicketPrice,
                        TrainNumber = ti.TrainNumber,
                        OpenPoint = DateTime.Now.AddDays(1),
                        IsSaleOut = true
                    });

                    return Content("<script>alert('购票成功！');</script>");
                }

            }

            return View();
        }
    }
}