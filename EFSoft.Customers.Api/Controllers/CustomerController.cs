namespace EFSoft.Customers.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("{customerId:guid}")]
    [ProducesResponseType(typeof(GetCustomerQueryResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid customerId)
    {
        var results = await _mediator.Send(new GetCustomerQuery(customerId));

        if (results == null)
        {
            return NotFound();
        }

        return Ok(results);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<GetCustomerQueryResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        return Ok("Customers microservice is working fine");
    }

    [HttpPost(Name = "Create Customer")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Post([FromBody] CreateCustomerCommand parameters)
    {
        await _mediator.Send(parameters);

        return Ok();
    }

    [HttpPut(Name = "Update Customer")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Put([FromBody] UpdateCustomerCommand parameters)
    {
        await _mediator.Send(parameters);

        return Ok();
    }

    [HttpDelete()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete([FromBody] DeleteCustomerCommand parameters)
    {
        await _mediator.Send(parameters);

        return Ok();
    }
}
