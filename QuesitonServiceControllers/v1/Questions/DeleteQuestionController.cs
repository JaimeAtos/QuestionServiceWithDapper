using Application.Features.Questions.Commands.DeleteQuestionCommand;
using Microsoft.AspNetCore.Mvc;


namespace QuestionService.Controllers.v1.Questions;
[ApiVersion("1.0")]
public class DeleteQuestionController : BaseApiController
{
    [HttpDelete]
    public Task<IActionResult> DeleteQuestion(DeleteQuestionCommand command, CancellationToken cancellationToken = default)
    {
        if (command is null)
            throw new ArgumentNullException();

        return ProcessDeleteQuestion(command, cancellationToken);
    }
    public async Task<IActionResult> ProcessDeleteQuestion(DeleteQuestionCommand command, CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(command, cancellationToken);
        return NoContent();
    }

}
