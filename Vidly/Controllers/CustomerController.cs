using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //New For
        public ActionResult New()
        {
            var memberShip = _context.MembershipTypes.ToList();
            var ViewModel = new AddCustomerViewModel
            {
                MembershipTypes = memberShip
            };
            return View(ViewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index","Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var viewModel = new AddCustomerViewModel
            {
                MembershipTypes = _context.MembershipTypes.ToList(),
                Customers = customer

            };
            return View("New",viewModel);
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).ToList();  //.include: Eager Loading ; .ToList
            return View(customer);
        }

        public ActionResult Details(int id)
        {
            var cur = _context.Customers.Include(c=>c.MembershipType).Where(m => m.Id == id).SingleOrDefault();
            if (cur == null)
                return HttpNotFound();
            else
                return View(cur);
        }
    }
}