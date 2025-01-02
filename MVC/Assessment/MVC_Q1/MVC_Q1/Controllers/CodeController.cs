﻿using MVC_Q1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Q1.Controllers
{
    public class CodeController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // CustomersInGermany
        public ActionResult CustomersInGermany()
        {
            var customers = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(customers);
        }

        //CustomerDetails
        public ActionResult CustomerDetails()
        {
            int orderId = 10248;
            var customer = db.Orders
                .Where(o => o.OrderID == orderId)
                .Select(o => o.Customer)
                .FirstOrDefault();

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }


    }
}