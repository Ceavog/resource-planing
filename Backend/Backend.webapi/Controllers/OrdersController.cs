using Backend.DataAccessLibrary;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace Backend.webapi;

[ApiController]
public class OrdersController : Controller
{
    private readonly IOrderService _orderService;
    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("GetAllOrders")]
    public ActionResult<IEnumerable<OrderModel>> GetAllOrders()
    {
        return Json(_orderService.GetAllOrders());
    }

    [HttpGet("OrdersWithMenuPositions")]
    public ActionResult<IEnumerable<Order>> OrdersWithMenuPositions()
    {
        return Json(_orderService.GetAllOrdersWithOrderPositions());
    }
}