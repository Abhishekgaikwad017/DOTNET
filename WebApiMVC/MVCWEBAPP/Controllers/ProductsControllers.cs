using BOL;
using DAL;
using Microsoft.AspNetCore.Mvc;
namespace ReactWithWebAPIApp.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
  private readonly ILogger<ProductsController> _logger;
  public ProductsController(ILogger<ProductsController> logger)
  {
    _logger = logger;
  }

  [HttpGet]
  public List<Product> Get()
  {
    List<Product> ls = DBManager.GetAllProducts();
    return ls;
  }

  [HttpGet("{id}")]
  public Product GetById(int id)
  {
    Product p = DBManager.GetAllProductById(id);
    return p;
  }

  [HttpPost]
  public void AddProduct([FromBody] Product p)
  {

    DBManager.AddProduct(p.Id, p.Name, p.Quantity, p.Price);
  }
}



