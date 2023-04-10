using Domain.Entities;

namespace Domain.Repositories;

public interface IQuestionRepository : IRepositoryBase<Guid, Guid, Question>
{
}
