using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WaterProjectAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace WaterProjectAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WaterController: ControllerBase
{
    private WaterDbContext _waterContext;
    
    public WaterController(WaterDbContext temp) => _waterContext = temp;
    
    [HttpGet("AllProjects")]
    public IActionResult GetProjects(int pageSize = 5, int pageNum = 1)
    {
        var something = _waterContext.Projects
            .Skip((pageNum - 1) * pageSize) 
            // If it is on page 2, it'll skip the number of what's
            // requested to give the right information.
            .Take(pageSize)
            .ToList();
        
        var totalNumProjects = _waterContext.Projects.Count();

        var someObject = new
        {
            Projects = something, // Two parts of a generic object
            TotalNumProjects = totalNumProjects
        };

        return Ok(someObject);
    }

    [HttpGet("FunctionalProjects")]
    public IEnumerable<Project> GetFunctionalProjects()
    {
        var something = _waterContext.Projects.Where(p => p.ProjectFunctionalityStatus == "Functional").ToList();
        return something;
    }
    
}