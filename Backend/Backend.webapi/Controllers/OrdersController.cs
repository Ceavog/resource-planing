using Backend.DataAccessLibrary;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace Backend.webapi;

[ApiController]
public class OrdersController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IOrderTypesService _orderTypesService;
    public OrdersController(IOrderService orderService, IOrderTypesService orderTypesService)
    {
        _orderService = orderService;
        _orderTypesService = orderTypesService;
    }

    [HttpGet("GetAllOrders")]
    public ActionResult<IEnumerable<OrderModel>> GetAllOrders()
    {
        return Json(_orderService.GetAllOrders());
    }

    [HttpPost("addOrderType")]
    public ActionResult AddType()
    {
        _orderTypesService.AddType();
        return new StatusCodeResult(200);
    }

 
}