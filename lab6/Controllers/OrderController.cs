using lab6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;

namespace lab6.Controllers
{
    public class OrderController : Controller
    {

        CustomerDbContext _context = new CustomerDbContext();

        // GET: OrderController
        public ActionResult Index()
        {
            SelectList CustomerrSL = new SelectList(_context.Customers.ToList(), "ID", "Name");
            ViewBag.allCustomers = CustomerrSL;
            return View(_context.Orders.ToList());

        }


        [HttpPost]
        public IActionResult Index(IFormCollection collection)
        {
            int customerid = int.Parse(collection["customerLst"]);
            var selectedOrders = _context.Orders.Include(o => o.Customer).Where(o => o.CustID == customerid).ToList();

            SelectList CustomerrSL = new SelectList(_context.Customers.ToList(), "ID", "Name",customerid);
            ViewBag.allCustomers = CustomerrSL;

            return View(selectedOrders);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.Orders.Include(o=> o.Customer).FirstOrDefault(o => o.ID == id));

        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            var customers = _context.Customers.ToList();
            ViewBag.CustomerList = new SelectList(customers, "ID", "Name");
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var customers = _context.Customers.ToList();
                ViewBag.CustomerList = new SelectList(customers, "ID", "Name");
                return View(order);
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            var order = _context.Orders.Include(o => o.Customer).SingleOrDefault(o => o.ID == id);
            if (order == null)
            {
                return NotFound();
            }

            var customers = _context.Customers.ToList();

            ViewBag.CustomerList = new SelectList(customers, "ID", "Name", order.Customer.ID);

            return View(order);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order order)
        {
            if (id != order.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              
                var customer = _context.Customers.SingleOrDefault(c => c.ID == order.CustID);
                if (customer == null)
                {
                    ModelState.AddModelError("Customer", "Invalid Customer ID");
                    return View(order); 
                }

                order.Customer = customer;
                _context.Update(order);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            var customers = _context.Customers.ToList();
            ViewBag.CustomerList = new SelectList(customers, "ID", "Name", order.CustID);
            return View(order);
        }



        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _context.Orders.Include(o=>o.Customer)
                .FirstOrDefault(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
