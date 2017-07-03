﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidlyv2.Models;
using System.Data.Entity;

namespace Vidlyv2.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //*-*-*-*-* Ejercicio 2
        public ViewResult Index()
        {

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customers = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customers == null)
                return HttpNotFound();


            return View(customers);
        }

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer> { 
        //        new Customer{Id = 1, Name = "John Smith"},
        //        new Customer{Id = 2, Name = "Mary Williams"}
        //    };
        //}


        
    }
}