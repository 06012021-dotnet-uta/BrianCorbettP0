using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P1Main.Controllers
{
  public class SignupController : Controller // maybe change to AccountController and have signup and login here
  {
    private readonly IDbInteract _DbInteract; //! might need to change this DbInteract after testing
    public SignupController(IDbInteract dbInteract) // dependency injection
    {
      this._DbInteract = dbInteract;
    }

    // GET: SignupController
    public ActionResult Index()
    {
      return View();
    }

    // GET: SignupController/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: SignupController/Create
    public ActionResult CreateCustomer() // has view [CreateCustomer.cshtml]
    {
      return View();
    }
    // GET: SignupController/Create/[id]
    [HttpPost] // because you're sending data
    public ActionResult VerifyCreateCustomer(CustomerModel customer) // has view [VerifyCreateCustomer.cshtml]
    {
      if (!ModelState.IsValid) // if the model passed in is not valid (it didn't get bound correctly somehow)
        RedirectToAction("CreateCustomer"); // redirects to the Create() action method

      return View(customer);
    }
    //[HttpPost]
    public async Task<ActionResult> SubmitNewCustomer(CustomerModel customer) // has view [SubmitNewCustomer.cshtml]
    {
      if (!ModelState.IsValid) // if the model passed in is not valid (it didn't get bound correctly somehow)
        RedirectToAction("CreateCustomer"); // redirects to the Create() action method

      // call RegisterNewCustomer() in BusinessLayer.DbInteract to insert the new customer to the Db
      bool SuccessfulRegistration = await _DbInteract.RegisterNewCustomer(customer);
      if (SuccessfulRegistration)
      {
        ViewBag.RegSuccess = "You are registered!";
        return View();
      }
      else
      {
        ViewBag.Error = "There was an error";
        return View("Error"); // Views/Shared/Error.cshtml
      }
    }

    // POST: LoginController/Create
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

    // GET: SignupController/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: SignupController/Edit/5
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

    // GET: SignupController/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: SignupController/Delete/5
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
