using Application.Features.Questions.Commands.CreateQuestionCommand;
using Microsoft.AspNetCore.Mvc;

namespace QuestionService.Controllers.v1.Questions;

[ApiVersion("1.0")]
public class CreateQuestionController : BaseApiController
{
    [HttpPost]
    public Task<IActionResult> CreateQuestion(CreateQuestionCommand command, CancellationToken cancellation = default)
    {
        if (command is null)
            throw new ArgumentNullException();

        return ProcessCreateQuestion(command, cancellation);
    }

    private async Task<IActionResult> ProcessCreateQuestion(CreateQuestionCommand command, CancellationToken cancellation = default)
    {
        var result = await Mediator.Send(command, cancellation);
        return CreatedAtRoute("GetQuestionById", new { id = result }, command);
    }

    //[HttpGet("{Id}", Name = "GetCatalogStateById")]
    //public async Task<IActionResult> GetCatalogStateById(Guid Id, CancellationToken cancellationToken)
    //{
    //    var query = new GetCatalogStateByIdQuery { CatalogStateId = Id, };
    //    await _getCatalogStateByIdInputPort.Handle(query, cancellationToken);
    //    var result = ((IPresenter<CatalogStateDto>)_getCatalogStateByIdOutputPort).Content;
    //    return Ok(result);
    //}
}
