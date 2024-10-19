namespace JobSite.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTimeOffset Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    // protected BaseAuditableEntity(Guid id) : base(id == Guid.Empty ? Guid.NewGuid() : id)
    // {

    // }
}