using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Connector.Models;
using BOL;
using BLL.connect;
using DAL.connect;
namespace Connector.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

     public IActionResult Products()
    {
      ProductMgr mgr = new ProductMgr();
      List<Product> ls = mgr.getAllProduct();
      ViewData["allproduct"] = ls;
      return View();
        
    }

    public IActionResult Insert(){
      return View();
    }

    [HttpPost]
    public IActionResult Insert(string title,double price){
        DBManager.Insertdata(title,price);
       
      return View();
    }

    public IActionResult Succesfull()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Delete(string de)
    {
        DBManager.deleteData(de);
       
        return View();
    }

    public IActionResult Delete()
    {
      ProductMgr mgr = new ProductMgr();
      List<Product> ls = mgr.getAllProduct();
      ViewData["allproduct"] = ls;
        return View();
    }
}
