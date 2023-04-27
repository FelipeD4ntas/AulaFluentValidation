using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoFluentValidation.Domain.Commands.UsuarioCommands.AdicionarUsuario;

namespace ProjetoFluenteValidation.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsuarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("adicionar")]
    public async Task<IActionResult> Adicionar(AdicionarUsuarioRequest request)
    {
        var response = await _mediator.Send(request);

        if (response.Success)
        {
            return Created("", response);
        }

        return BadRequest(response);
    }
}
