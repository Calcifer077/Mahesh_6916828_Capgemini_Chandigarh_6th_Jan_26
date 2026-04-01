using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
 
    public TransactionsController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetTransactions()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

        if (userIdClaim == null)
            return Unauthorized("User ID not found in token");

        var userId = int.Parse(userIdClaim.Value);

        var transactions = _context.Transactions
            .Where(t => t.UserId == userId)
            .ToList();

        var result = _mapper.Map<List<TransactionDTO>>(transactions);

        return Ok(result);
}
}