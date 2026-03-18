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
    public IActionResult GetProjects(int pageSize = 5, int pageNum = 1, [FromQuery] List<string>? projectTypes = null)
    {
        var query = _waterContext.Projects.AsQueryable();

        if (projectTypes != null && projectTypes.Any())
        {
            query = query.Where(p => projectTypes.Contains(p.ProjectType));
        }
        
        var totalNumProjects = query.Count();
        
        var something = query
            .Skip((pageNum - 1) * pageSize) 
            // If it is on page 2, it'll skip the number of what's
            // requested to give the right information.
            .Take(pageSize)
            .ToList();

        var someObject = new
        {
            Projects = something, // Two parts of a generic object
            TotalNumProjects = totalNumProjects
        };

        return Ok(someObject);
    }
    
    [HttpGet("GetProjectTypes")]
    public IActionResult GetProjectTypes()
    {
        var projectTypes = _waterContext.Projects
            .Select(p => p.ProjectType)
            .Distinct()
            .ToList();
        
        return Ok(projectTypes);
    }
    
}