using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Questions.Commands.CreateQuestionCommand;
//DTO
public class CreateQuestionCommand : IRequest<Response<Guid>>
{
    public string Description { get; set; }
    public short RowOrder { get; set; }
    public string Tags { get; set; }
}

public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, Response<Guid>>
{
    private readonly IQuestionRepository questionRepository;
    private readonly IMapper mapper;

    public CreateQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        //Dependency Injection, hacer el constructor testeable
        this.questionRepository=questionRepository;
        this.mapper=mapper;
    }


    public Task<Response<Guid>> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException();

        return ProcessHandle(request, cancellationToken);
    }

    public async Task<Response<Guid>> ProcessHandle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var newRecord = mapper.Map<Question>(request);
        var data = await questionRepository.CreateAsync(newRecord);

        return new Response<Guid>(data);
    }

}
