using Newtonsoft.Json;
using ShopThoiTrang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThoiTrang.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {

        private ShopThoiTrangDBContext db = new ShopThoiTrangDBContext();
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            double amount = 0;
            string label = "[\"";
            string data = "[";
            for (int i=6; i>=0; i--)
            {
                var date = DateTime.Now.AddDays(-i);
                var startOfDays = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                var endOfDays = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
                var list = db.Orders.Where(m => m.Created_At >= startOfDays && m.Created_At <= endOfDays).OrderByDescending(m => m.Created_At).ToList();
                foreach (var item in list)
                {
                    var listOD = db.OrderDetails.Where(m => m.OrderId == item.Id).ToList();
                    foreach (var itemOD in listOD)
                    {
                        amount = amount + itemOD.Amount;
                    }
                }
                label += date.ToString("dd/MM/yyyy") + "\", \""; 
                data += amount + ",";
                amount = 0;
            }
            var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            var endOfMonth = startOfMonth.AddMonths(1).AddSeconds(-1);
            var listMonth = db.Orders.Where(m => m.Created_At >= startOfMonth && m.Created_At <= endOfMonth).OrderByDescending(m => m.Created_At) .ToList();
            foreach (var item1 in listMonth)
            {
                var listOD1 = db.OrderDetails.Where(m => m.OrderId == item1.Id).ToList();
                foreach (var itemOD1 in listOD1)
                {
                    amount = amount + itemOD1.Amount;
                }
                ViewBag.month = DateTime.Now.Month;
                string formatAmount = String.Format("{0:#,0}", amount);
                ViewBag.amount = formatAmount;
            }
            amount = 0;
            var dateNow = DateTime.Now;
            var startOfDay = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 0, 0, 0);
            var endOfDay = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 23, 59, 59);
            var listDay = db.Orders.Where(m => m.Created_At >= startOfDay && m.Created_At <= endOfDay).OrderByDescending(m => m.Created_At).ToList();
            foreach (var item in listDay)
            {
                var listOD2 = db.OrderDetails.Where(m => m.OrderId == item.Id).ToList();
                foreach (var itemOD2 in listOD2)
                {
                    amount = amount + itemOD2.Amount;
                    string formatAmountDay = String.Format("{0:#,0}", amount);
                    ViewBag.amountDay = formatAmountDay;
                }
            }
            var listContact = db.Contacts.ToList();
            int count = 0;
            foreach (var item in listContact)
            {
                count++;
            }
            ViewBag.CountContact = count;
            label = label.TrimEnd('"');
            label = label.TrimEnd(' ');
            ViewBag.Label = label.TrimEnd(',') + "]";
            ViewBag.chartData = data.TrimEnd(',') + "]";
            return View();
        }
    }
}