using Application.Exceptions;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Questions.Commands.DeleteQuestionCommand;
public class DeleteQuestionCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, Response<bool>>
{
    private readonly IQuestionRepository questionRepository;
    private readonly IMapper mapper;

    //private readonly IQuestionRepository question
    public DeleteQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        this.questionRepository = questionRepository;
        this.mapper=mapper;
    }

    public Task<Response<bool>> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private async Task<Response<bool>> Processhandle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await questionRepository.GetEntityByIdAsync(request.Id);

        if (question is null) throw new ApiException($"Quesiton with id {request.Id} not found");

        question.State = false;

        await questionRepository.UpdateAsync(question, question.Id);
        return new Response<bool>();
    }

}

