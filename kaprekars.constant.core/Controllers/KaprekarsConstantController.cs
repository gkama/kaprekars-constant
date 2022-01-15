using Microsoft.AspNetCore.Mvc;

using kaprekars.constant.services;
using kaprekars.constant.data;

namespace kaprekars.constant.core.Controllers;

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
}
