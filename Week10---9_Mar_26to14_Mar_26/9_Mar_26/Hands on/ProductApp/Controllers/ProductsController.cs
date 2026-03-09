using Microsoft.AspNetCore.Mvc;

public class ProductsController : Controller
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    public IActionResult List()
    {
        var products = _service.GetProducts();
        return View(products);
    }
}