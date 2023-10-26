using Microsoft.AspNetCore.Mvc;
using ProdMvc.Models;
namespace ProdMvc.Controllers;

public class ProductController : Controller{
    private readonly NitroContext context;
    public ProductController(NitroContext _context)
    {
        context = _context;
    }

    public IActionResult List(){

        var data = context.Product.ToList();
        return View(data);
    }

    public IActionResult Create()
    {

        return View();
    }

    [HttpPost]
    public IActionResult Create(Product prod){

        if(ModelState.IsValid)
        {
           context.Product.Add(prod);
           context.SaveChanges();
           return RedirectToAction("List");  
        }
           return View();

    }
    public IActionResult Display(int Id){

        var data = context.Product.Find(Id);
        return View(data);

    }
      public IActionResult Edit(int id)
    {
        var data = context.Product.Find(id);
        return View(data);
        
    }
    [HttpPost]
    public IActionResult Edit(Product prod)
    {

        if(ModelState.IsValid)
        {
            Product product = context.Product.Find(prod.Id);
            product.Name = prod.Name;
            product.Price = prod.Price;
            product.Stock = prod.Stock;
            context.SaveChanges();
            return RedirectToAction("List");
        }
        return View();

    }

    public IActionResult Delete(int id)
    {
         var data = context.Product.Find(id);
         return View(data);

    }

    [HttpPost]
    public IActionResult Delete(Product prod)
    {
        Product product = context.Product.Find(prod.Id);
        context.Product.Remove(product);
        context.SaveChanges();
        return RedirectToAction("List");
    }




}