using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineAssessmentAPI.Data;
using OnlineAssessmentAPI.Models;

namespace OnlineAssessmentAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobDetailsController : ControllerBase
{
    private readonly AssessmentDbContext _context;

    public JobDetailsController(AssessmentDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobDetailsModel>>> GetAll()
    {
        return await _context.JobDetails.ToListAsync();
    }
    
    [HttpGet("{id}")]
        public async Task<ActionResult<JobDetailsModel>> GetById(Guid id)
        {
            var job = await _context.JobDetails.FindAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            return job;
        }

        // POST: api/JobDetails
        [HttpPost]
        public async Task<ActionResult<JobDetailsModel>> Create(JobDetailsModel newJob)
        {
        try
        {
            newJob.Id = Guid.NewGuid(); // Ensure ID is set
            _context.JobDetails.Add(newJob);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newJob.Id }, newJob);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating job details: {ex.Message}");
            return StatusCode(500, "Internal server error while creating job details.");
        }
            
        }

        // PUT: api/JobDetails/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, JobDetailsModel updatedJob)
        {
            if (id != updatedJob.Id)
            {
                return BadRequest();
            }

            _context.Entry(updatedJob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.JobDetails.Any(e => e.Id == id))
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

        // DELETE: api/JobDetails/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
        try
        {
            var job = await _context.JobDetails.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            _context.JobDetails.Remove(job);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting job details: {ex.Message}");
            return StatusCode(500, "Internal server error while deleting job details.");
        }
            
        }
}
