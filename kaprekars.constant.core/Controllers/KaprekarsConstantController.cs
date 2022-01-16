using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using kaprekars.constant.services;
using kaprekars.constant.data;

namespace kaprekars.constant.core.Controllers;

[ExcludeFromCodeCoverage]
[ApiController]
[Route("v1/kaprekars/constant")]
public class KaprekarsConstantController : ControllerBase
{
    private IRepository _repo;

    public KaprekarsConstantController(
        IRepository repo)
    {
        _repo = repo ?? throw new ArgumentNullException(nameof(repo));
    }

    [HttpGet]
    [ProducesResponseType(typeof(int), 200)]
    public IActionResult Get()
    {
        return Ok(Constants.KaprekarsConstant);
    }

    [HttpGet]
    [Route("{number}/routines")]
    public IActionResult GetRoutines([FromRoute] string number)
    {
        try
        {
            return Ok(_repo.GetRoutines(new data.Request { Number = number }));
        }
        catch (Exception ex)
        {
            return BadRequest(new { code = 400, message = ex.Message });
        }
    }
}
