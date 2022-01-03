namespace EFSoft.Customers.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICommandExecutor _commandExecutor;
    private readonly IQueryExecutor _queryExecutor;

    public CustomerController(
            ICommandExecutor commandExecutor,
            IQueryExecutor queryExecutor)
    {
        _commandExecutor = commandExecutor
            ?? throw new ArgumentNullException(nameof(commandExecutor));
        _queryExecutor = queryExecutor
            ?? throw new ArgumentNullException(nameof(queryExecutor));

    }

    [HttpGet]
    [Route("{customerId:guid}")]
    [ProducesResponseType(typeof(GetCustomerQueryResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid customerId)
    {
        var results = await _queryExecutor.ExecuteAsync<GetCustomerQueryParameters, GetCustomerQueryResult>(
         new GetCustomerQueryParameters(
             customerId: customerId));

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
        return Ok("Is working fine");
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Post([FromBody] CreateCustomerCommandParameters parameters)
    {
        await _commandExecutor.ExecuteAsync(parameters);

        return Ok();
    }

    [HttpPut()]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Put([FromBody] UpdateCustomerCommandParameters parameters)
    {
        await _commandExecutor.ExecuteAsync(parameters);

        return Ok();
    }

    [HttpDelete()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete([FromBody] DeleteCustomerCommandParameters parameters)
    {
        await _commandExecutor.ExecuteAsync(parameters);

        return Ok();
    }
}
