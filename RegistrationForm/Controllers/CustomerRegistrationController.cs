using RegistrationForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationForm.Controllers
{
    public class CustomerRegistrationController : Controller
    {
        DACustomer DaCustomer = new DACustomer();

        //
        // GET: /CustomerRegistration/

        public ActionResult Index()
        {
            var customerList = DaCustomer.GetAllCustomers();

            if (customerList == null)
                return RedirectToAction("Index");

            return View(customerList);
        }

        //
        // GET: /CustomerRegistration/Details/5

        public ActionResult Details(int id = 0)
        {
            var customer = DaCustomer.GetCustomerDetails(id);

            if (customer == null)
                return RedirectToAction("Index");

            return View(customer);
        }

        //
        // GET: /CustomerRegistration/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CustomerRegistration/Create

        [HttpPost]
        public ActionResult Create(CustomerViewModel Customer)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(Customer);

                bool check = DaCustomer.CreateNewCustomer(Customer);

                if (check == false)
                    return View(Customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(Customer);
            }
        }

        //
        // GET: /CustomerRegistration/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var customer = DaCustomer.GetCustomerDetails(id);

            if (customer == null)
                return RedirectToAction("Index");

            return View(customer);
        }

        //
        // POST: /CustomerRegistration/Edit/5

        [HttpPost]
        public ActionResult Edit(CustomerViewModel customer, int id = 0)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(customer);

                bool check = DaCustomer.EditCustomer(customer);

                if (check == false)
                    return View(customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(customer);
            }
        }

        //
        // GET: /CustomerRegistration/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var customer = DaCustomer.GetCustomerDetails(id);

            if (customer == null)
                return RedirectToAction("Index");

            return View(customer);
        }

        //
        // POST: /CustomerRegistration/Delete/5

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id = 0)
        {
            try
            {
                bool check = DaCustomer.RemoveCustomer(id);

                //if (check == false)
                //    return View(customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return HttpNotFound();
            }
        }

    }
}
