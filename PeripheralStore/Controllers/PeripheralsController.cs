// Controllers/PeripheralsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeripheralStore.Data;
using PeripheralStore.Models;

[Route("api/[controller]")]
[ApiController]
public class PeripheralsController : ControllerBase
{
    private readonly AppDbContext _context;

    public PeripheralsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Peripheral>>> GetAll()
    {
        return await _context.Peripherals.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Peripheral>> GetById(int id)
    {
        var item = await _context.Peripherals.FindAsync(id);
        if (item == null) return NotFound();
        return item;
    }

    [HttpPost]
    public async Task<ActionResult<Peripheral>> Create(Peripheral peripheral)
    {
        _context.Peripherals.Add(peripheral);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = peripheral.Id }, peripheral);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Peripheral peripheral)
    {
        if (id != peripheral.Id) return BadRequest();

        _context.Entry(peripheral).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var peripheral = await _context.Peripherals.FindAsync(id);
        if (peripheral == null) return NotFound();

        _context.Peripherals.Remove(peripheral);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
