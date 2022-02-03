using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using kaprekars.constant.services;
using kaprekars.constant.data;

namespace kaprekars.constant.core.Controllers;

[ExcludeFromCodeCoverage]
[ApiController]
[Route("v1/kaprekars/constant")]
[Produces("application/json")]
[Consumes("application/json")]
[ProducesResponseType(500)]
public class KaprekarsConstantController : ControllerBase
{
    private IRepository _repo;

    public KaprekarsConstantController(
        IRepository repo)
    {
        _repo = repo ?? throw new ArgumentNullException(nameof(repo));
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public IActionResult Get()
    {
        return Ok(Constants.KaprekarsConstant);
    }

    [HttpGet]
    [Route("{number}/routines")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult GetRoutines([FromRoute, Required] string number)
    {
        try
        {
            return Ok(_repo.GetRoutines(new Request { Number = number }));
        }
        catch (Exception ex)
        {
            return BadRequest(new { code = 400, message = ex.Message });
        }
    }
}
