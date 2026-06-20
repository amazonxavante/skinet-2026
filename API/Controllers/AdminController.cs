using API.RequestHelpers;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.DTOs;
using API.Extensions;

namespace API.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController(IUnitOfWork unit,IPaymentService paymentService) : BaseAPIController
{
    [HttpGet("orders")]
    public async Task <ActionResult<IReadOnlyList<OrderDto>>> GetOrders([FromQuery]OrderSpecParams specParams)
    {
        var spec = new OrderSpecification(specParams);
    
          return await  createPageResult(unit.Repository<Order>(),
            spec, specParams.PageIndex,specParams.PageSize, o => o.ToDto());
    }

    [HttpGet("orders/{id:int}")]
    public async Task<ActionResult<OrderDto>> GetOrderById(int id)
    {
        var spec = new OrderSpecification(id);
        var order = await unit.Repository<Order>().GetEntityWithSpec(spec);
        if (order == null) return BadRequest("Not order with that id  found");
        return Ok(order.ToDto());
    }

    [HttpPost("orders/refund/{id:int}")]
    public async Task <ActionResult<OrderDto>>RefundOrder(int id)
    {
        var spec = new OrderSpecification(id);

        var order = await unit.Repository<Order>().GetEntityWithSpec(spec);

        if (order == null) return BadRequest("Not order with that id  found");

        if (order.Status == OrderStatus.Pending)
         return BadRequest("Payment no received for this order");

         var result = await paymentService.RefundPayment(order.PaymentIntentId);
         if (result == "succeeded")
         {
            order.Status = OrderStatus.Refunded;
            
            await unit.Complete();
            return order.ToDto();
         }

            return BadRequest("Refund failed");
    }

    
}
