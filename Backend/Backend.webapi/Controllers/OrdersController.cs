using System.IdentityModel.Tokens.Jwt;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.webapi;

[ApiController]
[Authorize]
public class OrdersController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IOrderTypesService _orderTypesService;
    public OrdersController(IOrderService orderService, IOrderTypesService orderTypesService)
    {
        _orderService = orderService;
        _orderTypesService = orderTypesService;
    }


    

    [HttpPost("addOrderType")]
    public ActionResult AddType()
    {
        var id = Helpers.GetUserIdFromJwt(HttpContext.Request.Headers["Authorization"].ToString());    
        _orderTypesService.AddType();
        return new StatusCodeResult(200);
    }

 
}