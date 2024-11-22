namespace JobSite.Application.Common.Security.Request;
public interface IdentityEntityAttribute<T> : IRequest<T>
{
    public Guid Id { get; init; }
}