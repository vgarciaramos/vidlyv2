using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidlyv2.Models;
using System.Data.Entity;
using Vidlyv2.ViewModels;
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


        //Para el dropdownlists
        public ActionResult New()
        {
            var memberShipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel { 
                Customer = new Customer(),
                MembershipTypes = memberShipTypes

            };
            return View("CustomerForm",viewModel);
        }

        //Guardar Customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid) {
                var viewModel = new CustomerFormViewModel { 
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm",viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //opciones para actualizar datos
                //TryUpdateModel(customerInDb);
                //TryUpdateModel(customerInDb,"", new string[] {"Name", "Email"} );
                //Mapper.Map(customer, customerInDb);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.isSubscribedToNewsLetter = customer.isSubscribedToNewsLetter;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        //Edit Customer
        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm",viewModel);
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