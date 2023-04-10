using Application.Features.Questions.Commands.UpdateQuestionCommand;
using Microsoft.AspNetCore.Mvc;

namespace QuestionService.Controllers.v1.Questions;
[ApiVersion("1.0")]
public class UpdateQuestionController : BaseApiController
{
    [HttpPut]
    public Task<IActionResult> UpdateQuestion(UpdateQuestionCommand command, CancellationToken cancellationToken = default)
    {
        if (command is null)
            throw new ArgumentNullException();

        return ProcessUpdateQuestion(command, cancellationToken);
    }

    private async Task<IActionResult> ProcessUpdateQuestion(UpdateQuestionCommand command, CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(command, cancellationToken);
        return NoContent();
    }

}
