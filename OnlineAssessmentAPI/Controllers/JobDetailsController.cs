using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineAssessmentAPI.Data;
using OnlineAssessmentAPI.Models;

namespace OnlineAssessmentAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobDetailsController: ControllerBase
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
}
