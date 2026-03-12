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
    public IEnumerable<Project> Get()
    {
        return _waterContext.Projects.ToList();
    }

    [HttpGet("FunctionalProjects")]
    public IEnumerable<Project> GetFunctionalProjects()
    {
        var something = _waterContext.Projects.Where(p => p.ProjectFunctionalityStatus == "Functional").ToList();
        return something;
    }
    
}