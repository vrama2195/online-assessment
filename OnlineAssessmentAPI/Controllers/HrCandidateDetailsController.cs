using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineAssessmentAPI.Data;
using OnlineAssessmentAPI.Models;

namespace OnlineAssessmentAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HrCandidateDetailsController : ControllerBase
{
    private readonly AssessmentDbContext _context;

    public HrCandidateDetailsController(AssessmentDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<HrCandidateDetailsModel>>> GetAll()
    {
        return await _context.CandidateDetails.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HrCandidateDetailsModel>> GetById(Guid id)
    {
        var candidate = await _context.CandidateDetails.FindAsync(id);
        if (candidate == null)
        {
            return NotFound();
        }
        return candidate;
    }

    [HttpPost]
    public async Task<ActionResult<HrCandidateDetailsModel>> Create(HrCandidateDetailsModel newCandidate)
    {
        if (newCandidate.Id == null)
        {
            newCandidate.Id = Guid.NewGuid(); // Ensure ID is set
        }
        _context.CandidateDetails.Add(newCandidate);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = newCandidate.Id }, newCandidate);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, HrCandidateDetailsModel updatedCandidate)
    {
        if (id != updatedCandidate.Id)
        {
            return BadRequest();
        }
        _context.Entry(updatedCandidate).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.CandidateDetails.Any(e => e.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var candidate = await _context.CandidateDetails.FindAsync(id);
        if (candidate == null)
        {
            return NotFound();
        }
        _context.CandidateDetails.Remove(candidate);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}