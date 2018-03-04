using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy_VidlyApp.Models;
using Udemy_VidlyApp.ViewModel;
using System.Data.Entity;


namespace Udemy_VidlyApp.Controllers
{
    public class CustomerController : Controller
    {

        private ApplicationDbContext _context;

        //public ViewResult Index()
        //{
        //    var customers = GetCustomers();
        //    return View(customers);
        //}

        //public ActionResult Details(int id)
        //{
        //    var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
        //    if (customer == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(customer);
        //}

        public CustomerController()
        {
           _context = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //GET: Customer
        [Route("Customers/")]
        public ActionResult Customers()
        {
            

            var viewmodel = new RandomMovieViewModel
            {
                Customer = _context.Customer.Include(c => c.MemberShipType).ToList()
        };
            return View(viewmodel);
        }
        [Route("Customer/Details/{id}")]
        public ActionResult Details(int id)
        {
            var customers = _context.Customer.Include(c=>c.MemberShipType).ToList().SingleOrDefault(c => c.Id == id);

            if (customers == null)
                return HttpNotFound();

           
            ViewData["Customer"] = customers;
            return View();
           
        }

        public ActionResult New()
        {
            var membershiptypes = _context.MemberShipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                Customer= new Customer(),
                
                MemberShipTypes = membershiptypes
            };
            ViewBag.ViewModel = viewModel;
            return View("CustomerForm");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Customer customer)
        {
                var customerinDb = _context.Customer.Include(c=>c.MemberShipType).Single(c => c.Id == customer.Id);

                //  TryUpdateModel(customerinDb);
                // Mapper.Map(customer","customerinDb");
                //  TryUpdateModel(customerinDb, "" , new string{"Name","Email");

                customerinDb.Name = customer.Name;
                customerinDb.Dob= customer.Dob;
                customerinDb.MemberShipTypeId = customer.MemberShipTypeId;
                customerinDb.IsSuscribed = customer.IsSuscribed;



                _context.SaveChanges();
            

            return RedirectToAction("Customers", "Customer");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MemberShipTypes = _context.MemberShipTypes.ToList()
                };
                ViewBag.ViewModel = viewModel;
                return  View("CustomerForm");
            }

            _context.Customer.Add(customer);
            _context.SaveChanges();


            return RedirectToAction("Customers", "Customer");
        }
        public ActionResult Edit(int id)
        {
            Customer customer = _context.Customer.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };
            ViewBag.ViewModel = viewModel;
            return View();
        }



















        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer { Id=1, Name="Georgy Jose"},
        //        new Customer{Id=2, Name= "Tony Jose" }

        //    };
        //}
    }
}