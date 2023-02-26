using Sample.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Sample.Models;

namespace Sample.Controllers;

[ApiController]
[Route("[controller]")]
public class SampleController : ControllerBase
{
    private readonly ISampleRepository _sampleRepository;

    public SampleController(ISampleRepository sampleRepository)
    {
        _sampleRepository = sampleRepository;
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> Plus([FromQuery] InputModel model)
    {
        if (model.Value1 < 0)
        {
            ModelState.AddModelError(nameof(model.Value1), "Cannot be negative value");
        }

        if (model.Value2 < 0)
        {
            ModelState.AddModelError(nameof(model.Value2), "Cannot be negative value");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _sampleRepository.Plus(model.Value1, model.Value2);

        return Ok(result);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> Divide([FromQuery] InputModel model)
    {
        if (model.Value2 == 0)
        {
            ModelState.AddModelError(nameof(model.Value2), "Cannot be zero value");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _sampleRepository.Divide(model.Value1, model.Value2);

        return Ok(result);
    }
}