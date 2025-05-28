using Domain.DTOs.Order;
using Domain.Filters;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderService orderService) : ControllerBase
{
    [HttpPost]
    [Authorize]
    public async Task<Response<GetOrderDto>> CreateAsync(CreateOrderDto request)
    {
        return await orderService.CreateAsync(request);
    }

    [HttpPut]
    [Authorize]
    public async Task<Response<GetOrderDto>> UpdateAsync(int id, UpdateOrderDto request, int userId)
    {
        return await orderService.UpdateAsync(id, request, userId);
    }

    [HttpDelete]
    [Authorize]
    public async Task<Response<string>> DeleteAsync(int id, int userId)
    {
        return await orderService.DeleteAsync(id, userId);
    }

    [HttpGet]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<PagedResponse<List<GetOrderDto>>> GetAllAsync([FromQuery] OrderFilter filter)
    {
        return await orderService.GetAllAsync(filter);
    }

    [HttpGet("id")]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<Response<GetOrderDto>> GetByIdAsync(int id, int userId)
    {
        return await orderService.GetByIdAsync(id, userId);
    }   
}