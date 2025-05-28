using Domain.DTOs.Product;
using Domain.Filters;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<Response<GetProductDto>> CreateAsync(CreateProductDto request, int userId)
    {
        return await productService.CreateAsync(request, userId);
    }

    [HttpPut]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<Response<GetProductDto>> UpdateAsync(int id, UpdateProductDto request, int userId)
    {
        return await productService.UpdateAsync(id, request, userId);
    }

    [HttpDelete]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<Response<string>> DeleteAsync(int id, int userId)
    {
        return await productService.DeleteAsync(id, userId);
    }

    [HttpGet]
    [Authorize]
    public async Task<PagedResponse<List<GetProductDto>>> GetAllAsync([FromQuery] ProductFilter filter)
    {
        return await productService.GetAllAsync(filter);
    }
    
    [HttpGet("{id}")]
    public async Task<Response<GetProductDto>> GetByIdAsync(int id)
    {
        return await productService.GetByIdAsync(id);
    }

    [HttpPost("Promote-product")]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<Response<GetProductDto>> PromoteProductAsync(int id, PromoteProductDto request, int userId)
    {
        return await productService.PromoteProductAsync(id, request, userId);
    }
}