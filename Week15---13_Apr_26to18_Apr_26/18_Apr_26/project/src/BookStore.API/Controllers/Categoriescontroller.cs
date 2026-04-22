using BookStore.Application.DTOs.Categories;
using BookStore.Application.DTOs.Common;
using BookStore.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

/// <summary>
/// Manages book categories. Read endpoints are public; write endpoints require Admin.
/// </summary>
[ApiController]
[Route("api/v1/categories")]
[Produces("application/json")]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    // -------------------------------------------------------------------------
    // GET api/v1/categories
    // -------------------------------------------------------------------------
    /// <summary>Get all categories.</summary>
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<CategoryDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var categories = await categoryService.GetAllAsync();
        return Ok(ApiResponse<IEnumerable<CategoryDto>>.Ok(categories));
    }

    // -------------------------------------------------------------------------
    // GET api/v1/categories/{id}
    // -------------------------------------------------------------------------
    /// <summary>Get a category by ID.</summary>
    [HttpGet("{id:int}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResponse<CategoryDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await categoryService.GetByIdAsync(id);
        return Ok(ApiResponse<CategoryDto>.Ok(category));
    }

    // -------------------------------------------------------------------------
    // POST api/v1/categories              [Admin]
    // -------------------------------------------------------------------------
    /// <summary>Create a new category. Requires Admin role.</summary>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(ApiResponse<CategoryDto>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CategoryCreateDto dto)
    {
        var category = await categoryService.CreateAsync(dto);
        return CreatedAtAction(
            nameof(GetById),
            new { id = category.CategoryId },
            ApiResponse<CategoryDto>.Ok(category, "Category created")
        );
    }

    // -------------------------------------------------------------------------
    // PUT api/v1/categories/{id}          [Admin]
    // -------------------------------------------------------------------------
    /// <summary>Update a category's name. Requires Admin role.</summary>
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] CategoryCreateDto dto)
    {
        await categoryService.UpdateAsync(id, dto);
        return NoContent();
    }

    // -------------------------------------------------------------------------
    // DELETE api/v1/categories/{id}       [Admin]
    // -------------------------------------------------------------------------
    /// <summary>Delete a category. Requires Admin role. Fails if books are assigned to it.</summary>
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await categoryService.DeleteAsync(id);
        return NoContent();
    }
}
