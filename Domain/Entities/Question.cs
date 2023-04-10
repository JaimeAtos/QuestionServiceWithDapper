using Atos.Core.Commons;

namespace Domain.Entities;

public class Question : EntityBase<Guid, Guid>
{
    public string Description { get; set; }
    public short RowOrder { get; set; }
    public string Tags { get; set; } //Prescreening, BentchServices
}
