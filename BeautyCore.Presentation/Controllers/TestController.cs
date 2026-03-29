using BeautyCore.Domain.Entities;
using BeautyCore.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeautyCore.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly BeautyCoreDbContext _context;

    public TestController(BeautyCoreDbContext context)
    {
        _context = context;
    }

    [HttpPost("create-branch")]
    public async Task<IActionResult> CreateBranch(string name)
    {
        var branch = new Branch { Name = name };

        // Biz tarih set etmiyoruz, DbContext'teki SaveChanges halledecek!
        _context.Branches.Add(branch);
        await _context.SaveChangesAsync();

        return Ok(branch);
    }

    [HttpGet("get-branches")]
    public async Task<IActionResult> GetBranches()
    {
        var branches = await _context.Branches.ToListAsync();
        return Ok(branches);
    }
}
