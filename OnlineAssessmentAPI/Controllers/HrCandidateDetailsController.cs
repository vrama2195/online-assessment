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
}