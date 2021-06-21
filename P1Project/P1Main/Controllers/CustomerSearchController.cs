using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;

namespace P1Main.Controllers
{
  public class CustomerSearchController : Controller
  {
    private readonly IDbInteract _DbInteract; //! might need to change this DbInteract after testing
    public CustomerSearchController(IDbInteract dbInteract) // dependency injection
    {
      this._DbInteract = dbInteract;
    }

    // GET: CustomerSearch
    public ActionResult Index()
    {
      return View();
    }

    // GET: CustomerSearch/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: CustomerSearch/Search
    public ActionResult Search() // has views
    {
      return View();
    }

    public ActionResult DisplayCustomerDetails(CustomerModel customer)
    {
      List<List<string>> CustomerDetails = _DbInteract.GetCustomerSearchDetails(customer.Username, customer.FirstName, customer.LastName);
      return View(CustomerDetails);
    }

    // POST: CustomerSearch/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: CustomerSearch/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: CustomerSearch/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: CustomerSearch/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: CustomerSearch/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }
  }
}
