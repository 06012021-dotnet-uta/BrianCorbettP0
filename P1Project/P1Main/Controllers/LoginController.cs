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
  public class LoginController : Controller
  {
    private readonly IDbInteract _DbInteract;
    // create a constructor into which the business layer dependency will be injected (in Startup.cs)
    public LoginController(IDbInteract dbInteract)
    {
      this._DbInteract = dbInteract;
    }

    // GET: LoginController
    public ActionResult Index()
    {
      return View();
    }

    // GET: LoginController/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: LoginController/Create
    public ActionResult LoginCustomer()
    {
      return View();
    }

    [HttpPost]
    public ActionResult VerifyLoginCustomer(CustomerModel customerLogin)
    {
      bool SuccessfulVerification = _DbInteract.VerifyCustomer(customerLogin.Username, customerLogin.Password);
      if (SuccessfulVerification)
      {
        CustomerModel customer = _DbInteract.GetCustomer(customerLogin.Username, customerLogin.Password);
        return RedirectToAction("Index", "Home", customer);
      }
      else
        return View("LoginCustomer");
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

    // GET: LoginController/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: LoginController/Edit/5
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

    // GET: LoginController/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: LoginController/Delete/5
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
