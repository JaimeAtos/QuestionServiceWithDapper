using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Questions.Commands.UpdateQuestionCommand;

public class UpdateQuestionCommand : IRequest<Response<Guid>>
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public short RowOrder { get; set; }
    public string Tags { get; set; }
}

public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, Response<Guid>>
{
    private readonly IQuestionRepository questionRepository;
    private readonly IMapper mapper;

    public UpdateQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        //Dependency Injection, hacer el constructor testeable
        this.questionRepository=questionRepository;
        this.mapper=mapper;
    }


    public Task<Response<Guid>> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException();

        return ProcessHandle(request, cancellationToken);
    }

    public async Task<Response<Guid>> ProcessHandle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await questionRepository.GetEntityByIdAsync(request.Id);
        //Corregir despues que no tire el error en un metodo asincrono
        if (question is null)
            throw new ApiException($"Question with id {request.Id} not found");


        var newQuestion = mapper.Map<Question>(request);

        await questionRepository.UpdateAsync(newQuestion, newQuestion.Id);

        return new Response<Guid>(newQuestion.Id);
    }

}