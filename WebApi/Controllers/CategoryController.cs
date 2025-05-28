using Domain.DTOs.Category;
using Domain.Filters;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<Response<GetCategoryDto>> CreateAsync(CreateCategoryDto request)
    {
        return await categoryService.CreateAsync(request);
    }

    [HttpPut]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<Response<GetCategoryDto>> UpdateAsync(int id, UpdateCategoryDto request)
    {
        return await categoryService.UpdateAsync(id, request);
    }

    [HttpDelete]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<Response<string>> DeleteAsync(int id)
    {
        return await categoryService.DeleteAsync(id);
    }

    [HttpGet]
    [Authorize]
    public async Task<PagedResponse<List<GetCategoryDto>>> GetAllAsync([FromQuery] CategoryFilter filter)
    {
        return await categoryService.GetAllAsync(filter);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<Response<GetCategoryDto>> GetByIdAsync(int id)
    {
        return await categoryService.GetByIdAsync(id);
    }
}