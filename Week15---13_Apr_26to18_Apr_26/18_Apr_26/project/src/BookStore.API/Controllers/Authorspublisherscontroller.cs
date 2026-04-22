using BookStore.Application.DTOs.Authors;
using BookStore.Application.DTOs.Common;
using BookStore.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

/// <summary>
/// Manages authors. Read endpoints are public; write endpoints require Admin.
/// </summary>
[ApiController]
[Route("api/v1/authors")]
[Produces("application/json")]
public class AuthorsController(IAuthorService authorService) : ControllerBase
{
    // -------------------------------------------------------------------------
    // GET api/v1/authors
    // -------------------------------------------------------------------------
    /// <summary>Get all authors.</summary>
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<AuthorDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var authors = await authorService.GetAllAsync();
        return Ok(ApiResponse<IEnumerable<AuthorDto>>.Ok(authors));
    }

    // -------------------------------------------------------------------------
    // GET api/v1/authors/{id}
    // -------------------------------------------------------------------------
    /// <summary>Get an author by ID, including their books.</summary>
    [HttpGet("{id:int}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResponse<AuthorDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var author = await authorService.GetByIdAsync(id);
        return Ok(ApiResponse<AuthorDto>.Ok(author));
    }

    // -------------------------------------------------------------------------
    // POST api/v1/authors                 [Admin]
    // -------------------------------------------------------------------------
    /// <summary>Create a new author. Requires Admin role.</summary>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(ApiResponse<AuthorDto>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] AuthorCreateDto dto)
    {
        var author = await authorService.CreateAsync(dto);
        return CreatedAtAction(
            nameof(GetById),
            new { id = author.AuthorId },
            ApiResponse<AuthorDto>.Ok(author, "Author created")
        );
    }

    // -------------------------------------------------------------------------
    // PUT api/v1/authors/{id}             [Admin]
    // -------------------------------------------------------------------------
    /// <summary>Update an author's name. Requires Admin role.</summary>
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] AuthorCreateDto dto)
    {
        await authorService.UpdateAsync(id, dto);
        return NoContent();
    }

    // -------------------------------------------------------------------------
    // DELETE api/v1/authors/{id}          [Admin]
    // -------------------------------------------------------------------------
    /// <summary>Delete an author. Requires Admin role. Fails if books are assigned.</summary>
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await authorService.DeleteAsync(id);
        return NoContent();
    }
}

// =============================================================================
// PublishersController
// =============================================================================

/// <summary>
/// Manages publishers. Read endpoints are public; write endpoints require Admin.
/// </summary>
[ApiController]
[Route("api/v1/publishers")]
[Produces("application/json")]
public class PublishersController(IPublisherService publisherService) : ControllerBase
{
    // -------------------------------------------------------------------------
    // GET api/v1/publishers
    // -------------------------------------------------------------------------
    /// <summary>Get all publishers.</summary>
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<PublisherDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var publishers = await publisherService.GetAllAsync();
        return Ok(ApiResponse<IEnumerable<PublisherDto>>.Ok(publishers));
    }

    // -------------------------------------------------------------------------
    // GET api/v1/publishers/{id}
    // -------------------------------------------------------------------------
    /// <summary>Get a publisher by ID.</summary>
    [HttpGet("{id:int}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResponse<PublisherDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var publisher = await publisherService.GetByIdAsync(id);
        return Ok(ApiResponse<PublisherDto>.Ok(publisher));
    }

    // -------------------------------------------------------------------------
    // POST api/v1/publishers              [Admin]
    // -------------------------------------------------------------------------
    /// <summary>Create a new publisher. Requires Admin role.</summary>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(ApiResponse<PublisherDto>), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] PublisherCreateDto dto)
    {
        var publisher = await publisherService.CreateAsync(dto);
        return CreatedAtAction(
            nameof(GetById),
            new { id = publisher.PublisherId },
            ApiResponse<PublisherDto>.Ok(publisher, "Publisher created")
        );
    }

    // -------------------------------------------------------------------------
    // PUT api/v1/publishers/{id}          [Admin]
    // -------------------------------------------------------------------------
    /// <summary>Update a publisher's name. Requires Admin role.</summary>
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] PublisherCreateDto dto)
    {
        await publisherService.UpdateAsync(id, dto);
        return NoContent();
    }

    // -------------------------------------------------------------------------
    // DELETE api/v1/publishers/{id}       [Admin]
    // -------------------------------------------------------------------------
    /// <summary>Delete a publisher. Requires Admin role.</summary>
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await publisherService.DeleteAsync(id);
        return NoContent();
    }
}
