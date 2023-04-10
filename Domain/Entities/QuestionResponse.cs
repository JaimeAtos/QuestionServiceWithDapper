using Atos.Core.Commons;

namespace Domain.Entities;

public class QuestionResponse : EntityBase<Guid, Guid>
{
    public Guid QuestionId { get; set; }
    public Guid ResourceId { get; set; }
    public string ResourceName { get; set; }
    public string ResponseQuestion { get; set; }
}
