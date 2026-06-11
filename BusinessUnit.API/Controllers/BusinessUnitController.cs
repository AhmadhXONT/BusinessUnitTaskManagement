using MediatR;
using Microsoft.AspNetCore.Mvc;
using BusinessUnit.Application.Queries;
using BusinessUnit.Application.Commands;

namespace BusinessUnit.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BusinessUnitController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await mediator.Send(new GetAllBusinessUnitsQuery()));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetBusinessUnitByIdQuery(id));
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBusinessUnitCommand command) => Ok(await mediator.Send(command));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateBusinessUnitCommand command)
    {
        if (id != command.Id) return BadRequest();
        var result = await mediator.Send(command);
        Console.WriteLine($"Update result for Id={id}: {result}"); // ← add this
        return await mediator.Send(command) ? NoContent() : NotFound();
    }
}