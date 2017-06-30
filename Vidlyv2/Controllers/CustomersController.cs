﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidlyv2.Models;
namespace Vidlyv2.Controllers
{
    public class CustomersController : Controller
    {

        //*-*-*-*-* Ejercicio 2
        public ViewResult Index()
        {

            var customers = GetCustomers();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customers = GetCustomers().SingleOrDefault(c => c.Id == id);
            if (customers == null)
                return HttpNotFound();


            return View(customers);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer> { 
                new Customer{Id = 1, Name = "John Smith"},
                new Customer{Id = 2, Name = "Mary Williams"}
            };
        }


        

        //public ActionResult Random()
        //{
        //    var customers = new List<Customer>
        //    {
        //        new Customer{ Name = "John Smith"},
        //        new Customer{ Name = "Mary Williams"}
        //    };

        //    return View(customers);
        //}
    }
}